using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace BooksCheckInCheckOut
{
    public partial class Checkin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BookId"] != null)
                {
                    //Read BookId if passed as a query parameter in Querystring
                    int bookId = Convert.ToInt32(Request.QueryString["BookId"]);

                    LoadBookDetails(bookId);
                }
                else
                {
                    // Handle the case when BookId is not provided in the query string
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void LoadBookDetails(int bookId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BooksDBConnectionString"].ConnectionString;

            //creating a new connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT b.Title, b.ISBN, b.PublishYear, b.CoverPrice, c.BorrowerName, c.MobileNumber, c.NationalID, c.CheckedOutDate, c.ReturnDate 
                                FROM BookDetails b inner join CheckOutDetails c on b.BookId = c.BookId
                                WHERE b.BookId = @BookId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        lblBookTitle.Text = reader["Title"].ToString();
                        lblISBN.Text = reader["ISBN"].ToString();
                        lblPublishYear.Text = reader["PublishYear"].ToString();
                        lblCoverPrice.Text = Convert.ToDecimal(reader["CoverPrice"]).ToString("C");
                        txtBorrowerName.Text = reader["BorrowerName"].ToString();
                        txtMobileNumber.Text = reader["MobileNumber"].ToString();
                        txtNationalID.Text = reader["NationalID"].ToString();

                        // Format CheckedOutDate and ReturnDate in MM/dd/yyyy format
                        DateTime checkedOutDate = Convert.ToDateTime(reader["CheckedOutDate"]);
                        DateTime returnDate = Convert.ToDateTime(reader["ReturnDate"]);
                        txtCheckedOutDate.Text = checkedOutDate.ToString("MM/dd/yyyy");
                        txtReturnDate.Text = returnDate.ToString("MM/dd/yyyy");

                        // Calculate the penalty for late return
                        DateTime currentDate = DateTime.Now;
                        int lateDays = (int)(currentDate - returnDate).TotalDays;
                        decimal penalty = lateDays * 5;
                        if (penalty < 0)
                        {
                            penalty = 0; // No penalty if returned on or before the due date
                        }
                        lblPenalty.Text = penalty.ToString("C");
                    }
                    else
                    {
                        // Handle the case when the book with the specified BookId is not found
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            // Redirect to the homepage
            Response.Redirect("Default.aspx");
        }

    }
}