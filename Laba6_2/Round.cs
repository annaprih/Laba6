using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6_2
{
    class Round : IComparable<Round>
    {
        public int Rad { get; set; }

        public Round()
        {
            this.Rad = 0;
        }

        public Round(int rad)
        {
            this.Rad = rad;
        }

        public bool WriteToFile(string nameOfFile)
        {
            using (StreamWriter log = new StreamWriter(nameOfFile))
            {
                log.WriteLine(this.ToString());
            }
            return true;
        }

        public override int GetHashCode()
        {
            return ((int)Math.Pow(this.Rad, 3) * 5 << 3) * 100;
        }

        public override bool Equals(object obj)
        {
            if ((obj != null) && (obj is Round))
            {
                Round temp = obj as Round;
                if (temp.Rad == this.Rad)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"Радиус круга = {this.Rad}";
        }

        public int CompareTo(Round other)
        {
            if (this.Rad == other.Rad)
            {
                return 0;
            }
            else if (this.Rad > other.Rad)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
