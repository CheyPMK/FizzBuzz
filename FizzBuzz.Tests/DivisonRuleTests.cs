using System;
using System.Collections.Generic;
using FizzBuzzBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class DivisonRuleTests
    {
        [TestMethod]
        public void SetExpectation_should_set_the_divison_specs()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =1, OutputString = "Hurray"}
            };

            divisonRule.SetExpectation(divisonSpecs);

            Assert.AreEqual(1, divisonRule.DivisonSpecs.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleRequiredDataMissingException))]
        public void SetExpectation_should_throw_exception_if_denominator_is_zero_for_any_divison_specs()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =0, OutputString = "Hurray"}
            };

            divisonRule.SetExpectation(divisonSpecs);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleRequiredDataMissingException))]
        public void SetExpectation_should_throw_exception_if_output_string_is_null_for_any_divison_specs()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =1, OutputString = null}
            };

            divisonRule.SetExpectation(divisonSpecs);
        }

        [TestMethod]
        public void SetExpectation_should_set_the_divison_specs_with_out_altering_specs()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =1, OutputString = "Hurray"}
            };

            divisonRule.SetExpectation(divisonSpecs);

            Assert.AreEqual(1, divisonRule.DivisonSpecs[0].Denominator);
            Assert.AreEqual("Hurray", divisonRule.DivisonSpecs[0].OutputString, false);
        }

        [TestMethod]
        public void Execute_should_return_null_if_divison_specs_not_set()
        {
            var divisonRule = new DivisonRule();

            var actualOutput = divisonRule.Execute(15);

            Assert.IsNull(actualOutput);
        }

        [TestMethod]
        public void Execute_should_return_fizz_for_fifteem_if_divisonspec_with_three_added_first()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =3, OutputString = "Fizz"},
                new DivisonSpec{ Denominator =5, OutputString = "Buzz"},
                new DivisonSpec{Denominator =15, OutputString = "FizzBuzz"}
            };

            divisonRule.SetExpectation(divisonSpecs);

            var actualOutput = divisonRule.Execute(15);

            Assert.AreEqual("Fizz", actualOutput, false);
        }

        [TestMethod]
        public void Execute_should_return_buzz_for_fifteen_if_divisonspec_with_five_added_first()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =5, OutputString = "Buzz"},
                new DivisonSpec{ Denominator =3, OutputString = "Fizz"},
                new DivisonSpec{Denominator =15, OutputString = "FizzBuzz"}
            };

            divisonRule.SetExpectation(divisonSpecs);

            var actualOutput = divisonRule.Execute(15);

            Assert.AreEqual("Buzz", actualOutput, false);
        }

        [TestMethod]
        public void Execute_should_return_fizzbuzz_for_fifteen_if_divisonspec_with_fifteen_added_first()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =15, OutputString = "FizzBuzz"},
                new DivisonSpec{ Denominator =3, OutputString = "Fizz"},
                new DivisonSpec{Denominator =5, OutputString = "Buzz"}
            };

            divisonRule.SetExpectation(divisonSpecs);

            var actualOutput = divisonRule.Execute(15);

            Assert.AreEqual("FizzBuzz", actualOutput, false);
        }

        [TestMethod]
        public void Execute_should_return_null_if_int_minvalue_passed()
        {
            var divisonRule = new DivisonRule();

            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec{ Denominator =15, OutputString = "FizzBuzz"},
                new DivisonSpec{ Denominator =3, OutputString = "Fizz"},
                new DivisonSpec{Denominator =5, OutputString = "Buzz"}
            };

            divisonRule.SetExpectation(divisonSpecs);

            var actualOutput = divisonRule.Execute(int.MinValue);

            Assert.AreEqual(null, actualOutput, false);
        }
    }
}
