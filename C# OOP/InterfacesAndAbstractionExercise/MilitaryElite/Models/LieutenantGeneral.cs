using System.Collections.Generic;
using System.Text;

using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<IPrivate> Privates { get; private set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<IPrivate>();
        }

        public void AddPrivate(IPrivate @private)
        {
            Privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
              .AppendLine("Privates:");

            foreach (var @private in Privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().Trim();
        }
    }
}
