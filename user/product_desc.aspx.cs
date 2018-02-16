using System;
using System.Data;
using System.Data.SqlClient;

public partial class user_product_desc : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\an3\ProiectIS\App_Data\Database.mdf;Integrated Security=True");
    private int id;
    int qty;//quantity
    private string product_name, product_descr, product_price, product_qty, product_images;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("display_item.aspx");
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product where id=" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();
            con.Close();


        }
        //daca cantitatea e 0 se va afisa doar un mesaj
        qty = get_qty(id);
        if(qty==0)
        {
            l2.Visible = false;
            t1.Visible = false;
            Button1.Visible = false;
            l1.Text = "there is no available quantity of this item";
        }
    }

    //aici este functia corespunzatoare butonului care face add to card
    protected void d1_ItemAdd(object sender, EventArgs e)
    {
        //e o verificare pt a nu mai avea si la finalul acestei metode acel close()
        //mai faina metoda
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from product where id=" + id + "";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            product_name = dr["product_name"].ToString();
            product_descr = dr["product_descr"].ToString();
            product_price = dr["product_price"].ToString();
            product_qty = dr["product_qty"].ToString();
            product_images = dr["product_images"].ToString();
        }



        //for that label with adding the amount
        if (Convert.ToInt32(t1.Text) > Convert.ToInt32(product_qty))
        {
            l1.Text = "Please insert a lower quantity";
        }
        else
        {
            //if the user enters properly---> remove the label l1
            l1.Text = "";
            //storing using cookies
            if (Request.Cookies["aa"] == null)
            {
                Response.Cookies["aa"].Value = product_name.ToString() +
                                              "," +
                                              product_descr.ToString() +
                                               "," +
                                              product_price.ToString() +
                                               "," +
                                              t1.Text +
                                               "," +
                                              product_images.ToString()+
                                              ","+
                                               id.ToString()
                                              ;
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {//daca ceva item e available il vom inregistra
                Response.Cookies["aa"].Value = Request.Cookies["aa"].Value +//valoarea
                                            "|" +
                                            product_name.ToString() +
                                             "," +
                                             product_descr.ToString() +
                                              "," +
                                             product_price.ToString() +
                                              "," +
                                             t1.Text +
                                              "," +
                                             product_images.ToString()+
                                             "," +
                                              id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                /*Exemplu: daca am aa="testing" si vreau sa adaug testing1=>aa=testing|testing1*/

            }


            ///asta e functia care updateaza cantitatea in cazul in care s-au adaugat produse in cos
            ///ce ramane afisat dupa adaugare 
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            //modific aici
            cmd1.CommandText = "update product set product_qty=product_qty-" + t1.Text+"where id="+id;
         
            
            cmd1.ExecuteNonQuery();
            Response.Redirect("product_desc.aspx?id="+ id.ToString());
        }
       
    }

    //functia care ma returneaza cantitatiea, ce mai apoi e verificata daca e =0 in prog principal 
    public int get_qty(int id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from product where id=" + id + "";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            qty = Convert.ToInt32(dr["product_qty"].ToString());
        }
        return qty;
    }
}