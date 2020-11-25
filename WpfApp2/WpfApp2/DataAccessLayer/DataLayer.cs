using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WpfApp1.Model;
using System.Data;

namespace WpfApp1.DataAccessLayer
{
    class DataLayer
    {
        string connstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlCommand cmd; //= new SqlCommand(query, con);

        public int verifyCredentials(string uname, string upwd)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            string query = "SELECT COUNT(*) FROM Login " +
                "WHERE username = \'"+uname+"\' AND password = \'"+upwd+"\'";
            
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                return 0;   // not exits
            }
            else if (dt.Rows[0][0].ToString().Equals("1"))
            {
                return 1;   // verified
            }

            con.Close();
            return -1;   // some problem 
        }

        public int insertToUsersDB(User u)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            string query = "INSERT INTO Users (firstName, lastName,email, password)" +
                " VALUES(\'" + u.FirstName + "\', \'" + u.LastName + "\', \'" + u.Email + "\', \'" + u.Password + "\')";

            //  string query = "INSERT INTO Users (firstName, lastName,email, password)" +
            //                 " VALUES(\'@f\', \'@l\', \'@e\', \'@p\')";

            // It gives error that you need to convert string into SqlDbType 

            //SqlParameter p1 = new SqlParameter('f', u.FirstName);
            //SqlParameter p2 = new SqlParameter('l', u.LastName);
            //SqlParameter p3 = new SqlParameter('e', u.Email);
            //SqlParameter p4 = new SqlParameter('p', u.Password);

            cmd = new SqlCommand(query, con);

            //cmd.Parameters.Add(p1);
            //cmd.Parameters.Add(p2);
            //cmd.Parameters.Add(p3);
            //cmd.Parameters.Add(p4);
            int insertRows = cmd.ExecuteNonQuery();

            con.Close();
            return insertRows;
        }

        public List<User> getAllUsersFromDB()
        {
            List<User> users = new List<User>();

            SqlConnection con = new SqlConnection(connstring);
            con.Open();
                string query = "SELECT * FROM Users";
                cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
            

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine("::Got Data::");
                    Console.WriteLine($"id:{dr.GetValue(0)}");
                    Console.WriteLine($"First Name:{dr.GetValue(1)}");
                    Console.WriteLine($"Last Name:{dr.GetValue(2)}");
                    Console.WriteLine($"Email:{dr.GetValue(3)}");
                    Console.WriteLine($"Password:{dr.GetValue(4)}");

                    User u = new User(dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString());
                    users.Add(u);
                }
            }
            else
            {
                return null;
            }
            con.Close();
            return users.Count == 0 ? null : users;
        }
    }
}
