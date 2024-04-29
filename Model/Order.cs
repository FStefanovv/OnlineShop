namespace EFCoreVezba.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using EFCoreVezba.Enums;

public class Order {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    public string OrdererId {get; set;} 
    [ForeignKey("OrdererId")]
    public virtual User Orderer {get; set;}

    public string CompanyId {get; set;}
    [ForeignKey("CompanyId")]
    public virtual Company Company {get; set;}

    public string ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product {get; set;}
    public uint Quantity { get; set; }
    public float PricePerUnit { get; set; }
    public Currency Currency { get; set; }
    public float TotalPrice { get; set; }
    public DateTime OrderTime { get; set; }
    public OrderStatus Status { get; set; }
}