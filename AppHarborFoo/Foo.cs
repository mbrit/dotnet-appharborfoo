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
            return string.Format("Bar - {0} - {1}", DateTime.Now, ConfigurationManager.AppSettings["SQLSERVER_URI"]);
        }
    }
}
