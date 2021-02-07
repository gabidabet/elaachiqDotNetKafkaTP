using MyWebApplications.Model;
namespace MyWebApplications
{
    public class DbInt
    {
        public static void initData(MyDbContext myDbContext)
        {
            myDbContext.Clients.Add(new Client { nom = "elaachiq", prenom = "youness", email = "youness.elaachiq.info@gmail.com" });
            myDbContext.Clients.Add(new Client { nom = "assili", prenom = "karima", email = "karima@assili.com" });
            myDbContext.Clients.Add(new Client { nom = "elaachiq", prenom = "abderrahim", email = "elaachiq@abderrahim.com" });
            myDbContext.SaveChanges();
            myDbContext.Categories.Add(new Categorie { catName = "Ordinateur" });
            myDbContext.Categories.Add(new Categorie { catName = "Impriment" });
            myDbContext.SaveChanges();
            myDbContext.Produits.Add(new Produit { label = "hp 650 G1", prix = 20.20, CategorieId = 1 });
            myDbContext.Produits.Add(new Produit { label = "hp 650 G1", prix = 20.60, CategorieId = 1 });
            myDbContext.Produits.Add(new Produit { label = "imprimente 1", prix = 21.60, CategorieId = 2 });
            myDbContext.SaveChanges();
        }
    }
}