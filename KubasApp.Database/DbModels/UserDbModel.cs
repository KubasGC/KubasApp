using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KubasApp.Database.DbModels;

[Table("Users")]
public class UserDbModel
{
    [Key]
    public Guid Id { get; set; }
    
    [StringLength(255)]
    public string Username { get; set; }
    
    [StringLength(255)]
    public string PasswordHash { get; set; }
    
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [StringLength(50)]
    public string SecondName { get; set; }
    
    [StringLength(50)]
    public string LastName { get; set; }
    
    [StringLength(100)]
    public string EmailAddress { get; set; }
    
    public DateTime DateCreatedUtc { get; set; }
    
    public DateTime? DateDeletecUtc { get; set; }
}