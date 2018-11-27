using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moby_Dick
{
    public class ClearString
    {
        public string Method(string input)// For replace new line characters with space
        {
            input = input.Replace("\r", string.Empty);
            input = input.Replace("\n", string.Empty);
            input = input.Replace("\r\n", string.Empty);

            return input;
        }
    }
}
