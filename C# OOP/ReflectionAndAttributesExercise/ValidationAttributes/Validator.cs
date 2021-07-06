using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes(true)
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attrubute in attributes)
                {
                    if (attrubute.IsValid(property.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
