using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinCollection.Models
{
    [Table("coins")]
    public class Coin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("year")]
        public int Year { get; set; }

        [Required]
        [Column("country")]
        public string Country { get; set; }

        [Required]
        [Column("nominal")]
        public string Nominal { get; set; }

        [Required]
        [Column("condition")]
        public string Condition { get; set; }

        public string DisplayString => $"Id: {Id} Рік: {Year} Країна: {Country} Номінал: {Nominal} Стан: {Condition}";
    }
}