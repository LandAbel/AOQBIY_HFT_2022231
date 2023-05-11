using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Models
{
    [Table("Processor")]
    public class Processor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("processor_id", TypeName = "int")]
        public int ProcessorId { get; set; }

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

        public double Cache { get; set; }

        [NotNull]
        public bool IntegratedGraphics { get; set; }

        [JsonIgnore]
        [NotMapped] 
        public virtual Brand Brand { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Chipset Chipset { get; set; }

        [ForeignKey(nameof(Chipset))]
        public int ChipsetId { get; set; }

        public override bool Equals(object obj)
        {
            Processor b = obj as Processor;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.ProcessorId == b.ProcessorId && this.Name == b.Name;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ProcessorId, this.Name);
        }
        public class ProcessorInfo
        {
            public string Brand { get; set; }
            public double AvgCore { get; set; }
            public int Number { get; set; }

            public override bool Equals(object obj)
            {
                ProcessorInfo b = obj as ProcessorInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Brand == b.Brand;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Brand, this.AvgCore, this.Number);
            }
        }
    }
}
