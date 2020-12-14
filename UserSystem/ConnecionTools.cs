using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSystem
{
    public static class ConnecionTools
    {
        #region REGISTRY AYARLARI
        private static string registrationPath="HKEY_CURRENT_USER\\USERSYSTEM\\";

        public static string ServerName
        {
            get
            {
                try
                {
                    return Registry.GetValue(registrationPath, "ServerName", ".").ToString();
                }
                catch (Exception)
                {
                    return ".";
                }
            }
            set
            {
                try
                {
                    Registry.SetValue(registrationPath, "ServerName", value);
                }
                catch (Exception)
                {
                }
            }
        }
        public static string DatabaseName
        {
            get
            {
                try
                {
                    return Registry.GetValue(registrationPath, "DatabaseName", "KullaniciPanel").ToString();
                }
                catch (Exception)
                {
                    return "KullaniciPanel";
                }
            }
            set
            {
                try
                {
                    Registry.SetValue(registrationPath, "DatabaseName", value);
                }
                catch (Exception)
                {
                }
            }
        }
        public static string Username
        {
            get
            {
                try
                {
                    return Registry.GetValue(registrationPath, "Username", "").ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    Registry.SetValue(registrationPath, "Username", value);
                }
                catch (Exception)
                {
                }
            }
        }
        public static string Password
        {
            get
            {
                try
                {
                    return Registry.GetValue(registrationPath, "Password", "").ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    Registry.SetValue(registrationPath, "Password", value);
                }
                catch (Exception)
                {
                }
            }
        }
        public static string IntegratedSecurity
        {
            get
            {
                try
                {
                    return Registry.GetValue(registrationPath, "IntegratedSecurity", "").ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    Registry.SetValue(registrationPath, "IntegratedSecurity", value);
                }
                catch (Exception)
                {
                }
            }
        }

        public static string getConnectionString_EX()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            //string serverName = @"(localdb)\MSSQLLocalDB";
            string serverName = ServerName;
            string databaseName = DatabaseName;
            string metadata = "Entity.Model1";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/" + metadata + ".csdl|"
                            + "res://*/" + metadata + ".ssdl|"
                           + "res://*/" + metadata + ".msl";
            return entityBuilder.ToString();
        }

        public static string GetConnectionString()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            string metadata = "Entity.Model1";
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = ServerName;
            sqlBuilder.InitialCatalog = DatabaseName;
            sqlBuilder.UserID = Username;
            sqlBuilder.Password = Password;
            sqlBuilder.ConnectTimeout = 5;
            sqlBuilder.IntegratedSecurity = false;

            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.MultipleActiveResultSets = true;

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/" + metadata + ".csdl|"
                + "res://*/" + metadata + ".ssdl|"
               + "res://*/" + metadata + ".msl";
            return entityBuilder.ToString();
        }

        internal class getConnectionString
        {
        }

        #endregion
    }
}
