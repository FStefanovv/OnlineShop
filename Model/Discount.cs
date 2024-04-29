namespace EFCoreVezba.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Discount {
    public Discount(){}

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    [Required]
    public string ProductId {get;set;}
    [Required]
    public DateTime ValidUntil {get;set;}
    [Required]
    public double DiscountAmount  {get;set;}
}