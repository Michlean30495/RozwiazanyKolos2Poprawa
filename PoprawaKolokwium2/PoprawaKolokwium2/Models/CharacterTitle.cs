using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoprawaKolokwium2.Models;

public class CharacterTitle
{
    [Key, Column(Order = 0)]
    public int CharacterId { get; set; }
    
    [ForeignKey("CharacterId")]
    public Character Character { get; set; }
    
    [Key, Column(Order = 1)]
    public int TitleId { get; set; }
    
    [ForeignKey("TitleId")]
    public Title Title { get; set; }
    
    [Required]
    public DateTime AcquiredAt { get; set; }
}