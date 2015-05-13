using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public class FlowController : IFlowController
    {

        private readonly IRulesEngine _rulesEngine;
        private readonly IOutput _output;
        private readonly IDivisionRule _rule;

        public FlowController(IRulesEngine rulesEngine, IOutput output, 
            IDivisionRule rule)
        {
            _rulesEngine = rulesEngine;
            _output = output;
            _rule = rule;
        }


        //One unit for exception
        //checkIf run rules getting called
        //output.writeline getting called
        public void ExecuteRange(int minNumber, int maxNumber)
        {
            if (minNumber > maxNumber)
            {
                throw new ApplicationException("Please provide valid range");
            }

            for (int i = minNumber; i <= maxNumber; i++)
            {
                var generatedText = _rulesEngine.RunRules(i);
                _output.WriteLine(generatedText);
            }
        }

        //count check
        //check if rule expectation set
        //check if rule got added
        public void SetUpDivisonRules(IList<DivisonSpec> divisonSpecs)
        {

            if (divisonSpecs == null ||
                divisonSpecs.Count == 0)
            {
                return;
            }

               _rule.SetExpectation(divisonSpecs);
               _rulesEngine.AddRule(_rule);
          
        }
    }
}
