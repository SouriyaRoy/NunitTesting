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
    public class Tests1
    {
        [Test]
        public void IsApplicableToDiscount_RetFalse()
        {
            //Arrange : DO the arrangement for calling unit under Test

            Customer cust = new Customer(10, "Sachin", "T", CustomerType.Basic);

            CustomerOrderService service = new CustomerOrderService();
            //Act

            //Call method under Test

            var Result = service.IsApplicableToDiscount(cust);

            //Assert: Check Actual output with excpected output

            Assert.IsFalse(Result);

            // Assert.AreEqual(false, Result);
        }

        [Test]
        public void IsApplicableToDiscount_RetTrue()
        {
            //Arrange : DO the arrangement for calling unit under Test

            Customer cust1 = new Customer(10, "Sachin", "T", CustomerType.Premium);

            CustomerOrderService service = new CustomerOrderService();
            //Act

            //Call method under Test

            var Result = service.IsApplicableToDiscount(cust1);

            //Assert: Check Actual output with excpected output

            Assert.IsTrue(Result);

            // Assert.AreEqual(false, Result);
        }

        [Test]
        public void GetDiscount_CustomerBasic_RetTenPerCentDiscount()
        {
            //Arrange
            Customer cust = new Customer(10, "Sachin", "T", CustomerType.Basic);
            Order order = new Order(10, 10, 10, 1000);
            CustomerOrderService service = new CustomerOrderService();

            //Act
            var result = service.GetDiscount(cust, order);

            //Assert
            Assert.AreEqual(900, result);
            //Assert.LessOrEqual(900, result);
            //Assert.GreaterOrEqual(900, result);
        }

        [Test]
        public void GetDiscount_CustomerPremium_RetThirtyPerCentDiscount()
        {
            //Arrange
            Customer cust = new Customer(10, "Sachin", "T", CustomerType.Premium);
            Order order = new Order(10, 10, 10, 1000);
            CustomerOrderService service = new CustomerOrderService();

            //Act
            var result = service.GetDiscount(cust, order);

            //Assert
            Assert.AreEqual(700, result);
        }

        [Test]
        public void GetDiscount_CustomerNormal_RetFiftyPerCentDiscount()
        {
            //Arrange
            Customer cust = new Customer(10, "Sachin", "T", CustomerType.SpecialCustomer);
            Order order = new Order(10, 10, 10, 1000);
            CustomerOrderService service = new CustomerOrderService();

            //Act
            var result = service.GetDiscount(cust, order);

            //Assert
            Assert.AreEqual(500, result);
        }

        [Test]
        public void GetCoupon()
        {
            //Arrange
            Customer cust = new Customer(10, "Sachin", "T", CustomerType.Basic);
            Order order = new Order(10, 10, 10, 1000);
            CustomerOrderService service = new CustomerOrderService();

            //Act
            var res = service.GetCouponCode(cust, order);

            //Assert
            StringAssert.StartsWith("BasicA", res);
            //StringAssert.Contains("BasicA", res);
            //StringAssert.IsMatch("BasicA*.*", res);
            //StringAssert.AreEqualIgnoringCase("nunit", "Nunit");
        }
    }

    [TestFixture]
    public class Tests2
    {
        [Test]
        public void GetData_100_RetStringData()
        {
            CustomerOrderService service = new CustomerOrderService();
            var res = service.getData(100);
            Assert.IsInstanceOf<string>(res);
        }
        [Test]
        public void GetData_200_RetIntegerData()
        {
            CustomerOrderService service = new CustomerOrderService();
            var res = service.getData(200);
            Assert.AreEqual(1900, res);
        }
        [Test]
        public void GetData_Object()
        {
            CustomerOrderService service = new CustomerOrderService();
            var res = service.getData(1000);
            Assert.IsInstanceOf<Customer>(res);
        }
    }
}
