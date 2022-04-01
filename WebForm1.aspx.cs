using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDefaultFirstRecord();
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            txtDate.Text = Calendar1.SelectedDate.ToShortDateString();

           // dt.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }
        private void AddDefaultFirstRecord()
        {
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "Energy Selling";
            dt.Columns.Add(new DataColumn("Date", typeof(string)));
            dt.Columns.Add(new DataColumn("EnergyType", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
           
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["EnergySelling"] = dt;
            //bind Gridview  
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["EnergySelling"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["EnergySelling"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DateTime dateinput =Convert.ToDateTime(txtDate.Text.ToString());
                     // DateTime dtResult = DateTime.ParseExact(dateinput, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                       

                        DayOfWeek today = dateinput.DayOfWeek;


                     
                            //add each row into data table  
                            drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Date"] = txtDate.Text;
                        drCurrentRow["EnergyType"] = ddlEnergyType.SelectedValue;

                        if (today == DayOfWeek.Sunday || today == DayOfWeek.Saturday)
                        {
                            int discount = Convert.ToInt32(txtPrice.Text) * 10 / 100;
                            drCurrentRow["Price"] = Convert.ToInt32(txtPrice.Text)-discount+" -Discount ";

                        }
                        else
                        {
                            drCurrentRow["Price"] = txtPrice.Text;
                        }
                        
                      


                    }
                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //add created Rows into dataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Save Data table into view state after creating each row  
                    ViewState["EnergySelling"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                    txtDate.Text = "";
                    txtPrice.Text = "";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
        }
    }
}