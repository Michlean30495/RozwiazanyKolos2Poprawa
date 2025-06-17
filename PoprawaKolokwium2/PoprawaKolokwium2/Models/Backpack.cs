using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoprawaKolokwium2.Models;

public class Backpack
{
    [Key, Column(Order = 0)]
    public int CharacterId { get; set; }
    
    [ForeignKey("CharacterId")]
    public Character Character { get; set; }
    
    [Key, Column(Order = 1)]
    public int ItemId { get; set; }
    
    [ForeignKey("ItemId")]
    public Item Item { get; set; }
    
    [Required]
    public int Amount { get; set; }
}