using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using static Reflection.Comparer;

namespace Reflection.Tests
{
    [TestFixture]
    public class ComparerTests
    {
        [TestCase(ExpectedResult = true)]
        public bool ReflectionComparer_Person_ExpectedResult_True()
        {
            Person first = new Person { Name = "Tony", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            Person second = new Person { Name = "Tony", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            return first.ReflectionComparer(second);
        }

        [TestCase(ExpectedResult = false)]
        public bool ReflectionComparer_Person_Different_Name_ExpectedResult_False()
        {
            Person first = new Person { Name = "Tony", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            Person second = new Person { Name = "Kate", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            return first.ReflectionComparer(second);
        }

        [TestCase(ExpectedResult = false)]
        public bool ReflectionComparer_Person_Different_Age_ExpectedResult_False()
        {
            Person first = new Person { Name = "Kate", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            Person second = new Person { Name = "Kate", Age = 20, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            return first.ReflectionComparer(second);
        }

        [TestCase(ExpectedResult = false)]
        public bool ReflectionComparer_Person_Different_Adress_Street_ExpectedResult_False()
        {
            Person first = new Person { Name = "Tony", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            Person second = new Person { Name = "Tony", Age = 23, Address = new Address { Street = "First Avenue", HouseNumber = 2 } };
            return first.ReflectionComparer(second);
        }

        [TestCase(ExpectedResult = false)]
        public bool ReflectionComparer_Person_Different_Adress_HouseNumber_ExpectedResult_False()
        {
            Person first = new Person { Name = "Tony", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 2 } };
            Person second = new Person { Name = "Tony", Age = 23, Address = new Address { Street = "Avenue", HouseNumber = 78 } };
            return first.ReflectionComparer(second);
        }
    }
}
