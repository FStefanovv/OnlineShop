namespace EFCoreVezba.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Email), IsUnique = true)]
public class User {
    public User(){}

    public User(string fname, string lname, string email, DateTime birthDate, string password) {
        FirstName = fname;
        LastName = lname;
        DateOfBirth = birthDate;
        Email = email;
        Password = password;
        RegisteredOn = DateTime.UtcNow;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id {get; set;}

    [Required]
    [EmailAddress]
    public string Email {get; set;}

    [Required]
    public string Password {get; set;}

    [Required]
    public string FirstName {get; set;}

    [Required]
    public string LastName {get; set;}

    [Required]
    public DateTime DateOfBirth {get; set;}

    [Required]
    public DateTime RegisteredOn {get; set;}
    
    public virtual List<BankAccount> Accounts {get; set;} = new List<BankAccount>();
}