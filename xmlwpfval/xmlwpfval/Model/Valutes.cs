using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlwpfval.Model
{
    public class Valutes
    {
        public string Codee { get; set; }
        public string Namee { get; set; }
        public int Nominall { get; set; }
        public string CharCodee { get; set; }
        public double Valuee { get; set; }

        public override string ToString()
        {
            return $"{Nominall} {Namee}";
        }
    }
}
