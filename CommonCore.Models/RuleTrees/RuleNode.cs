using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.RuleTrees
{
    public abstract class RuleNode
    {
        public Guid ID { get; set; }
        public Guid ParentID { get; set; }
        private List<RuleNode> _children = new List<RuleNode>();
        public List<RuleNode> Children
        {
            get
            {
                return _children;
            }
            set
            {
                foreach (var child in value)
                {
                    child.ParentID = ID;
                    _children.Add(child);
                }
            }
        }
        public abstract Task<bool> Passes();

        protected RuleNode() { }

        protected RuleNode(params RuleNode[] rules)
        {
            Children = rules.ToList();
        }
    }
}
