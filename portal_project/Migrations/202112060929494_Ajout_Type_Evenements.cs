namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajout_Type_Evenements : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categorie(Libelle) VALUES('Culture')");
            Sql("INSERT INTO Categorie(Libelle) VALUES('Sport')");

            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Concert',1) ");
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Art',1) ");
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Histoire',1) ");
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Festival de musique',1) ");

            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Football',2) ");
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Rugby',2) "); 
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Trail',2) ");
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Fitness',2) ");
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Judo',2) ");
            Sql("Insert INTO SousCategorie(Libelle,EventCategorie_Id) VALUES('Karaté',2) ");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categorie");
            Sql("DELETE FROM SousCategorie");
        }
    }
}
