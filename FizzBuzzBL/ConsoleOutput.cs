using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
