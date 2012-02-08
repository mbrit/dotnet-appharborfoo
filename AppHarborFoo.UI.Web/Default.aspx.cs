using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppHarborFoo.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // sub...
            this.buttonCreateCustomer.Click += new EventHandler(buttonCreateCustomer_Click);
        }

        void buttonCreateCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = Customer.CreateCustomer("foo", "bar", "foo+" + new Random().Next() + "@mbrit.com");
            this.buttonCreateCustomer.Text = string.Format("Created customer #{0}: {1}", customer.CustomerId, customer.Email);
        }

        public string Foobar
        {
            get
            {
                return new Foo().DoMagic();
            }
        }
    }
}