using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class user_login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\an3\ProiectIS\App_Data\Database.mdf;Integrated Security=True");
    int tot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Buton_Login(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from registration where email='"+TextBox1.Text+"' and password='"+TextBox2.Text+"'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        tot = Convert.ToInt32(dt.Rows.Count.ToString());

        if (tot > 0)
        {
            if (Session["checkoutButton"] == "yes")
            {//user comes has pressed checkout button in cart.aspx
                Session["user"] = TextBox1.Text;
                Response.Redirect("update_order_details.aspx");
            }
            else
            {
                Session["user"] = TextBox1.Text;
                Response.Redirect("order_details.aspx");
            }
          
        }
        else
        {
            Label1.Text = "invalid usename or password";
        }
        con.Close();

    }
}