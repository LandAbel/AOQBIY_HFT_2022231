using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Models
{
    [Table("Chipset")]
    public class Chipsets:Entity
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual Processor Processor { get; set; }

        [ForeignKey(nameof(Processor))]
        public int ProcessorId { get; set; }

    }
}
