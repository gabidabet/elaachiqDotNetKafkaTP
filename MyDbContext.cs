using Microsoft.EntityFrameworkCore;
using MyWebApplications.Model;

namespace MyWebApplications{
    public class MyDbContext:DbContext{
        public DbSet<Client> Clients{get;set;}
        public DbSet<Produit> Produits{get;set;}
        public DbSet<Categorie> Categories{get;set;}

        public MyDbContext(DbContextOptions dbContextOptions):base(dbContextOptions){

        }

    }
}