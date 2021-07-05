using System;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type @class = Type.GetType(className);

            FieldInfo[] fieldInfos = @class.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            object classInstance = Activator.CreateInstance(@class, new object[] { });

            StringBuilder sb = new StringBuilder($"Class under investigation: {@class.FullName}").AppendLine();

            foreach (var field in fieldInfos.Where(f=> fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
