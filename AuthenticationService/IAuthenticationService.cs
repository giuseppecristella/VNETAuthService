using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthenticationService
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IService1" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IAuthenticationService
    {

        [OperationContract]
        string CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved);

        [OperationContract]
        string CustomValidateUser(string username, string password);

        [OperationContract]
        string GetClientCode(string code);

        [OperationContract]
        bool CreateUserClient(int clientId, string codiceStruttura, string nome, string cognome, string indirizzo, string citta, string provincia, string cap,
            string nazione, string telefono, string cellulare, string email, string password, DateTime registratoIl, bool attivo);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: aggiungere qui le operazioni del servizio
    }


    // Per aggiungere tipi compositi alle operazioni del servizio utilizzare un contratto di dati come descritto nell'esempio seguente.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
