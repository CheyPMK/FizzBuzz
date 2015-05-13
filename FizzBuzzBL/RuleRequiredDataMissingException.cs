using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public class RuleRequiredDataMissingException : Exception
    {
        public RuleRequiredDataMissingException()
        {
        }

        public RuleRequiredDataMissingException(string message)
            : base(message)
        {
        }

        public RuleRequiredDataMissingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RuleRequiredDataMissingException(string format, params object[] args)
            : base(string.Format(format, args))
        {

        }

        public RuleRequiredDataMissingException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {

        }
    }
}
