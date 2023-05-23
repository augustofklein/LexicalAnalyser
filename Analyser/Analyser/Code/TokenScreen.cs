using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyser.Code
{
    public class TokenScreen
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public TokenScreen(int line, int column, string name, string data)
        {
            Line = line;
            Column = column;
            Name = name;
            Data = data;
        }
    }
}
