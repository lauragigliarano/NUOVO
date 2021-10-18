namespace NUOVO.Migrations.MigrationsA
{
    using NUOVO.Models;
    using NUOVO.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity.Validation;
    using System.Collections;
    using System.Globalization;
    internal sealed class ConfigurationA : DbMigrationsConfiguration<NUOVO.DAL.Context>
    {
        public ConfigurationA()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "NUOVO.DAL.Context";
        }

        protected override void Seed(NUOVO.DAL.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            try
            {
                var cliente = new List<Cliente>
                {
                    new Cliente{ClienteID=1159,RagioneSociale="Easynet S.p.A.", Telefono="0341256911", Mail = "info@enet.it",
                        Commesse = new List<Commessa>()},
                    new Cliente{ClienteID=1139,RagioneSociale="Enel Italia S.p.a.", Telefono="0341256911", Mail = "info@enei.it",
                        Commesse = new List<Commessa>()},
                    new Cliente{ClienteID=1149,RagioneSociale="Enel Energia S.p.a.", Telefono="0341256911", Mail = "info@enen.it",
                        Commesse = new List<Commessa>()}
                };
                cliente.ForEach(s => context.Cliente.Add(s));
                context.SaveChanges();


                var commessa = new List<Commessa>
                {
                    new Commessa{CommessaID=1050, Descrizione="Chemistry",
                        DataInizio=DateTime.Parse("2005-09-01"),DataFine=DateTime.Parse("2006-09-01"),
                        Importo = 10, ClienteID = cliente.Single(c => c.ClienteID == 1159 ).ClienteID, CommessaStackholders=new List<CommessaStackholder>()},
                    new Commessa{CommessaID=1030, Descrizione="Abbattimento",
                        DataInizio=DateTime.Parse("2015-09-01"), /*DataFine=DateTime.Parse("2015-10-01")*/
                        Importo = 10, ClienteID = cliente.Single(c => c.ClienteID == 1159 ).ClienteID, CommessaStackholders=new List<CommessaStackholder>() },
                    new Commessa{CommessaID=1040, Descrizione="Cablaggio",
                        DataInizio=DateTime.Parse("2006-03-01"), /*DataFine=DateTime.Parse("2006-07-01")*/
                        Importo = 10, ClienteID = cliente.Single(c => c.ClienteID == 1149 ).ClienteID, CommessaStackholders=new List<CommessaStackholder>()},
                };
                commessa.ForEach(s => context.Commessa.Add(s));
                context.SaveChanges();


                var stackholder = new List<Stackholder>
                {
                    new Stackholder{StackholderID=1159,Nome="Investitore", Cognome="uno", Telefono = "0341131476", Cellulare="3382542742", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CommessaStackholders=new List<CommessaStackholder>()},
                    new Stackholder{StackholderID=1139,Nome="Investitore", Cognome="due", Telefono = "0341131476", Cellulare="3382542742", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CommessaStackholders=new List<CommessaStackholder>()},
                    new Stackholder{StackholderID=1229,Nome="Investitore", Cognome="tre", Telefono = "0341131476", Cellulare="3382542742", Mail="info@enet.it", Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        CommessaStackholders=new List<CommessaStackholder>()}
                };
                stackholder.ForEach(s => context.Stackholder.Add(s));
                context.SaveChanges();


                var commessastackholder = new List<CommessaStackholder>
                {
                    new CommessaStackholder{CommessaID = commessa.Single(c => c.CommessaID == 1030 ).CommessaID, StackholderID = stackholder.Single(c => c.StackholderID == 1139 ).StackholderID, NumeroRilevamentoID=1229,DataRilevamento=DateTime.Parse("2006-03-01"),Interesse=2, Potere=5, Impatto = 1, Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                    new CommessaStackholder{CommessaID = commessa.Single(c => c.CommessaID == 1040 ).CommessaID, StackholderID = stackholder.Single(c => c.StackholderID == 1159 ).StackholderID, NumeroRilevamentoID=1529,DataRilevamento=DateTime.Parse("2009-03-01"),Interesse=4, Potere=1, Impatto = 3, Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                    new CommessaStackholder{CommessaID = commessa.Single(c => c.CommessaID == 1050 ).CommessaID, StackholderID = stackholder.Single(c => c.StackholderID == 1229 ).StackholderID, NumeroRilevamentoID=1829,DataRilevamento=DateTime.Parse("2015-05-01"),Interesse=3, Potere=2, Impatto = 5, Note="Lorem ipsum dolor sit amet, consectetur adipisci elit, sed do eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullamco laboriosam, nisi ut aliquid ex ea commodi consequatur. Duis aute irure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." }
                };
                commessastackholder.ForEach(s => context.CommessaStackholders.Add(s));
                context.SaveChanges();


                var commessarischio = new List<CommessaRischio>
                {
                    new CommessaRischio{ NomeRischio="Pandemia", CommessaID=commessa.FirstOrDefault(c => c.Descrizione == "Cablaggio" ).CommessaID , Progressivo=5, DataRilevamento=DateTime.Parse("2006-03-01"), DataAggiornamento=DateTime.Parse("2006-03-05"), Voto=2, Priorita=5, Importo = 12.5f, Probabilita="Rare", Impatto="Catastrophic", Strategia="Contain" },
                    new CommessaRischio{  NomeRischio="Dimissioni", CommessaID=commessa.FirstOrDefault(c => c.Descrizione == "Abbattimento" ).CommessaID , Progressivo=3, DataRilevamento=DateTime.Parse("2015-11-22"), DataAggiornamento=DateTime.Parse("2016-12-05"), Voto=3, Priorita=1, Importo = 107.35f, Probabilita="Possible", Impatto="Major", Strategia="Transfer" },
                    new CommessaRischio{  NomeRischio="Pandemia operai", CommessaID=commessa.FirstOrDefault(c => c.Descrizione == "Chemistry" ).CommessaID , Progressivo=1, DataRilevamento=DateTime.Parse("2018-06-16"), DataAggiornamento=DateTime.Parse("2020-09-20"), Voto=4, Priorita=3, Importo = 1273.44f, Probabilita="Rare", Impatto="Minor", Strategia="Avoid" }
                };
                commessarischio.ForEach(s => context.CommessaRischio.Add(s));
                context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
        public static void Main()
        {
            Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
            // Creates and initializes the CultureInfo which uses the international sort.
            CultureInfo myCIintl = new CultureInfo("it-IT", false);
            Console.WriteLine("CurrentCulture is now {0}.", CultureInfo.CurrentCulture.Name);

        }
    }
}
