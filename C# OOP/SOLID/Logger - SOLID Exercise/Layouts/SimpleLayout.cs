using System;
using System.Collections.Generic;
using System.Text;

namespace Log.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string pattern => "{0} - {1} - {2}";
    }
}
