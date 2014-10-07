using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.String_Disperser
{
    class StringDisperser: ICloneable, IComparable, IEnumerable
    {
        private string[] strings;
        public string chars = "";

        public StringDisperser(params string[] strings)
        {
            this.strings = strings;
            foreach (var word in strings)
	        {
                chars += word;
	        }
        }

        public override string ToString()
        {
            return this.chars;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == ((StringDisperser)obj).ToString();
        }

        public static bool operator ==(StringDisperser s1, StringDisperser s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(StringDisperser s1, StringDisperser s2)
        {
            return !s1.Equals(s2);
        }

        public char this[int index]
        {
            get { return this.chars.ElementAt(index); }
            set { this.chars = this.chars.Substring(0, value) + value + this.chars.Substring(value + 1); }
        }

        public override int GetHashCode()
        {
            var result = this.strings[0].GetHashCode();
            for (int index = 1; index < this.strings.Length; index++)
            {
                result ^= this.strings[index].GetHashCode();
            }
            return result;
        }

        public StringDisperser Clone()
        {
            string[] listCopy = new string[this.strings.Length];
            int index = 0;
            foreach (var word in this.strings)
            {
                listCopy.SetValue(word, index);
                index++;
            }
            return new StringDisperser((string[])listCopy);
        }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}
