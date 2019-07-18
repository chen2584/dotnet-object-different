using System;
using System.Collections.Generic;

namespace ObjectDifferent
{
    public class Foo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Bar Bar { get; set; }
        public IList<Bar> Bars { get; set; }
    }
}