using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NUOVO.Models;
using System.Data.Entity.Validation;

namespace NUOVO.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            try
            {
                var cliente = new List<Cliente>
            {
            new Cliente{ClienteID=1159,RagioneSociale="Easynet S.p.A.", Telefono="0341256911", Mail = "info@enet.it"},
            new Cliente{ClienteID=1139,RagioneSociale="Enel Italia S.p.a.", Telefono="0341222211", Mail = "info@enei.it"},
            new Cliente{ClienteID=1149,RagioneSociale="Enel Energia S.p.a.", Telefono="0341256333", Mail = "info@enen.it"}
            };

                cliente.ForEach(s => context.Cliente.Add(s));
                context.SaveChanges();

                var commessa = new List<Commessa>
            {
            new Commessa{CommessaID=1050,Descrizione="Chemistry",ClienteID=1159,DataInizio=DateTime.Parse("2005-09-01"),/*DataFine=DateTime.Parse("2006-09-01"),*/ Importo = 10.2F},
            new Commessa{CommessaID=1030,Descrizione="Abbattimento",ClienteID=1139,DataInizio=DateTime.Parse("2015-09-01"),/*DataFine=DateTime.Parse("2015-10-01"),*/ Importo = 15.5F},
            new Commessa{CommessaID=1040,Descrizione="Cablaggio",ClienteID=1149,DataInizio=DateTime.Parse("2006-03-01"),/*DataFine=DateTime.Parse("2006-07-01"),*/ Importo = 11.4F},
            };
                commessa.ForEach(e => context.Commessa.Add(e));
                context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
          
        }
    }
}