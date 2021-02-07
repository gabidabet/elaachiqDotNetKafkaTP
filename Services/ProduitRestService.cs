using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApplications.Model;


namespace MyWebApplications.Services
{
    [Route("/api/produit")]
    public class ProduitRestService : Controller
    {
        MyDbContext dbService;
        KafkaProducer preducer = new KafkaProducer();

        public ProduitRestService(MyDbContext myDbContext)
        {
            dbService = myDbContext;
        }


        [HttpGet]
        public IEnumerable<Produit> produitList()
        {
            return dbService.Produits.Include(p => p.categorie);
        }

        [HttpPost]
        public Produit Save([FromBody] Produit produit)
        {
            dbService.Produits.Add(produit);
            dbService.SaveChanges();
            preducer.preduceMessage(1, new Data { operationType = "post", data = produit });
            return produit;
        }

        [HttpGet("{id}")]
        public Produit GetOne(long id)
        {
            return dbService.Produits.Include(p => p.categorie).FirstOrDefault(p => p.ProduitId == id);
        }

        [HttpDelete("{id}")]
        public Produit DeleteProduit(long id)
        {
            Produit p = dbService.Produits.FirstOrDefault(p => p.ProduitId == id);
            dbService.Produits.Remove(p);
            dbService.SaveChanges();
            preducer.preduceMessage(1, new Data { operationType = "delete", data = p });
            return p;
        }
        [HttpPut("{id}")]
        public Produit ModifProduit(long id, [FromBody] Produit produit)
        {
            produit.ProduitId = id;
            dbService.Produits.Update(produit);
            preducer.preduceMessage(1, new Data { operationType = "put", data = produit });
            return produit;
        }


        [HttpGet("search")]
        public IEnumerable<Produit> searchProduit(string kw)
        {
            return dbService.Produits.Include(p => p.categorie).Where(p => p.label.Contains(kw));
        }

    }
}