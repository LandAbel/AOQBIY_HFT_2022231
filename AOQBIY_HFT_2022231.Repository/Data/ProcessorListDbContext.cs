using AOQBIY_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Repository.Data
{
    public partial class ProcessorListDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Processor> Processors { get; set; }
        public virtual DbSet<Chipsets> Chipsets { get; set; }

        public ProcessorListDbContext()
        {
            this.Database.EnsureCreated();
        }

        public ProcessorListDbContext(DbContextOptions<ProcessorListDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("processorlistdb")
                    .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processor>(entity =>
            {
                entity.HasOne(processor => processor.Brand)
                    .WithMany(brand => brand.Processors)
                    .HasForeignKey(processor => processor.BrandId) 
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Processor>(entity =>
            {
                entity.HasOne(proc => proc.Chipset)
                .WithMany(chipset => chipset.Processors)
                .HasForeignKey(processor => processor.ChipsetId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            //Adattal való feltöltés
            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand() {BrandId=1,Name= "INTEL" },
                new Brand() { BrandId = 2, Name = "AMD" },
                new Brand() { BrandId = 3, Name = "QUALCOMM" },

            });
            modelBuilder.Entity<Chipsets>().HasData(new Chipsets[]
            {
                new Chipsets() { ChipsetId = 1, Name = "Z790" },
                new Chipsets() { ChipsetId = 2, Name = "Z690" },
                new Chipsets() { ChipsetId = 3, Name = "Z590" },
                new Chipsets() { ChipsetId = 4, Name = "Z490" },
                new Chipsets() { ChipsetId = 5, Name = "Z390" },
                new Chipsets() { ChipsetId = 6, Name = "Z270" },
                new Chipsets() { ChipsetId = 7, Name = "Z170" },
                new Chipsets() { ChipsetId = 8, Name = "AM4" },
                new Chipsets() { ChipsetId = 9, Name = "AM5" },
                new Chipsets() { ChipsetId = 10, Name = "Mobile" },

            });
            modelBuilder.Entity<Processor>().HasData(new Processor[] 
            {
                new Processor() {ProcessorId =1, BrandId=1,ChipsetId=1, PerformanceCores=8,EfficencyCores=16,TotalThreads=32,MaxTurboFrequency=5.8,Cache=36,IntegratedGraphics=true,Name= "Intel Core i9-13900K"},
                new Processor() { ProcessorId = 2, BrandId = 1, ChipsetId = 2, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.5, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-12900KS" },
                new Processor() { ProcessorId = 3, BrandId = 1, ChipsetId = 3, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5.2, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-11900K" },
                new Processor() { ProcessorId = 4, BrandId = 1, ChipsetId = 4, PerformanceCores = 10, EfficencyCores = 0, TotalThreads = 20, MaxTurboFrequency = 5.3, Cache = 20, IntegratedGraphics = true, Name = "Intel Core i9-10900K" },
                new Processor() { ProcessorId = 5, BrandId = 1, ChipsetId = 5, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-9900K" },
                new Processor() { ProcessorId = 6, BrandId = 1, ChipsetId = 5, PerformanceCores = 6, EfficencyCores = 0, TotalThreads = 12, MaxTurboFrequency = 4.8, Cache = 12, IntegratedGraphics = true, Name = "Intel Core i9-8950HK" },
                new Processor() { ProcessorId = 7, BrandId = 1, ChipsetId = 1, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-13700K" },
                new Processor() { ProcessorId = 8, BrandId = 1, ChipsetId = 2, PerformanceCores = 8, EfficencyCores = 4, TotalThreads = 20, MaxTurboFrequency = 5.0, Cache = 25, IntegratedGraphics = true, Name = "Intel Core i9-12700K" },
                new Processor() { ProcessorId = 9, BrandId = 1, ChipsetId = 3, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5.0, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-11700K" },
                new Processor() { ProcessorId = 10, BrandId = 1, ChipsetId = 4, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5.1, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-10700K" },
                new Processor() { ProcessorId = 11, BrandId = 1, ChipsetId = 6, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 8, MaxTurboFrequency = 4.9, Cache = 12, IntegratedGraphics = true, Name = "Intel Core i7-9700K" },
                new Processor() { ProcessorId = 12, BrandId = 1, ChipsetId = 6, PerformanceCores = 6, EfficencyCores = 0, TotalThreads = 12, MaxTurboFrequency = 4.7, Cache = 12, IntegratedGraphics = true, Name = "Intel Core i7-8700K" },
                new Processor() { ProcessorId = 13, BrandId = 1, ChipsetId = 1, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = false, Name = "Intel Core i9-13700KF" },
                new Processor() { ProcessorId = 14, BrandId = 1, ChipsetId = 2, PerformanceCores = 8, EfficencyCores = 4, TotalThreads = 20, MaxTurboFrequency = 5.0, Cache = 25, IntegratedGraphics = false, Name = "Intel Core i9-12700KF" }, 
                new Processor() { ProcessorId = 15, BrandId = 2, ChipsetId = 8, PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 4.9, Cache = 72, IntegratedGraphics = false, Name = "AMD Ryzen 9 5950X" },
                new Processor() { ProcessorId = 16, BrandId = 2, ChipsetId = 9, PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.7, Cache = 81, IntegratedGraphics = false, Name = "AMD Ryzen 9 7950X" },
                new Processor() { ProcessorId = 17, BrandId = 2, ChipsetId = 8, PerformanceCores = 10, TotalThreads = 20, MaxTurboFrequency = 4.7, Cache = 60, IntegratedGraphics = false, Name = "AMD Ryzen 7 5750X" },
                new Processor() { ProcessorId = 18, BrandId = 3, ChipsetId = 10, PerformanceCores = 8, TotalThreads = 8, MaxTurboFrequency = 2.84, Cache = 6.8, IntegratedGraphics = true, Name = "Snapdragon 865 5G" },
            });
        }
    }
}
