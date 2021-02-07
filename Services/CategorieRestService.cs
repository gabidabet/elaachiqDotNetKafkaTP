using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApplications.Model;

namespace MyWebApplications.Services
{
    [Route("/api/categories")]
    public class CategorieRestService : Controller
    {
        MyDbContext dbService;
        KafkaProducer preducer = new KafkaProducer();

        public CategorieRestService(MyDbContext myDbContext)
        {
            dbService = myDbContext;
        }


        [HttpGet]
        public IEnumerable<Categorie> catigorieList()
        {
            return dbService.Categories;
        }

        [HttpPost]
        public Categorie Save([FromBody] Categorie produit)
        {
            dbService.Categories.Add(produit);
            dbService.SaveChanges();
            preducer.preduceMessage(1, new Data { operationType = "post", data = produit });
            return produit;
        }

        [HttpGet("{id}")]
        public Categorie GetOne(long id)
        {
            return dbService.Categories.FirstOrDefault(p => p.CategorieId == id);
        }

        [HttpGet("{id}/produits")]
        public IEnumerable<Produit> GetProduit(long id)
        {
            Categorie categorie = dbService.Categories.Include(categorie => categorie.produits)
            .FirstOrDefault(p => p.CategorieId == id);
            return categorie.produits;
        }





        [HttpDelete("{id}")]
        public Categorie DeleteCategorie(long id)
        {
            Categorie p = dbService.Categories.FirstOrDefault(p => p.CategorieId == id);
            dbService.Categories.Remove(p);
            dbService.SaveChanges();
            preducer.preduceMessage(1, new Data { operationType = "delete", data = p });
            return p;
        }
        [HttpPut("{id}")]
        public Categorie ModifCategorie(long id, [FromBody] Categorie produit)
        {
            produit.CategorieId = id;
            dbService.Categories.Update(produit);
            preducer.preduceMessage(1, new Data { operationType = "Put", data = produit });
            return produit;
        }
    }
}