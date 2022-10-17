using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.LogViewer.WordsSearch
{
    public class CharPosition
    {
     
        public int Position { get; set; }
        public char Char { get; set; }

        public CharPosition()
        {
            
        }
        public CharPosition(char c, int p)
        {
            Position = p;
            Char = c;
        }
        public override string ToString()
        {
            return $"[{Position+1}]:{Char}";
        }
    }
}
