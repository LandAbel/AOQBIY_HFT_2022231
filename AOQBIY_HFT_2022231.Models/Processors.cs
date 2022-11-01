using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Models
{
    [Table("Processor")]
    public class Processor:Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("processor_id", TypeName = "int")]
        public override int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [NotNull]
        public double PerformanceCores { get; set; }

        public double EfficencyCores { get; set; }

        [NotNull]
        public int TotalThreads { get; set; }

        [NotNull]
        public double MaxTurboFrequency { get; set; }

        public int Cache { get; set; }

        [NotNull]
        public bool IntegratedGraphics { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public override bool Equals(object obj)
        {
            Processor b = obj as Processor;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Id == b.Id && this.Name == b.Name;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Name);
        }
    }
}
