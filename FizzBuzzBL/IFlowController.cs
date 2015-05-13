using System.Collections.Generic;

namespace FizzBuzzBL
{
    public interface IFlowController
    {
        void ExecuteRange(int minNumber, int maxNumber);

        void SetUpDivisonRules(IList<DivisonSpec> divisonSpecs);
    }
}