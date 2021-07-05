using System;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public FieldInfo[] StealFieldInfo(string className)
        {
            Type @class = Type.GetType(className);

            FieldInfo[] fieldInfos = @class.GetFields(
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static);

            return fieldInfos;
        }

        public MethodInfo[] StealMethodInfo(string className)
        {
            Type @class = Type.GetType(className);

            MethodInfo[] methods = @class.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            return methods;
        }

        public string AnalyzeAccessModifiers(string className)
        {
            FieldInfo[] fields = StealFieldInfo("Stealer." + className);

            MethodInfo[] privateGettters = StealMethodInfo("Stealer." + className).Where(x => !x.IsPublic && x.Name.StartsWith("get")).ToArray();
            MethodInfo[] publicStters = StealMethodInfo("Stealer." + className).Where(x => !x.IsPrivate && x.Name.StartsWith("set")).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in privateGettters)
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in publicStters)
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
