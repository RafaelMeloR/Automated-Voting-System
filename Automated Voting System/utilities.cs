﻿/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows; 
using System.Windows.Input;

namespace Automated_Voting_System.Models
{
    public static class utilities
    {

       
        public static class tools
        {
            public static Boolean numberValidation(TextCompositionEventArgs e)
            {

                e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
                return e.Handled;
            }

        }
        public static  class sql
        {
            private static string getConnnectionString()
            {

                string connectionString = "Server=localhost;Database=FarmersMarket;Trusted_Connection=True; encrypt=false;";
                return connectionString;
            }
            private static SqlConnection con;
            private static SqlCommand cmd;

            private static  void establishConnection()
            {
                try
                {
                    con = new SqlConnection(getConnnectionString());
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

            //Threading for handling database operations
            public static async 
            //Threading for handling database operations
            Task
            Set(string query)
            {
                try
                {
                    establishConnection();
                    if (con.State != ConnectionState.Open)
                    {
                        await con.OpenAsync();
                    }
                    using (cmd = new SqlCommand(query, con))
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Executed Successfully");
                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public static DataTable Get(string query)
            {
                DataTable dt = new DataTable();
                try
                {
                    establishConnection();
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(dt);
                    con.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return dt;
            }
        }
    }

}
*/