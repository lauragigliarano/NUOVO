namespace NUOVO.Migrations.MigrationsA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialASchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        RagioneSociale = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 10),
                        Mail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Commessas",
                c => new
                    {
                        CommessaID = c.Int(nullable: false),
                        Descrizione = c.String(maxLength: 50),
                        ClienteID = c.Int(nullable: false),
                        DataInizio = c.DateTime(nullable: false),
                        DataFine = c.DateTime(nullable: false),
                        Importo = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CommessaID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.CommessaStackholders",
                c => new
                    {
                        NumeroRilevamentoID = c.Int(nullable: false),
                        CommessaID = c.Int(nullable: false),
                        StackholderID = c.Int(nullable: false),
                        DataRilevamento = c.DateTime(nullable: false),
                        Interesse = c.Int(nullable: false),
                        Potere = c.Int(nullable: false),
                        Impatto = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.NumeroRilevamentoID)
                .ForeignKey("dbo.Commessas", t => t.CommessaID, cascadeDelete: true)
                .ForeignKey("dbo.Stackholders", t => t.StackholderID, cascadeDelete: true)
                .Index(t => t.CommessaID)
                .Index(t => t.StackholderID);
            
            CreateTable(
                "dbo.Stackholders",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommessaStackholders", "StackholderID", "dbo.Stackholders");
            DropForeignKey("dbo.CommessaStackholders", "CommessaID", "dbo.Commessas");
            DropForeignKey("dbo.Commessas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.CommessaStackholders", new[] { "StackholderID" });
            DropIndex("dbo.CommessaStackholders", new[] { "CommessaID" });
            DropIndex("dbo.Commessas", new[] { "ClienteID" });
            DropTable("dbo.Stackholders");
            DropTable("dbo.CommessaStackholders");
            DropTable("dbo.Commessas");
            DropTable("dbo.Clientes");
        }
    }
}
