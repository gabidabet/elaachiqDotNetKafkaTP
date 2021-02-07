using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApplications.Model{
    [Table("produits")]
    public class Produit{
        [Key]
        public long ProduitId{set;get;}
        [Required,StringLength(25)]
        public string label{get;set;}

        public double prix{get;set;}

        public long CategorieId{get;set;}
        [ForeignKey("CategorieId")]
        public virtual Categorie categorie{get;set;}
    }
}