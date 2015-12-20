using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;

namespace AuthenticationService
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare Service1.svc o Service1.svc.cs in Esplora soluzioni e avviare il debug.
    public class AuthenticationService : IAuthenticationService
    {
        public string CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved)
        {
            MembershipCreateStatus status;
            Membership.CreateUser(username, password, email, "a", "b", true, out status);

            return status.ToString(); 
        }

        public string CustomValidateUser(string username, string password)
        {
            return Membership.ValidateUser(username, password) ? "ok" : "ko";
        }

        public string GetClientCode(string code)
        {
            var connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Azure"].ToString();
            var clientId = 0;
            using (var connection = new SqlConnection(connetionString))
            {
                using (var command = new SqlCommand("GetCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codice", code);

                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            clientId = Convert.ToInt32(reader["Id_Cliente"]);
                        }
                    reader.Close();
                }
                connection.Close();
            }
            return clientId.ToString();
        }

        /// <summary>
        /// Inserisce un cliente nella Tabella Clienti
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="codiceStruttura"></param>
        /// <param name="nome"></param>
        /// <param name="cognome"></param>
        /// <param name="indirizzo"></param>
        /// <param name="citta"></param>
        /// <param name="provincia"></param>
        /// <param name="cap"></param>
        /// <param name="nazione"></param>
        /// <param name="telefono"></param>
        /// <param name="cellulare"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="registratoIl"></param>
        /// <param name="attivo"></param>
        /// <returns>TODO: Restituire un corretto valore di ritorno</returns>
        public bool CreateUserClient(int clientId, string codiceStruttura, string nome, string cognome, string indirizzo, string citta,
            string provincia, string cap, string nazione, string telefono, string cellulare, string email, string password,
            DateTime registratoIl, bool attivo)
        {
            var connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql_Azure"].ToString();
            using (var connection = new SqlConnection(connetionString))
            {
                using (var command = new SqlCommand("InsertCliente", connection))
                {
                    command.Parameters.Clear();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDCliente", clientId);
                    command.Parameters.AddWithValue("@CodiceStruttura", codiceStruttura);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Cognome", cognome);
                    command.Parameters.AddWithValue("@Indirizzo", indirizzo);
                    command.Parameters.AddWithValue("@Citta", citta);
                    command.Parameters.AddWithValue("@Provincia", provincia);
                    command.Parameters.AddWithValue("@CAP", cap);
                    command.Parameters.AddWithValue("@Nazione", nazione);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Cellulare", cellulare);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@RegistratoIl", registratoIl);
                    command.Parameters.AddWithValue("@Attivo", attivo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
