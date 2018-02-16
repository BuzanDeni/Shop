using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_add_product : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\an3\ProiectIS\App_Data\Database.mdf;Integrated Security=True");
    string a, b;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        //to make sure it the product was added
        if (IsPostBack) return;
        dd.Items.Clear();



        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        // la t3 si la t4 sunt integer (product price si product quantity)
        cmd.CommandText = "select * from category";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach(DataRow dr in dt.Rows)
        {
            dd.Items.Add(dr["product_category"].ToString());
        }
        con.Close();
    }

    protected void b1_Click(object sender, EventArgs e)
    {  
        //a este database din vs
        a = Class1.GetRandomPassword(10).ToString();
        /*am ales a pentru a putea incarca mai multe images care sa nu se overwrite si care sa aiba
        un nume diferit de la 1-10 si sa contina liteerele afabetului, pe care le gasim in class1.cs*/
        f1.SaveAs(Request.PhysicalApplicationPath + "./images/"+a+f1.FileName.ToString());
        //b este database normal, aici nu avem nevoie de physical path
        b = "images/" + a + f1.FileName.ToString();

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        // la t3 si la t4 sunt integer (product price si product quantity)
        cmd.CommandText = "insert into product values('" + t1.Text + "','" + t2.Text + "'," + t3.Text + "," + t4.Text + ",'" + b.ToString() + "','" + dd.SelectedItem.ToString() +"')";
        cmd.ExecuteNonQuery();
        con.Close();
    }
}