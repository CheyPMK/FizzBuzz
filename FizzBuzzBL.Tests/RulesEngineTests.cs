using Rhino.Mocks;
using Xunit;

namespace FizzBuzzBL.Tests
{
    public class RulesEngineTests
    {
        [Fact]
        public void AddRule_should_return_false_if_rule_is_passed_null()
        {

            var rulesEngine = new RulesEngine();
            var ruleAdded = rulesEngine.AddRule(null);

            Assert.False(ruleAdded);
        }

        [Fact]
        public void AddRule_should_return_true_if_rule_got_added()
        {
            var rulesEngine = new RulesEngine();
            var ruleAdded = rulesEngine.AddRule(new DivisonRule());

            Assert.True(ruleAdded);
        }

        [Fact]
        public void AddRule_should_return_false_if_duplicate_rule_being_added()
        {
            var rulesEngine = new RulesEngine();
            var divisonRule = MockRepository.GenerateMock<IDivisionRule>();
            rulesEngine.AddRule(divisonRule);
            var  ruleAdded = rulesEngine.AddRule(divisonRule);

            Assert.False(ruleAdded);
        }

        [Fact]
        public void RunRules_should_call_exceute_method_on_particular_rule()
        {
            var rulesEngine = new RulesEngine();
            var divisonRule = MockRepository.GenerateMock<IDivisionRule>();
            divisonRule.Stub(x => x.Execute(1)).Return("Test");
            rulesEngine.AddRule(divisonRule);

            rulesEngine.RunRules(1);

            divisonRule.AssertWasCalled(x=>x.Execute(1), x=>x.Repeat.Once());
        }

        [Fact]
        public void RunRules_should_return_exact_string_retured_by_particular_rule()
        {
            var rulesEngine = new RulesEngine();
            var divisonRule = MockRepository.GenerateMock<IDivisionRule>();
            divisonRule.Stub(x => x.Execute(1)).Return("Test");
            rulesEngine.AddRule(divisonRule);

            var returnedString = rulesEngine.RunRules(1);

           Assert.Equal("Test", returnedString);
        }

        [Fact]
        public void RunRules_should_return_input_string_when_null_retured_by_particular_rule()
        {
            var divisonRule = MockRepository.GenerateMock<IDivisionRule>();
            var rulesEngine = new RulesEngine();
            divisonRule.Stub(x => x.Execute(1)).Return(null);
            rulesEngine.AddRule(divisonRule);

            var returnedString = rulesEngine.RunRules(1);

            Assert.Equal("1", returnedString);
        }

        [Fact]
        public void RunRules_Should_Return_input_string_when_no_rules_were_added()
        {
            var rulesEngine = new RulesEngine();
            var returnedString = rulesEngine.RunRules(1);

            Assert.Equal("1", returnedString);
        }

    }
}
