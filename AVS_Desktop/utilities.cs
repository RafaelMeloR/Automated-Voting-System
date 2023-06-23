using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Views;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace AVS_Desktop
{
    public static class utilities
    {
        public static class AVS
        {
            public static void DataTableToDataGrid(DataGrid grid,DataTable dt)
            {  
                grid.ItemsSource = dt.DefaultView;
            }

            /*public static void copyToTextBox(Object ob, DataRowView selected_row)
            {
                Admin objAdmin = new Admin();
                Sales objSales = new Sales();
                dynamic obj = null;
                if (objAdmin.GetType() == ob.GetType())
                {
                    obj = (Admin)ob;
                }
                else if (objSales.GetType() == ob.GetType())
                {
                    obj = (Sales)ob;
                }

                if (selected_row != null)
                {
                    obj.ProductId.Text = selected_row[0].ToString();
                    obj.producName.Text = selected_row[1].ToString();
                    obj.Amount.Text = selected_row[2].ToString();
                    obj.Price.Text = selected_row[3].ToString();
                }

            }*/
        }

        public static class tools
        {
            public static bool ValidateInputs(params TextBox[] textBoxes)
            {
                foreach (TextBox textBox in textBoxes)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show($"Please enter a value in {textBox.Name}.");
                        textBox.Focus();
                        return false;
                    }
                }

                return true;
            }
            public static string HashPassword(string password)
            { 
                string plainTextPassword = password;
                var passwordHasher = new PasswordHasher();
                string hashedPassword = passwordHasher.HashPassword(plainTextPassword);  
                return hashedPassword;
            }
            public static bool VerifyHashPassword(string user ,string password)
            {
                String pass = dal.get.Login(user);
                 
                bool hash=false;
                var passwordHasher = new PasswordHasher();
                string hashedPasswordFromDatabase = pass;
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(hashedPasswordFromDatabase, password);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    hash = true; 
                }
                else if (passwordVerificationResult == PasswordVerificationResult.Failed)
                {
                    hash=false; 
                }
                
                return hash;
            }
            public static void OpenUrl(string target)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = target,
                        UseShellExecute = true
                    });
                }
                catch (System.ComponentModel.Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2147467259)
                        MessageBox.Show(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
            }
            public static string GetIpAddress()
            {
                string ipAddress = string.Empty;

                try
                {
                    string hostName = Dns.GetHostName();
                    IPAddress[] addresses = Dns.GetHostAddresses(hostName);

                    foreach (IPAddress address in addresses)
                    {
                        if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = address.ToString();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting IP address: " + ex.Message);
                }

                return ipAddress;
            }
        
            public static string GetMacAddress()
            {
                string macAddress = string.Empty;

                try
                {
                    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                            nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                        {
                            macAddress = nic.GetPhysicalAddress().ToString();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting MAC address: " + ex.Message);
                }

                return macAddress;
            }

            //<Label Name="LiveTimeLabel" Content="%TIME%" HorizontalAlignment="Left" Margin="557,248,0,0" VerticalAlignment="Top" Height="55" Width="186" FontSize="36" FontWeight="Bold" Foreground="Red" />
            public static void timer(Vote ob)
            {
                DispatcherTimer LiveTime = new DispatcherTimer();
                LiveTime.Interval = TimeSpan.FromSeconds(1);
                LiveTime.Tick +=ob.timer_Tick; 
                LiveTime.Start();
            }
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

                string connectionString = "Server=localhost;Database=AutomatedVotingSystem;Integrated Security=True;TrustServerCertificate=True";
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
             
            public static async  
            Task Set(string query)
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
