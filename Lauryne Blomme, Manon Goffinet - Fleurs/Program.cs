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
    using System.Xml.Serialization;

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
            Clients_Plusieurs_Commandes_Mois(connection);
            //Console.ReadLine();


        }


        static void Clients_Plusieurs_Commandes_Mois(MySqlConnection connection)
        {
            connection.Close();
            if (connection.State.ToString() != "Open")
            {
                connection.Open();
            }
            DateTime date = DateTime.Now;
            string jour = date.Day.ToString();
            string mois = "0" + date.Month.ToString();
            string annee = date.Year.ToString();
            string date_actuelle = annee + "-" + mois + "-" + jour;
            MySqlCommand commande = connection.CreateCommand();
            commande.CommandText = "SELECT idClient,nomC,prenomC,telephone,email,motDePasse,adresse,carteDeCredit,group_concat(dateCommande) from client natural join commande group by idClient";
            
            MySqlDataReader reader = commande.ExecuteReader();
            List<client> clients = new List<client>();
            int nb_bouquet_mois = 0;
            while (reader.Read())
            {
                nb_bouquet_mois = 0;
                string[] tab = reader.GetString(8).Split(",");
                foreach (string i in tab)
                {
                    string mois2 = i.Substring(5, 2);
                    if (mois2 == mois) { nb_bouquet_mois += 1; }
                    Console.Write(mois + ' ' + mois2);
                }
                client c = new client(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                if (nb_bouquet_mois >= 1) { clients.Add(c); }



            }
            XmlSerializer xs = new XmlSerializer(typeof(List<client>));
            StreamWriter sw = new StreamWriter("Clients_plusieurs_commandes_mois.xml");
            xs.Serialize(sw, clients);
            sw.Close();
            connection.Close();

        }
    }
    public class client
    {
        private string idClient;
        private string nomC;
        private string prenom;
        private string telephone;
        private string email;
        private string motDePasse;
        private string adresse;
        private string carteDeCredit;


        public client(string idClient, string nomC, string prenom, string tel, string email, string mdp, string adresse, string carteDeCredit)
        {
            this.idClient = idClient;
            this.nomC = nomC;
            this.prenom = prenom;
            this.telephone = tel;
            this.email = email;
            this.motDePasse = mdp;
            this.adresse = adresse;
            this.carteDeCredit = carteDeCredit;
        }
        public client()
        {
           
        }

        public string IdClient { get => idClient; set => idClient = value; }
        public string NomC { get => nomC; set => nomC = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string CarteDeCredit { get => carteDeCredit; set => carteDeCredit = value; }



    }

}