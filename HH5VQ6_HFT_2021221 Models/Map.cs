using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221_Models
{
    [Table("Maps")]
    public class Map
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MapId { get; set; }

        [Required]
        public string MapName { get; set; }
        public int Difficulty { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public Map()
        {
            Players = new HashSet<Player>();
        }
    }
}
