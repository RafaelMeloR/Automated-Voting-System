﻿using AVS_API.DataAccessLayer;
using AVS_API.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace AVS_API
{
    public static class utilities
    {
       

        public static class tools
        {
            
            public static string HashPassword(string password)
            { 
                string plainTextPassword = password;
                var passwordHasher = new PasswordHasher();
                string hashedPassword = passwordHasher.HashPassword(plainTextPassword);  
                return hashedPassword;
            }
            public static bool VerifyHashPassword(string user ,string password)
            {
                PersonViewModel pass = dal.get.Login(user);
                 
                bool hash=false;
                var passwordHasher = new PasswordHasher();
                string hashedPasswordFromDatabase = pass.Pasword;
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
            public static bool VerifyHash(string hashed, string id)
            {
                 
                bool hash = false;
                var passwordHasher = new PasswordHasher(); 
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(hashed, id);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    hash = true;
                }
                else if (passwordVerificationResult == PasswordVerificationResult.Failed)
                {
                    hash = false;
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
                        Console.WriteLine(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    Console.WriteLine(other.Message);
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
                    Console.WriteLine(ex.Message);

                }
            }
             
            public static async  
            Task<bool> Set(string query)
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
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                } 
                return false;
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
                    Console.WriteLine(ex.Message);
                }
                return dt;
            }
        }
    }

}
