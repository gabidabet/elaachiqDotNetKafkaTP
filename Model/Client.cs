using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace MyWebApplications.Model{
    [Table("Clients")]
    public class Client{
        [Key]
        public long Id{get;set;}
        [Required,StringLength(25)]
        public string nom{get;set;}
        [Required,StringLength(25)]
        public string prenom{get;set;}
        [Required,StringLength(50)]
        public string email{get;set;}
    }
}