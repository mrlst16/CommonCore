using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.MongoDb.TestHelpers
{
	/// <summary>
	/// Credit to Thomas B https://www.thomasb.fr/2017/12/unit-testing-mongodb-queries/
	/// </summary>
	public class MongoDaemon : IDisposable
	{
		public const string ConnexionString = "mongodb://localhost:27017";
		public const string DbName = "test";
		public const string Host = "localhost";
		public const string Port = "27017";
		private readonly string assemblyFolder;
		private readonly string dbFolder;
		private readonly string mongoFolder;
		private Process process;

		public MongoDaemon()
		{
			this.assemblyFolder = Path.GetDirectoryName(new Uri(typeof(MongoDaemon).Assembly.CodeBase).LocalPath);
			this.mongoFolder = Path.Combine(this.assemblyFolder, "mongo");
			this.dbFolder = Path.Combine(this.mongoFolder, "temp");

			// re-create db folder if it exists
			if (Directory.Exists(this.dbFolder))
			{
				Directory.Delete(this.dbFolder, true);
				Directory.CreateDirectory(this.dbFolder);
			}

			this.process = new Process();
			process.StartInfo.FileName = Path.Combine(this.mongoFolder, "mongod.exe");
			process.StartInfo.Arguments = "--dbpath " + this.dbFolder + " --storageEngine ephemeralForTest";
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public string Query(string query)
		{
			var output = string.Empty;

			var procQuery = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = Path.Combine(this.mongoFolder, "mongo.exe"),
					Arguments = string.Format("--host {0} --port {1} --quiet --eval \"{2}\"", Host, Port, query),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				},
			};

			procQuery.Start();

			// read query output
			while (!procQuery.StandardOutput.EndOfStream)
			{
				output += procQuery.StandardOutput.ReadLine() + "\n";
			}

			// wait 2 seconds max before killing it
			if (!procQuery.WaitForExit(2000))
			{
				procQuery.Kill();
			}

			return output;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources
			}

			if (process != null && !process.HasExited)
			{
				process.Kill();
			}
		}
	}
}
