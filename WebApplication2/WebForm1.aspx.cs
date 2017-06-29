using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DatabaseDataContext db = new DatabaseDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            
            GridViewSales.DataSource = from sales in db.Salesmens
                                   select sales;
            GridViewSales.DataBind();

            GridViewOrders.DataSource = from order in db.Orders
                                   select order;
            GridViewOrders.DataBind();

            GridViewItems.DataSource = from item in db.Items
                                   select item;
            GridViewItems.DataBind();



            GridView3.DataSource = from orders in db.Orders
                                   join sales in db.Salesmens
                                   on new { orders.city, orders.code } equals new { sales.city, sales.code }
                                   select new { orders.order_id, orders.customer_name, orders.city,orders.code,sales.salesman_name};
            
            GridView3.DataBind();

            Button1.Click += new EventHandler(this.GreetingBtn_Click);
            AddSalesman.Click += new EventHandler(this.AddSalesman_Click);
            DeleteSalesman.Click += new EventHandler(this.DeleteSalesman_Click);
            UpdateSalesman.Click += new EventHandler(this.UpdateSalesman_Click);
        }

        void GreetingBtn_Click(Object sender, EventArgs e)
        {
        // When the button is clicked,
        // change the button text, and disable it.

            Button clickedButton = (Button)sender;
            clickedButton.Text = "...button clicked...";
            clickedButton.Enabled = false;

            GridView2.DataSource = from items in db.Items
                                   join orders in db.Orders on items.order_id equals orders.order_id
                                   select new { items.order_id, orders.customer_name, items.title };
            GridView2.DataBind();
            
        }

        void AddSalesman_Click(Object sender, EventArgs e)
        {
            Random r1 = new Random();
            
            Salesmen sm1 = new Salesmen();
            sm1.salesman_id = r1.Next();
            sm1.salesman_name = "Waqar";
            sm1.city = "Lahore";
            sm1.code = 042;

            db.Salesmens.InsertOnSubmit(sm1);
            db.SubmitChanges();

            Response.Redirect("WebForm1.aspx");
        }

        void DeleteSalesman_Click(Object sender, EventArgs e)
        {
            Salesmen sm1 = db.Salesmens.FirstOrDefault(x => x.salesman_name.Equals("Waqar"));
            db.Salesmens.DeleteOnSubmit(sm1);
            db.SubmitChanges();

            Response.Redirect("WebForm1.aspx");
        }


        void UpdateSalesman_Click(Object sender, EventArgs e)
        {
            Salesmen sm1 = db.Salesmens.FirstOrDefault(x => x.salesman_name.Equals("Waqar"));
            sm1.city = "Peshawar";

            db.SubmitChanges();

            Response.Redirect("WebForm1.aspx");
        }



    }
}