using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksCheckInCheckOut
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookList();
            }
        }

        protected void BindBookList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BooksDBConnectionString"].ConnectionString;

            try
            {
                //creating a new connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT BookId, Title, ISBN, PublishYear, CoverPrice, IsCheckedOut FROM BookDetails";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //open a connection
                        connection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dtBooks = new DataTable();
                        adapter.Fill(dtBooks);
                        GridViewBooks.DataSource = dtBooks;
                        GridViewBooks.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Button btnCheckOut = (Button)sender;
            int bookId = Convert.ToInt32(btnCheckOut.CommandArgument);

            // Redirect to the Checkout page with the BookId as a query parameter
            Response.Redirect("Checkout.aspx?BookId=" + bookId);
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            Button btnCheckIn = (Button)sender;
            int bookId = Convert.ToInt32(btnCheckIn.CommandArgument);

            // Redirect to the Checkin page with the BookId as a query parameter
            Response.Redirect("Checkin.aspx?BookId=" + bookId);
        }

        protected void LogError(string errorMessage)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BooksDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ErrorsLog (ErrorMessage, ErrorDate) VALUES (@ErrorMessage, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ErrorMessage", errorMessage);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}