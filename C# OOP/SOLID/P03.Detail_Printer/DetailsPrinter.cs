using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                this.PrintEmployee(employee);
            }
        }

        private void PrintEmployee(IEmployee employee)
        {
            Console.WriteLine(employee.Name);
        }

        private void PrintManager(Manager manager)
        {
            Console.WriteLine(manager.Name);
            Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        }
    }
}
