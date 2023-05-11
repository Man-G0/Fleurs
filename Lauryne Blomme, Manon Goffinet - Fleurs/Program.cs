using MySql.Data.MySqlClient;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    using Google.Protobuf.WellKnownTypes;
    using Mysqlx.Prepare;
    using MySqlX.XDevAPI.Relational;
    using MySqlX.XDevAPI;
    using Org.BouncyCastle.Asn1.Crmf;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Text;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = "SERVER=loc" +
                "alhost;PORT=3306;DATABASE=Fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            //Console.WriteLine("connexion");
            connection.Open();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(connection));
            //Console.WriteLine("fin des opérations");
            connection.Close();
            //Console.ReadLine();

        }
    }
}