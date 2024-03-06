using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectDb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            try
            {
                sqlConnection = new SqlConnection(constr);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("SELECT * from Users");
                sqlDataAdapter = new SqlDataAdapter();
                sqlCommand.Connection = sqlConnection;
                sqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                this.usersGrView.DataSource = dataTable;
                this.usersGrView.DataBind();
                sqlConnection.Close();
            }
            catch (Exception ms)
            {
                //To do
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            usersGrView.PageIndex = e.NewPageIndex;
            this.BindGridView();
        }

        protected void SerchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(constr);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("SELECT * FROM Users,TimeLog WHERE LogDate BETWEEN'" + this.fromDateSearch.Text + "'AND'" + this.toDateSearch.Text + "'");
                sqlCommand.Connection = sqlConnection;
                dataTable = new DataTable();
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                this.usersGrView.DataSource = dataTable;
                this.usersGrView.DataBind();
                sqlConnection.Close();
            }
            catch (Exception ms)
            {
                // To do
            }
        }
        protected void InitializationDbBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(constr);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("InitializeDatabase", sqlConnection);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Redirect("Default.aspx");
            }
            catch(Exception ms)
            {
                //To do
            }
        }
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        const string constr = "Data Source=localhost;Initial Catalog=projectDb;Integrated Security=True";
    }
}