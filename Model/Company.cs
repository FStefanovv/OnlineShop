using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreVezba.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Company
    {
        public Company(){}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email {get; set;}
        [Required]
        public string BankAccountId {get; set;}
        public virtual List<Product> Products { get; set; }
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("BankAccountId")]
        public virtual BankAccount BankAccount { get; set; }
    }
}
