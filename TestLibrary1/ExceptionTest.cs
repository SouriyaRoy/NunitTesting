using Day1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary1
{
    [TestFixture]
    class ExceptionTest
    {
        [Test,Category("Customer_Exception")]
        public void GetCustomer_ValidId_RetCustType()
        {
            CustomerOrderService service = new CustomerOrderService();
            var res = service.GetCustomer(10);
            Assert.IsInstanceOf<Customer>(res);
        }
        [Test, Category("Customer_Exception")]
        public void GetCustomer_InvalidId_RetException()
        {
            CustomerOrderService service = new CustomerOrderService();
            //var res = service.GetCustomer(10);
            Assert.Throws<CustomerNotFoundException>(() => service.GetCustomer(50));
        }
    }
}
