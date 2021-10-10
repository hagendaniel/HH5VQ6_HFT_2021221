﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221_Models
{
    [Table("Seasons")]
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeasonId { get; set; }
        
        [MaxLength(50)]
        public string SeasonNickname { get; set; }

        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }

        [NotMapped]
        public virtual Place Place { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public Season()
        {
            Players = new HashSet<Player>();
        }
    }
}