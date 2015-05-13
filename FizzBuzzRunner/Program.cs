using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using FizzBuzzBL;

namespace FizzBuzzRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            InitIoC();

            Console.WriteLine("StructureMap Initialized.");

#pragma warning disable 618
            var flowController = ObjectFactory.GetInstance<IFlowController>();
#pragma warning restore 618


            var divisonSpecs = new List<DivisonSpec>
            {
                new DivisonSpec {Denominator = 15, OutputString = "FizzBuzz"},
                new DivisonSpec {Denominator = 3, OutputString = "Fizz"},
                new DivisonSpec {Denominator = 5, OutputString = "Buzz"}
            };

            flowController.SetUpDivisonRules(divisonSpecs);
            flowController.ExecuteRange(1,100);

            Console.WriteLine("ExecutionDone!!!!!!!!!");
            Console.ReadLine();

        }

        private static void InitIoC()
        {
#pragma warning disable 618
            ObjectFactory.Configure(config =>
#pragma warning restore 618
            {

                config.For<IDivisionRule>().Use<DivisonRule>();
                config.For<IOutput>().Use<ConsoleOutput>();
                config.For<IFlowController>().Use<FlowController>();
                config.For<IRulesEngine>().Use<RulesEngine>();

            });
        }

    }
}
