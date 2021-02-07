using MyWebApplications.Model;
namespace MyWebApplications{
    public class DbInt{
        public static void initData(MyDbContext myDbContext){
            myDbContext.Clients.Add(new Client{nom="amin",prenom="goulzima",email="amin@goulzima.com"});
            myDbContext.Clients.Add(new Client{nom="Mohamed amine",prenom="goulzima",email="mohamedamin@goulzima.com"});
            myDbContext.Clients.Add(new Client{nom="jinzo",prenom="goulzima",email="jinzo@goulzima.com"});
            myDbContext.SaveChanges();
            myDbContext.Categories.Add(new Categorie{catName="Ordinateur"});
            myDbContext.Categories.Add(new Categorie{catName="Impriment"});
            myDbContext.SaveChanges();
            myDbContext.Produits.Add(new Produit{label="ordi HP 5",prix=20.20,CategorieId=1});
            myDbContext.Produits.Add(new Produit{label="ordi HP 5",prix=20.60,CategorieId=1});
            myDbContext.Produits.Add(new Produit{label="impr 1",prix=21.60,CategorieId=2});
            myDbContext.SaveChanges();
        }
    }
}