using Microsoft.EntityFrameworkCore;

namespace SoftUni
{
    using System;
    using System.Linq;
    using SoftUni.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = RemoveTown(context);

            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context
                .Towns
                .FirstOrDefault(x => x.Name == "Seattle");

            var addresses = context
                .Addresses
                .Include(x => x.Employees)
                .Where(x => x.Town == town)
                .ToList();

            foreach (var address in addresses)
            {
                foreach (var employee in address.Employees.Where(x => x.AddressId == address.AddressId))
                {
                    employee.AddressId = null;
                }

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}