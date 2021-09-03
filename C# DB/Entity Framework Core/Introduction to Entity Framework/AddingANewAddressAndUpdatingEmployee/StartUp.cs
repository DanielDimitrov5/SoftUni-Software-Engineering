namespace AddingANewAddressAndUpdatingEmployee
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = AddNewAddressToEmployee(context);

            Console.WriteLine(result);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee Nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            Nakov.Address = newAddress;

            newAddress.Employees.Add(Nakov);

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new { x.Address.AddressText, x.AddressId })
                .OrderByDescending(x => x.AddressId)
                .Take(10);

            foreach (var employee in employees)
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
