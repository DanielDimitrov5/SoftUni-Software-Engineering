namespace AddressesByTown
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = GetAddressesByTown(context);

            Console.WriteLine(result);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(x => new { x.AddressText, x.Town.Name, x.Employees.Count })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine(
                    $"{address.AddressText}, {address.Name} - {address.Count} employees");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
