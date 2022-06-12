using Lord_of_the_rings.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lord_of_the_rings.Data
{
    internal class LOTRDATA
    {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LOTRDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<LOTRModel> FetchAll()
        {
            List<LOTRModel> returneList = new List<LOTRModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        LOTRModel LOTR = new LOTRModel();
                        LOTR.ID = reader.GetInt32(0);
                        LOTR.Name = reader.GetString(1);
                        LOTR.Description = reader.GetString(2);
                        LOTR.AppearsIn = reader.GetString(3);
                        LOTR.WithThisActor = reader.GetString(4);

                        returneList.Add(LOTR);
                    }
                }
            }
            
            return returneList;
        }

        public LOTRModel FetchOne(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets WHERE Id = @id";
                // povezi @id sa id parametrom

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                LOTRModel LOTR = new LOTRModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LOTR.ID = reader.GetInt32(0);
                        LOTR.Name = reader.GetString(1);
                        LOTR.Description = reader.GetString(2);
                        LOTR.AppearsIn = reader.GetString(3);
                        LOTR.WithThisActor = reader.GetString(4);     

                        
                    }
                }
                return LOTR;
            }

        }
    }
}