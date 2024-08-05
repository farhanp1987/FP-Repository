using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Collections.Generic;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace BooksCheckInCheckOut
{
    public partial class Checkout : Page
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
                    SetDefaultDates();
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
                string query = "SELECT Title, ISBN, PublishYear, CoverPrice FROM BookDetails WHERE BookId = @BookId";

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
                    }
                    else
                    {
                        // Handle the case when the book with the specified BookId is not found
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }

        protected void SetDefaultDates()
        {
            txtCheckedOutDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtReturnDate.Text = CalculateReturnDate().ToString("MM/dd/yyyy");
        }

        protected DateTime CalculateReturnDate()
        {
            DateTime currentDate = DateTime.Now;
            DateTime returnDate = currentDate.AddDays(1); // Start from the next day
            int businessDaysCount = 0;

            while (businessDaysCount < 15)
            {
                if (!IsWeekend(returnDate) && !IsHoliday(returnDate))
                {
                    businessDaysCount++;
                }
                returnDate = returnDate.AddDays(1);
            }

            return returnDate.AddDays(-1); // Subtract 1 day to get the last counted business day
        }

        protected bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        protected bool IsHoliday(DateTime date)
        {
            // Define the list of holidays
            List<DateTime> holidays = new List<DateTime>
            {
                new DateTime(date.Year, 8, 10), // Example holiday 1
                new DateTime(date.Year, 8, 15), // Example holiday 2
                new DateTime(date.Year, 8, 20)  // Example holiday 3
            };

            // Check if the given date is in the list of holidays
            return holidays.Contains(date.Date);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int bookId = Convert.ToInt32(Request.QueryString["BookId"]);
            string borrowerName = txtBorrowerName.Text.Trim();
            string mobileNumber = txtMobileNumber.Text.Trim();
            string nationalID = txtNationalID.Text.Trim();
            string checkedOutDate = txtCheckedOutDate.Text;
            string returnDate = txtReturnDate.Text;

            // Validate the input fields
            if (string.IsNullOrEmpty(borrowerName) || string.IsNullOrEmpty(mobileNumber) || string.IsNullOrEmpty(nationalID))
            {
                lblErrorMessage.Text = "Please fill in all the required fields.";
                return;
            }

            // Validate the mobile number format
            if (!IsValidMobileNumber(mobileNumber))
            {
                lblErrorMessage.Text = "Please enter the mobile number in the format 'xx-xxxx xxx'.";
                return;
            }

            // Validate the national ID format
            if (!IsValidNationalID(nationalID))
            {
                lblErrorMessage.Text = "Please enter a numeric national ID with exactly 11 digits.";
                return;
            }

            // Save the checkout details in the CheckOutDetails table
            SaveCheckoutDetails(bookId, borrowerName, mobileNumber, nationalID, checkedOutDate, returnDate);

            // Redirect to the homepage
            Response.Redirect("Default.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            // Redirect to the homepage
            Response.Redirect("Default.aspx");
        }

        protected void SaveCheckoutDetails(int bookId, string borrowerName, string mobileNumber, string nationalID, string checkedOutDate, string returnDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BooksDBConnectionString"].ConnectionString;
            lblErrorMessage.Text = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO CheckOutDetails (BookId, BorrowerName, MobileNumber, NationalID, CheckedOutDate, ReturnDate) " +
                                   "VALUES (@BookId, @BorrowerName, @MobileNumber, @NationalID, @CheckedOutDate, @ReturnDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookId", bookId);
                        command.Parameters.AddWithValue("@BorrowerName", borrowerName);
                        command.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                        command.Parameters.AddWithValue("@NationalID", nationalID);
                        command.Parameters.AddWithValue("@CheckedOutDate", DateTime.ParseExact(checkedOutDate, "MM/dd/yyyy", CultureInfo.InvariantCulture));
                        command.Parameters.AddWithValue("@ReturnDate", DateTime.ParseExact(returnDate, "MM/dd/yyyy", CultureInfo.InvariantCulture));
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Update the IsCheckedOut flag in the BookDetails table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE BookDetails SET IsCheckedOut = 1 WHERE BookId = @BookId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookId", bookId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected bool IsValidMobileNumber(string mobileNumber)
        {
            // Validate the mobile number format (xx-xxxx xxx) using a regular expression
            Regex regex = new Regex(@"^\d{2}-\d{4} \d{3}$");
            return regex.IsMatch(mobileNumber);
        }

        protected bool IsValidNationalID(string nationalID)
        {
            // Validate the national ID format (numeric and contain 11 digits) using a regular expression
            Regex regex = new Regex(@"^\d{11}$");
            return regex.IsMatch(nationalID);
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