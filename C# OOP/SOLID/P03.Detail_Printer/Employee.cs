using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
