using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public class RulesEngine : IRulesEngine
    {
        private ConcurrentBag<IRule> _rules = new ConcurrentBag<IRule>();
        private RuleEqualityComparer _ruleEqualityComparer = new RuleEqualityComparer();

        public bool AddRule(IRule rule)
        {
            if (rule == null)
            {
                return false;
            }

            if (!_rules.Contains(rule, _ruleEqualityComparer))
            {
                _rules.Add(rule);
                return true;
            }
            return false;
        }

  
        public string RunRules(int valueToCheck)
        {
           foreach (var ruleTobeExecuted in _rules)
            {
                var generatedText = ruleTobeExecuted.Execute(valueToCheck);
                 if (!string.IsNullOrWhiteSpace(generatedText))
                 {
                     return generatedText;
                 }
            }

            return Convert.ToString(valueToCheck);

        }

    }
}
