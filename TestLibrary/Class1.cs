using System;
using NUnit.Framework;

namespace TestLibrary
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void IsApplicableToDiscount_CustomerBasic_ReturnFalse()
        {
            Customer cust = new Customer(10, "Sachin", "T", CustomerType.Basic);
        }
    }
}
