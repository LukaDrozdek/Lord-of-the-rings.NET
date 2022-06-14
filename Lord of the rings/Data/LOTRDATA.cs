using Lord_of_the_rings.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lord_of_the_rings.Data
{
    internal class LOTRDATA
    {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LOTRDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // dohvati sve
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

        internal int Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = sqlQuery = "DELETE FROM dbo.Gadgets WHERE Id = @id";


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = Id;

                connection.Open();
                int DeletedId = command.ExecuteNonQuery();


                return DeletedId;
            }
        }

        // dohvati jednog po ID
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

        public int CreateOrUpdate(LOTRModel lotrModel)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if(lotrModel.ID <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Gadgets Values(@Name, @Description, @AppearsIn, @WithThisActor)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, AppearsIn= @AppearsIn, WithThisActor = @WithThisActor WHERE Id = @Id";
                }
                // povezi @id sa id parametrom

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = lotrModel.ID;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = lotrModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = lotrModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = lotrModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = lotrModel.WithThisActor;
                connection.Open();
                int newID = command.ExecuteNonQuery();

                
                return newID;
            }

        }


    }
}