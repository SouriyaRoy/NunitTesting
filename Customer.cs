using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public enum CustomerType
    {
        Basic,
        Premium,
        SpecialCustomer
    }

    public class Parent
    {

    }

    public class Child :Parent
    {

    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public CustomerType Type { get; set; }

        public Customer(int id, string fname, string lname, CustomerType type)
        {
            this.CustomerId = id;
            this.FName = fname;
            this.LName = lname;
            this.Type = type;
        }

        public override bool Equals(object obj)
        {
            Customer cust = obj as Customer;

            if (this.FName == cust.FName)
                return true;
            else
                return false;
        }

    }
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public double Amount { get; set; }

        public Order(int id, int prdid, int prdqty, double amount)
        {
            this.OrderId = id;
            this.ProductId = prdid;
            this.ProductQuantity = prdqty;
            this.Amount = amount;
        }



    }
    public class CustomerOrderService
    {
        public object getData(int id)
        {
            if (id == 100)
            {
                return "Some Data";
            }
            else if (id == 200)
            {
                return 1900;
            }
            else
                return new Customer(10, "Souriya", "Roy", CustomerType.Basic);
        }

        public int ProductStock { get; set; }


        public void UpdateStock(int amount)
        {
            if (amount != 0)
                ProductStock = ProductStock + amount;
            else
                throw new ArgumentNullException();
        }




        public string GetCustomerFullName(Customer cust)
        {
            return cust.FName + " " + cust.LName;
        }
        //30

        public Customer GetCustomer(int id)
        {
            Customer cust = GetList().Find(x => x.CustomerId == id);
            if (cust != null)
                return cust;
            else
                //throw null;
                throw new CustomerNotFoundException();
        }

        public int GetCustomer1(int id)
        {
            return 10;
        }


        public ObservableCollection<Customer> GetCustomerList()
        {
            ObservableCollection<Customer> custs = new ObservableCollection<Customer>();
            custs.Add(new Customer(10, "Sachin", "T", CustomerType.Basic));
            custs.Add(new Customer(20, "Rahul", "D", CustomerType.Basic));
            return custs;
        }



        public List<Customer> GetList()
        {
            List<Customer> custs = new List<Customer>();
            custs.Add(new Customer(10, "Sachin", "T", CustomerType.Basic));
            custs.Add(new Customer(20, "Rahul", "D", CustomerType.Basic));
            return custs;
        }
        public string GetCouponCode(Customer cust,Order order)
        {
            if(cust.Type== CustomerType.Basic && order.Amount <=1000)
            {
                return "BasicA" + GetRandomNumber();
            }

            //else if (cust.Type == CustomerType.Basic && order.Amount <= 2000)
            //{
            //    return "BasicB" + GetRandomNumber();
            //}

            else if (cust.Type == CustomerType.Premium && order.Amount <= 1000)
            {
                return "PremiumA" + GetRandomNumber();
                //return false;
            }

            //else if (cust.Type == CustomerType.Premium && order.Amount <= 2000)
            //{
            //    return "PremiumB" + GetRandomNumber();
            //}

            return "";
        }

        public int GetRandomNumber()
        {
            Random rnd = new Random();
            int number=rnd.Next(1, 100);
            return number;
        }
        public bool IsApplicableToDiscount(Customer cust)
        {
            if (cust.Type == CustomerType.Basic)
            {
                return false;
            }

            //else if(cust.Type == CustomerType.Premium)
            //{
            // return cust;
            //}
            else
                return true;
        }
        public double GetDiscount(Customer cust, Order order)
        {
            double discountAmount = 0;
            double actualAmount = 0;
            if (cust.Type == CustomerType.Basic)
            {
                discountAmount = order.Amount * 10 / 100;
                actualAmount = order.Amount - discountAmount;
            }
            else if (cust.Type == CustomerType.Premium)
            {
                discountAmount = order.Amount * 30 / 100;
                actualAmount = order.Amount - discountAmount;
            }
            else
            {
                discountAmount = order.Amount * 50 / 100;
                actualAmount = order.Amount - discountAmount;
            }
            return actualAmount;
        }
    }
}
