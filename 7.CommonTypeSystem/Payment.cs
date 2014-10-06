using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.CommonTypeSystem
{
    class Payment
    {
        //product name and price.
        private string name;
        private decimal price;

        //constructor
        public Payment(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        //props
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                try
                {
                    this.name = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Name must be string");
                }
            }
        }

        public decimal Price 
        {
            get
            {
                return this.price;
            }
            set
            {
                try
                {
                    this.price = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Price must be decimal number");
                }
            }
        }
    }
}
