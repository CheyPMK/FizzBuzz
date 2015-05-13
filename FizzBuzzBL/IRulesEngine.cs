using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public interface IRulesEngine
    {
        /// <summary>
        /// Add the rules to existing rules collection,
        /// Assumption: For now we dont accept to have rules with duplicate type
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        bool AddRule(IRule rule);

        /// <summary>
        /// Will execute the rules in the order of specs that got added
        /// </summary>
        /// <param name="valueToCheck"></param>
        /// <returns></returns>
        string RunRules(int valueToCheck);
    }
}
