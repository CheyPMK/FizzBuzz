using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public class RuleEqualityComparer : IEqualityComparer<IRule>
    {
        public bool Equals(IRule existingRule, IRule newRule)
        {
            //For now we are only comparing types.
            return existingRule.GetType() == newRule.GetType();
        }

        public int GetHashCode(IRule obj)
        {
            return obj.GetHashCode();
        }
    }
}
