using CommonCore.Interfaces.RuleTrees;
using CommonCore.Models.Enums;
using CommonCore.Repo.MongoDb;
using CommonCore2.RuleTrees;
using CommonCore2.RuleTrees.Comparison;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab
{

    public class Balls
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Balls> Children { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {

            Balls balls = new Balls()
            {
                Children = new List<Balls>()
                {
                    new Balls(){
                        Children = new List<Balls>(){ 
                            new Balls(){ }
                        }
                    }
                }
            };

            

            //IRuleTree ruleTree = new RuleTree()
            //{
            //    BaseNode = new OrRule()
            //    {
            //        Children = new List<RuleNode>()
            //        {
            //            new StringComparisonRule("Joe", "Joe"),
            //            new StringComparisonRule("Dog", "Dogs"),
            //            new GenericComparisonRule<decimal>(){
            //                OwnValue = 2m,
            //                ComparisonValue = 3m,
            //                Operator = ComparisonOperatorEnum.EqualTo
            //            }
            //        }
            //    }
            //};

            //string connectionString = "mongodb://localhost:27017/dac?readPreference=primary&appname=MongoDB%20Compass&ssl=false";

            //MongoDbCrudRepository<RuleTree> rulesRepo = new MongoDbCrudRepository<RuleTree>(connectionString);

            //await rulesRepo.Create(ruleTree);

            //var readResult = await rulesRepo.Read(x => true);


        }
    }
}
