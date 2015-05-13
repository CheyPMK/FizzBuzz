using System;
using FizzBuzzBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class RulesEngineTests
    {
        [TestMethod]
        public void AddRule_should_return_false_if_rule_is_passed_null()
        {

            var rulesEngine = new RulesEngine();
            var ruleAdded = rulesEngine.AddRule(null);

            Assert.IsFalse(ruleAdded);
        }

        [TestMethod]
        public void AddRule_should_return_true_if_rule_got_added()
        {
            var rulesEngine = new RulesEngine();
            var ruleAdded = rulesEngine.AddRule(new DivisonRule());

            Assert.IsTrue(ruleAdded);
        }

        [TestMethod]
        public void AddRule_should_return_false_if_duplicate_rule_being_added()
        {
            var rulesEngine = new RulesEngine();
            var divisonRule = new DivisonRule();
            rulesEngine.AddRule(divisonRule);
            var ruleAdded = rulesEngine.AddRule(divisonRule);

            Assert.IsFalse(ruleAdded);
        }

        [TestMethod]
        public void RunRules_should_call_exceute_method_on_particular_rule()
        {
            var rulesEngine = new RulesEngine();
            var mockdivisonRule = new Mock<IDivisionRule>();
            mockdivisonRule.Setup(x => x.Execute(1)).Returns("Test");
            rulesEngine.AddRule(mockdivisonRule.Object);

            rulesEngine.RunRules(1);

            mockdivisonRule.Verify(x=>x.Execute(1), Times.Once());
        }

        [TestMethod]
        public void RunRules_should_return_exact_string_retured_by_particular_rule()
        {
            var rulesEngine = new RulesEngine();
            var mockdivisonRule = new Mock<IDivisionRule>();
            mockdivisonRule.Setup(x => x.Execute(1)).Returns("Test");
            rulesEngine.AddRule(mockdivisonRule.Object);

            var returnedString = rulesEngine.RunRules(1);

            Assert.AreEqual("Test", returnedString);
        }

        [TestMethod]
        public void RunRules_should_return_input_string_when_null_retured_by_particular_rule()
        {
            var rulesEngine = new RulesEngine();
            var mockdivisonRule = new Mock<IDivisionRule>();
            mockdivisonRule.Setup(x => x.Execute(1)).Returns(() => null);
            rulesEngine.AddRule(mockdivisonRule.Object);

            var returnedString = rulesEngine.RunRules(1);

            Assert.AreEqual("1", returnedString);
        }

        [TestMethod]
        public void RunRules_Should_Return_input_string_when_no_rules_were_added()
        {
            var rulesEngine = new RulesEngine();
            var returnedString = rulesEngine.RunRules(1);

            Assert.AreEqual("1", returnedString);
        }
    }
}
