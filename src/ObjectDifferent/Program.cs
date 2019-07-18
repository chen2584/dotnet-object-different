using System;
using System.Collections.Generic;
using KellermanSoftware.CompareNetObjects;

namespace ObjectDifferent
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo1 = new Foo
            {
                Id = 1,
                Username = "Chen",
                Password = "SomePassword2",
                Age = 20,
                CreatedDate = new DateTime(1992, 07, 04),
                Bar = new Bar
                {
                    SomeField1 = "123",
                    SomeField2 = "456"
                },
                Bars = new List<Bar>
                {
                    new Bar
                    {
                        SomeField1 = "123",
                        SomeField2 = "456"
                    },
                    new Bar
                    {
                        SomeField1 = "456",
                        SomeField2 = "789"
                    }
                }
            };

            var foo2 = new Foo
            {
                Id = 2,
                Username = "Chen",
                Password = "SomePasswordzzz",
                CreatedDate = new DateTime(1992, 07, 05),
                Bar = new Bar
                {
                    SomeField1 = "12345",
                    SomeField2 = "45678"
                },
                Bars = new List<Bar>
                {
                    new Bar
                    {
                        SomeField1 = "555",
                        SomeField2 = "456"
                    },
                    new Bar
                    {
                        SomeField1 = "456",
                        SomeField2 = "789"
                    }
                }
            };

            var compareLogic = new CompareLogic(new ComparisonConfig
            {
                MaxDifferences = 99,
                CompareChildren = false
            });
            var result = compareLogic.Compare(foo1, foo2);
            foreach (var data in result.Differences)
            {
                Console.WriteLine($"{data.PropertyName} : {data.Object1Value}, {data.Object2Value} with type: {data.Object1TypeName}");
            }
        }
    }
}

// Id : 1, 2 with type: Int32
// Password : SomePassword2, SomePasswordzzz with type: String
// Age : 20, (null) with type: Int32
// CreatedDate : 04/07/1992 00:00:00, 05/07/1992 00:00:00 with type: DateTime