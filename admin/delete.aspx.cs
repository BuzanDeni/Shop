using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class admin_delete : System.Web.UI.Page
{
    string category;
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\an3\ProiectIS\App_Data\Database.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        category = Request.QueryString["category"].ToString();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        // la t3 si la t4 sunt integer (product price si product quantity)
        cmd.CommandText = "delete from category where product_category='"+category.ToString()+"'";
        cmd.ExecuteNonQuery();


        SqlCommand cmd1 = con.CreateCommand();
        cmd1.CommandType = CommandType.Text;
        // la t3 si la t4 sunt integer (product price si product quantity)
        cmd1.CommandText = "delete from product where product_category='" + category.ToString() + "'";
        cmd1.ExecuteNonQuery();
        con.Close();
        Response.Redirect("add_category.aspx");

    }
}