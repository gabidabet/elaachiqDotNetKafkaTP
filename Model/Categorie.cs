using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyWebApplications.Model{
    [Table("Categories")]
    public class Categorie{
        [Key]
        public long CategorieId{get;set;}
        [Required,StringLength(25)]
        public string catName{get;set;}
        [JsonIgnore]
        public virtual ICollection<Produit> produits{get;set;}

    }
}