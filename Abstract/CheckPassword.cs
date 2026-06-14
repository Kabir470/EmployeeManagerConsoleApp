using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Abstract
{
    public class CheckPassword
    {
        
        private const string? password= "password";

        public bool Check(string? input)
        {
            return string.Equals(input, password, StringComparison.Ordinal);
        }
    }
}
