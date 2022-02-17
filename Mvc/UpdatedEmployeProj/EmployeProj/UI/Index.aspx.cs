using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeProj.UI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadReport_Click(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/EmployeDetails.rdlc");
            OrganizationsDataSet organizationsDataSet = GetData();
            ReportDataSource dataSource = new ReportDataSource("Employee", organizationsDataSet.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(dataSource);

        }

        private OrganizationsDataSet GetData()
        {
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionstring"].ConnectionString;
            string query = "SELECT EmployeId,EmployeName,Designation,DateOfJoing,Contact,DepartmentId,Status,Sals,City FROM Empployes WHERE City=@City";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@City", TextCity.Text);

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    using (OrganizationsDataSet organizationsDataSet = new OrganizationsDataSet())
                    {
                        da.Fill(organizationsDataSet, "Empployes");
                        return organizationsDataSet;
                    }
                }
            }
        }
    }
}