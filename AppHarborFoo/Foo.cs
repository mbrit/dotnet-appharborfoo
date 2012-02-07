using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AppHarborFoo
{
    public class Foo
    {
        public string DoMagic()
        {
            return string.Format("Welcome to AppHarbor! - {0}", DateTime.Now);
        }
    }
}
