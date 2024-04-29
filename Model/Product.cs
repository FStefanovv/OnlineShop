namespace EFCoreVezba.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using EFCoreVezba.Enums;

public class Product {
    public Product(){}

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    [Required]
    public string CompanyId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public uint Quantity {get; set;}
    [Required]
    public float UnitPrice {get; set;}
    public string Description {get;set;}
    public virtual Company Company {get; set;}
    public virtual List<Discount> Discounts { get; set;}

    public double GetUnitPrice() {
        var currentDiscount = Discounts.FirstOrDefault(x => x.ValidUntil > DateTime.UtcNow);

        if (currentDiscount == null)
            return UnitPrice;
        
        return (1 - currentDiscount.DiscountAmount/100.0) * UnitPrice;
    }
}