using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService.Repositories
{
    public class ContactRepository
    {
        public static bool AddContactToDB(Contact contact)
        {
            var connectionString = "Data Source = IGALSQL; Initial Catalog = ContactManager; Integrated Security = True";

            var query = "INSERT INTO ContactList (Name, PhoneNumber, Note) VALUES " +
                            "(@Name, @PhoneNum, @Note)";

            query = query.Replace("@Name", contact.Name).Replace("@PhoneNum", contact.PhoneNumber).Replace("@Note", contact.Note);

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                //opening connection
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                //closing connection
                command.Dispose();
                connection.Close();
                return true;
            }
            catch(Exception)
            {
                //throw exception
                return false;
            }
        }
    }
}