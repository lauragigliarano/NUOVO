namespace NUOVO.Migrations.MigrationsA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrazione1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        RagioneSociale = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 10),
                        Mail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Commessa",
                c => new
                    {
                        CommessaID = c.Int(nullable: false),
                        Descrizione = c.String(maxLength: 50),
                        ClienteID = c.Int(nullable: false),
                        DataInizio = c.DateTime(nullable: false),
                        DataFine = c.DateTime(),
                        Importo = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CommessaID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.CommessaStackholder",
                c => new
                    {
                        CommessaID = c.Int(nullable: false),
                        StackholderID = c.Int(nullable: false),
                        NumeroRilevamentoID = c.Int(nullable: false),
                        DataRilevamento = c.DateTime(nullable: false),
                        Interesse = c.Int(nullable: false),
                        Potere = c.Int(nullable: false),
                        Impatto = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => new { t.CommessaID, t.StackholderID, t.NumeroRilevamentoID })
                .ForeignKey("dbo.Commessa", t => t.CommessaID, cascadeDelete: true)
                .ForeignKey("dbo.Stackholder", t => t.StackholderID, cascadeDelete: true)
                .Index(t => t.CommessaID)
                .Index(t => t.StackholderID);
            
            CreateTable(
                "dbo.Stackholder",
                c => new
                    {
                        StackholderID = c.Int(nullable: false),
                        Nome = c.String(maxLength: 50),
                        Cognome = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 10),
                        Cellulare = c.String(maxLength: 10),
                        Mail = c.String(maxLength: 50),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.StackholderID);
            
            CreateTable(
                "dbo.CommessaRischio",
                c => new
                    {
                        Progressivo = c.Int(nullable: false),
                        CommessaID = c.Int(nullable: false),
                        DataRilevamento = c.DateTime(nullable: false),
                        DataAggiornamento = c.DateTime(),
                        Voto = c.Int(nullable: false),
                        Priorita = c.Int(nullable: false),
                        Importo = c.Single(nullable: false),
                        Probabilita = c.String(),
                        Impatto = c.String(),
                        Strategia = c.String(),
                    })
                .PrimaryKey(t => new { t.Progressivo, t.CommessaID })
                .ForeignKey("dbo.Commessa", t => t.CommessaID, cascadeDelete: true)
                .Index(t => t.CommessaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommessaRischio", "CommessaID", "dbo.Commessa");
            DropForeignKey("dbo.CommessaStackholder", "StackholderID", "dbo.Stackholder");
            DropForeignKey("dbo.CommessaStackholder", "CommessaID", "dbo.Commessa");
            DropForeignKey("dbo.Commessa", "ClienteID", "dbo.Cliente");
            DropIndex("dbo.CommessaRischio", new[] { "CommessaID" });
            DropIndex("dbo.CommessaStackholder", new[] { "StackholderID" });
            DropIndex("dbo.CommessaStackholder", new[] { "CommessaID" });
            DropIndex("dbo.Commessa", new[] { "ClienteID" });
            DropTable("dbo.CommessaRischio");
            DropTable("dbo.Stackholder");
            DropTable("dbo.CommessaStackholder");
            DropTable("dbo.Commessa");
            DropTable("dbo.Cliente");
        }
    }
}
