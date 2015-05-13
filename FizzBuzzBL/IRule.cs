using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    public interface IRule
    {
        string Execute(int examiningNumber);
    }
}
