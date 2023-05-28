using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyser.Code
{
    public class Token
    {
        public string Name { get; private set; }
        public string Data { get; private set; }

        public Token(string name, string data)
        {
            Name = name;
            Data = data;
        }
    }
}
