using System;
using System.Collections.Generic;
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

        public bool CustomValidateUser(string username, string password)
        {
            return Membership.ValidateUser(username, password);
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
