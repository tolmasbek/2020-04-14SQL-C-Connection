using System;
using System.Data.SqlClient;
using System.Data;
namespace first
{
    class Program
    {
        static void Main(string[] args)
        {
            const string constring = @"Data source = TOLMASBEK-ПК; Initial catalog = ContactCenterTaxi; Integrated Security=True"; 
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            if(con.State==ConnectionState.Open)
            {
                System.Console.WriteLine("Yes connected !!!");
            }
            else
            {
                System.Console.WriteLine("Not connected !!!");
            }

            string commandText = "Select *from Operators";
            SqlCommand command = new SqlCommand(commandText, con);
            
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                System.Console.WriteLine($"Pseudonym:{reader.GetValue(0)},\nCategory:{reader.GetValue(1)},NumberOfCalls:{reader.GetValue(2)}");
            }
            reader.Close();
            
            string insertSqlCommand = string.Format($"insert into Operators([Pseudonym],[Category],[NumberOfCalls]) Values('{"rrrr"}', '{2}', '{345}')");
            command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();
            if(result > 0)
            {
                System.Console.WriteLine("Insert command successfull!!!");
            }
            con.Close();

            Console.ReadKey();
        }
    }
}
