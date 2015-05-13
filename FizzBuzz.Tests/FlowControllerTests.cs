using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzBL;
using Moq;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FlowControllerTests
    {
        
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void ExecuteRange_should_throw_exception_if_minNumber_greater_maxNumber()
        {
            var mockRuleEngine = new Mock<IRulesEngine>();
            var mockOutPut = new Mock<IOutput>();
            var mockRule = new Mock<IDivisionRule>();

            var flowController = new FlowController(mockRuleEngine.Object, mockOutPut.Object, mockRule.Object);

            flowController.ExecuteRange(5, 1);
        }

        [TestMethod]
        public void ExecuteRange_should_call_rules_engine_with_valid_range()
        {
            var mockRuleEngine = new Mock<IRulesEngine>();
            var mockOutPut = new Mock<IOutput>();
            var mockRule = new Mock<IDivisionRule>();

            mockRuleEngine.Setup(x => x.RunRules(It.IsAny<int>())).Returns("Test");
            mockOutPut.Setup(x => x.WriteLine(It.IsAny<string>()));

            var flowController = new FlowController(mockRuleEngine.Object, mockOutPut.Object, mockRule.Object);

            flowController.ExecuteRange(1, 4);
            mockRuleEngine.Verify(x=>x.RunRules(It.IsAny<int>()));
        }


        [TestMethod]
        public void ExecuteRange_should_call_rules_engine_maxnumber_minus_minnumber_times()
        {
            var mockRuleEngine = new Mock<IRulesEngine>();
            var mockOutPut = new Mock<IOutput>();
            var mockRule = new Mock<IDivisionRule>();

            mockRuleEngine.Setup(x => x.RunRules(It.IsAny<int>())).Returns("Test");
            mockOutPut.Setup(x => x.WriteLine(It.IsAny<string>()));

            var flowController = new FlowController(mockRuleEngine.Object, mockOutPut.Object, mockRule.Object);

            flowController.ExecuteRange(1, 4);
            mockRuleEngine.Verify(x => x.RunRules(It.IsAny<int>()), Times.Exactly(4));
        }


        [TestMethod]
        public void ExecuteRange_should_call_output_for_writing_it_out_as_many_times_as_range()
        {
            var mockRuleEngine = new Mock<IRulesEngine>();
            var mockOutPut = new Mock<IOutput>();
            var mockRule = new Mock<IDivisionRule>();

            mockRuleEngine.Setup(x => x.RunRules(It.IsAny<int>())).Returns("Test");
            mockOutPut.Setup(x => x.WriteLine(It.IsAny<string>()));

            var flowController = new FlowController(mockRuleEngine.Object, mockOutPut.Object, mockRule.Object);

            flowController.ExecuteRange(1, 4);
            mockOutPut.Verify(x=>x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }



        [TestMethod]
        public void SetUpDivisonRules_should_not_call_rules_engine_if_divisonspecslist_is_null()
        {

            var mockRuleEngine = new Mock<IRulesEngine>();
            var mockOutPut = new Mock<IOutput>();
            var mockRule = new Mock<IDivisionRule>();

            var flowController = new FlowController(mockRuleEngine.Object, mockOutPut.Object, mockRule.Object);

            mockRuleEngine.Setup(x => x.AddRule(It.IsAny<IRule>()));
            mockRule.Setup(x => x.SetExpectation(It.IsAny<IList<DivisonSpec>>()));

            flowController.SetUpDivisonRules(null);

            mockRuleEngine.Verify(x=>x.AddRule(It.IsAny<IRule>()), Times.Never());
           mockRule.Verify(x=>x.SetExpectation(It.IsAny<IList<DivisonSpec>>()), Times.Never());
        }


        [TestMethod]
        public void SetUpDivisonRules_should_call_rules_engine_if_divisonspecslist_is_not_null()
        {

            var mockRuleEngine = new Mock<IRulesEngine>();
            var mockOutPut = new Mock<IOutput>();
            var mockRule = new Mock<IDivisionRule>();

            var flowController = new FlowController(mockRuleEngine.Object, mockOutPut.Object, mockRule.Object);

            mockRuleEngine.Setup(x => x.AddRule(It.IsAny<IRule>()));
            mockRule.Setup(x => x.SetExpectation(It.IsAny<IList<DivisonSpec>>()));

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator = 1, OutputString = "Test"} 
            };

            flowController.SetUpDivisonRules(divisonSpecs);

            mockRuleEngine.Verify(x => x.AddRule(It.IsAny<IRule>()), Times.Once());
            mockRule.Verify(x => x.SetExpectation(It.IsAny<IList<DivisonSpec>>()), Times.Once());
        }

    }
}
