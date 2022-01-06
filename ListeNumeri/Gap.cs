using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeNumeri
{
    public class Gap
    {
        public int Start { get; set; }
        public int Jump { get; set; }

        public override string ToString() =>
            (Jump == 1) ? $"Gruppo: {Start}" : $"Gruppo: {Start}-{Start + Jump - 1}";

    }
}
