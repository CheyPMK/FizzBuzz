using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public class DivisonRule : IDivisionRule
    {
        //Public getter for verifying the setexpectation call.
        public IList<DivisonSpec> DivisonSpecs { get; set; }

        public void SetExpectation(IList<DivisonSpec> divisonSpecs)
        {
            DivisonSpecs = new List<DivisonSpec>();

            if (divisonSpecs.Any(s => s.Denominator == 0 || string.IsNullOrWhiteSpace(s.OutputString)))
            {
                throw new RuleRequiredDataMissingException("Invalid divison spec data, denominator should be greater " +
                                               "than zero and output string cannot be null.");
            }

            foreach (var divisonSpec in divisonSpecs.Where(divisonSpec => divisonSpec.Denominator != 0))
            {
                DivisonSpecs.Add(divisonSpec);
            }
        }

        public string Execute(int examiningNumber)
        {
            string outputString = null;

            if (DivisonSpecs == null || DivisonSpecs.Count <= 0)
            {
                return null;
            }

            foreach (var spec in DivisonSpecs)
            {
                if (examiningNumber%spec.Denominator == 0)
                {
                    outputString = spec.OutputString;
                    break;
                }
            }
            return outputString;
        }
    }
}
