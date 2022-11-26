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
    public class Chipsets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChipsetId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Processor> Processors { get; set; }

        public Chipsets()
        {
            this.Processors = new HashSet<Processor>();
        }

/*        [ForeignKey(nameof(Processor))]
        public int ProcessorId { get; set; }*/

    }
}
