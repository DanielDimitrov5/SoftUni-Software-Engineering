using System;
using System.Collections.Generic;
using System.Text;

namespace Log.Layouts
{
    public interface ILayout
    {
        public string pattern { get; }
    }
}
