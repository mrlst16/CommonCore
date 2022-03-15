using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CommonCore2.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SqlDebuggingExtensions
    {
        private static readonly string newline = System.Environment.NewLine;

        public static string ToSqlString(this SqlParameter[] parameters, string sprocName)
        {
            try
            {
                string result = string.Empty;
                var structuredParameters = parameters.Where(x => x.SqlDbType == SqlDbType.Structured);
                var unstructuredParameters = parameters.Where(x => x.SqlDbType != SqlDbType.Structured);

                foreach (var structuredParameter in structuredParameters)
                    result += UdtToParametersString(structuredParameter);

                result += $"exec {sprocName} ";

                if (unstructuredParameters?.Any() ?? false)
                {
                    result += unstructuredParameters.Select(p => $"{p?.ParameterName}={FormatParameter(p)}").Aggregate((x, y) => $"{x}, {y}");
                }
                if (structuredParameters?.Any() ?? false)
                {
                    result += ',';
                    result += structuredParameters?.Select(p => $"{p?.ParameterName}={p?.ParameterName}_var")?.Aggregate((x, y) => $"{x}, {y}");
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static string FormatParameter(SqlParameter parameter)
        {
            if (parameter == null)
                return string.Empty;

            if (parameter.SqlValue == null)
                return "null";

            var str = parameter.SqlValue.ToString();

            if (bool.TryParse(str, out bool value))
                return value ? "1" : "0";

            return $"'{str}'";
        }

        private static string UdtToParametersString(SqlParameter udt)
        {
            string result = string.Empty;
            var table = udt.Value as DataTable;
            if (table.Rows.Count == 0)
                return result;

            List<string> columnNames = new List<string>();
            foreach (DataColumn column in table.Columns)
                columnNames.Add(column.ColumnName);

            result = $"declare {udt.ParameterName}_var {udt.TypeName}{newline}";
            DataRow firstRow = table.Rows[0];
            result += $"insert into {udt.ParameterName}_var select {UdtRowToParametersString(firstRow)}{newline}";

            for (int i = 1; i < table.Rows.Count; i++)
            {
                result += "union select " + UdtRowToParametersString(table.Rows[i]) + newline;
            }
            return result;
        }

        private static string UdtRowToParametersString(DataRow row)
        {
            var result = string.Empty;

            for (int i = 0; i < row.Table.Columns.Count; i++)
            {
                var val = row.ItemArray.ElementAt(i).ToString();
                result += $"'{val}', ";
            }
            result = result.Trim().Trim(',');
            return result;
        }
    }
}