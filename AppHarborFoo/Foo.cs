using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppHarborFoo
{
    public class Foo
    {
        public string DoMagic()
        {
            return string.Format("Bar ... {0}", DateTime.Now);
        }
    }
}
