using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.CommonTypeSystem
{
    class Customer : ICloneable, IComparable<Customer>
    {
        // and customer type. 
        //fields
        private string name;
        private string middleName;
        private string lastName;
        private string id;
        private string address;
        private string mobilePhone;
        private string email;
        private List<Payment> payments;
        private CustomerType type;

        //constructor
        public Customer(string name, string middleName, string lastName, string id, string address,
                        string mobilePhone, string email, List<Payment> payments, CustomerType type)
        {
            this.Name = name;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.Type = type;
        }

        object ICloneable.Clone()  // Implicit implementation
        {
            return this.Clone();
        }

        //properties
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
        
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                try
                {
                    this.middleName = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Middle Name must be string");
                }
            }
        }
        
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                try
                {
                    this.lastName = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Last Name must be string");
                }
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                try
                {
                    this.id = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("ID must be string of numbers");
                }
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                try
                {
                    this.address = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Address must be string");
                }
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                try
                {
                    this.mobilePhone = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Mobilephone must be string of digits");
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                try
                {
                    this.email = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("ID must be string of numbers");
                }
            }
        }

        public List<Payment> Payments
        {
            get
            {
                return this.payments;
            }
            set
            {
                try
                {
                    this.payments = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Payment must be list of payments");
                }
            }
        }

        public CustomerType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                try
                {
                    this.type = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Customer type must be enum");
                }
            }
        }

        //methods
        public override bool Equals(object param)
        {
            // If the cast is invalid, the result will be null
            Customer customer = param as Customer;

            if (customer == null)
            {
                return false;
            }

            // Compare the reference type member fields
            List<Object> props = new List<Object> { this.Name, this.MiddleName, this.LastName, this.ID, this.Address, 
                                                    this.MobilePhone, this.Email, this.Payments, this.Type };
            List<Object> cProps = new List<Object> { customer.Name, customer.MiddleName, customer.LastName, customer.ID, customer.Address, 
                                                     customer.MobilePhone, customer.Email, customer.Payments, customer.Type };
            for (int i = 0; i < props.Count; i++ )
            {
                if (!Object.Equals(props[i], cProps[i]))
                {
                    return false;
                }
            }

            // Compare the value type member fields
            //if (this.Age != student.Age)
            //{
            //    return false;
            //}

            return true;
        }

        public Customer Clone() // our method Clone()
        {
            // Copy the first element
            Customer original = this;
            var originalName = original.name;
            var originalMiddleName = original.middleName;
            var originalLastName = original.lastName;
            var originalID = original.id;
            var originalAddress = original.address;
            var originalMobilPhone = original.mobilePhone;
            var originalEmail = original.email;
            var originalPayments = original.payments;
            var originalType = original.type;
            Customer result = new Customer(originalName, originalMiddleName, originalLastName,  originalID,
                                           originalAddress, originalMobilPhone, originalEmail, originalPayments, originalType);
            return result;
        }



        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^   this.LastName.GetHashCode() ^ 
                   this.ID.GetHashCode() ^  this.Address.GetHashCode() ^ this.MobilePhone.GetHashCode() ^
                   this.Email.GetHashCode() ^ this.Payments.GetHashCode() ^ this.Type.GetHashCode();
        }

        public int CompareTo(Customer customer)
        {
            if (!Object.Equals(this.Name, customer.Name))
            {
                return this.Name.CompareTo(customer.Name);
            }
            if (!Object.Equals(this.MiddleName, customer.MiddleName))
            {
                return this.MiddleName.CompareTo(customer.MiddleName);
            }
            if (!Object.Equals(this.LastName, customer.LastName))
            {
                return this.LastName.CompareTo(customer.LastName);
            }
            if (!Object.Equals(this.ID, customer.ID))
            {
                return customer.ID.CompareTo(this.ID);
            }
            return 0;
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return Object.Equals(c1, c2);
        }
        public static bool operator !=(Customer c1, Customer c2)
        {
            return !Object.Equals(c1, c2);
        }
    }
}
