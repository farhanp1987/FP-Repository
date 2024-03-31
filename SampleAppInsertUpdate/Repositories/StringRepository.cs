using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SampleAppInsertUpdate.Models;

namespace SampleAppInsertUpdate.Data
{
    public class StringRepository
    {
        private readonly string _connectionString;

        public StringRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        }

        public void AddOrUpdateString(StringModel stringModel)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text
                };

                connection.Open();

                //check if string exists
                command.CommandText = "select UserID from Users where FullName = @FullName";
                command.Parameters.AddWithValue("@FullName", stringModel.Value);
                var existingID = command.ExecuteScalar();

                if (existingID != null)
                {
                    //update existing string
                    command.CommandText = "update Users set FullName =  @ExistingName, UpdatedOn = @LastUpdatedOn where UserId = @Id";
                    command.Parameters.AddWithValue("@LastUpdatedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@ExistingName", stringModel.Value);
                    command.Parameters.AddWithValue("@Id", existingID);
                }
                else
                {
                    //insert new record
                    command.CommandText = "insert into Users (FullName, UpdatedOn) values (@NewName, @NewUpdatedOn)";
                    command.Parameters.AddWithValue("@NewName", stringModel.Value);
                    command.Parameters.AddWithValue("@NewUpdatedOn", DateTime.Now);
                }

                command.ExecuteNonQuery();
                
            }
        }

        public IEnumerable<StringModel> GetStrings()
        {
            var strings = new List<StringModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "select top 10 UserID, FullName, CONVERT(varchar, UpdatedOn, 120) AS UpdatedOn from Users where UpdatedOn is not null order by UpdatedOn desc"
                };

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        strings.Add(new StringModel
                        {
                            ID = (int)reader["UserID"],
                            Value = reader["FullName"].ToString(),
                            UpdatedOn = reader["UpdatedOn"].ToString()
                        });
                    }
                }
            }

            return strings;
        }

    }
}