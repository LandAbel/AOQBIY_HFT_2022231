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

            Brand AMD = new Brand() {BrandId=1,Name= "AMD" };
            Brand INTEL = new Brand() { BrandId = 2,Name = "INTEL" };
            Brand QUALCOMM = new Brand() { BrandId = 3, Name = "QUALCOMM"};
            Chipsets Z790 = new Chipsets() { ChipsetId = 1, Name = "Z790" };
            Chipsets Z690 = new Chipsets() { ChipsetId = 2, Name = "Z690" };
            Chipsets Z590 = new Chipsets() { ChipsetId = 3, Name = "Z590" };
            Chipsets Z490 = new Chipsets() { ChipsetId = 4, Name = "Z490" };
            Chipsets Z390 = new Chipsets() { ChipsetId = 5, Name = "Z390" };
            Chipsets Z270 = new Chipsets() { ChipsetId = 6, Name = "Z270" };
            Chipsets Z170 = new Chipsets() { ChipsetId = 7, Name = "Z170" };
            Chipsets AM4 = new Chipsets() { ChipsetId = 8, Name = "AM4" };
            Chipsets AM5 = new Chipsets() { ChipsetId = 9, Name = "AM5" };
            Chipsets Mobile = new Chipsets() { ChipsetId = 10, Name = "Mobile" };
            Processor i9k13th=new Processor() {ProcessorId =1, BrandId=INTEL.BrandId,ChipsetId=Z790.ChipsetId, PerformanceCores=8,EfficencyCores=16,TotalThreads=32,MaxTurboFrequency=5.8,Cache=36,IntegratedGraphics=true,Name= "Intel Core i9-13900K"};
            Processor i9ks12th = new Processor() { ProcessorId = 2, BrandId = INTEL.BrandId, ChipsetId = Z690.ChipsetId, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.5, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-12900KS Processor" };
            Processor i9k11th = new Processor() { ProcessorId = 3, BrandId = INTEL.BrandId, ChipsetId = Z590.ChipsetId, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5.2, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-11900K" };
            Processor i9k10th = new Processor() { ProcessorId = 4, BrandId = INTEL.BrandId, ChipsetId = Z490.ChipsetId, PerformanceCores = 10, EfficencyCores = 0, TotalThreads = 20, MaxTurboFrequency = 5.3, Cache = 20, IntegratedGraphics = true, Name = "Intel Core i9-10900K Processor" };
            Processor i9k9th = new Processor() { ProcessorId = 5, BrandId = INTEL.BrandId, ChipsetId = Z390.ChipsetId, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-9900K" };
            Processor i9k8th = new Processor() { ProcessorId = 6, BrandId = INTEL.BrandId, ChipsetId = Z390.ChipsetId, PerformanceCores = 6, EfficencyCores = 0, TotalThreads = 12, MaxTurboFrequency = 4.8, Cache = 12, IntegratedGraphics = true, Name = "Intel Core i9-8950HK Processor" };
            Processor i7k13th = new Processor() { ProcessorId = 7, BrandId = INTEL.BrandId, ChipsetId = Z790.ChipsetId, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-13700K" };
            Processor i7k12th = new Processor() { ProcessorId = 8, BrandId = INTEL.BrandId, ChipsetId = Z690.ChipsetId, PerformanceCores = 8, EfficencyCores = 4, TotalThreads = 20, MaxTurboFrequency = 5.0, Cache = 25, IntegratedGraphics = true, Name = "Intel Core i9-12700K Processor" };
            Processor i7k11th = new Processor() { ProcessorId = 9, BrandId = INTEL.BrandId, ChipsetId = Z590.ChipsetId, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5.0, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-11700K" };
            Processor i7k10th = new Processor() { ProcessorId = 10, BrandId = INTEL.BrandId, ChipsetId = Z490.ChipsetId, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 16, MaxTurboFrequency = 5.1, Cache = 16, IntegratedGraphics = true, Name = "Intel Core i9-10700K Processor" };
            Processor i7k9th = new Processor() { ProcessorId = 11, BrandId = INTEL.BrandId, ChipsetId = Z270.ChipsetId, PerformanceCores = 8, EfficencyCores = 0, TotalThreads = 8, MaxTurboFrequency = 4.9, Cache = 12, IntegratedGraphics = true, Name = "Intel Core i7-9700K" };
            Processor i7k8th = new Processor() { ProcessorId = 12, BrandId = INTEL.BrandId, ChipsetId = Z270.ChipsetId, PerformanceCores = 6, EfficencyCores = 0, TotalThreads = 12, MaxTurboFrequency = 4.7, Cache = 12, IntegratedGraphics = true, Name = "Intel Core i7-8700K Processor" };
            Processor ryzen9gen3 = new Processor() { ProcessorId = 13, BrandId = AMD.BrandId, ChipsetId=AM4.ChipsetId, PerformanceCores =16, TotalThreads = 32, MaxTurboFrequency = 4.9, Cache = 72, IntegratedGraphics = false, Name = "AMD Ryzen 9 5950X" };
            Processor ryzen9gen4 = new Processor() { ProcessorId = 14, BrandId = AMD.BrandId, ChipsetId = AM5.ChipsetId, PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.7, Cache = 81, IntegratedGraphics = false, Name = "AMD Ryzen 9 7950X" };
            Processor ryzen7gen3 = new Processor() { ProcessorId = 15, BrandId = AMD.BrandId, ChipsetId = AM4.ChipsetId, PerformanceCores = 10, TotalThreads = 20, MaxTurboFrequency = 4.7, Cache = 60, IntegratedGraphics = false, Name = "AMD Ryzen 7 5750X" };
            Processor Snapdragon = new Processor() { ProcessorId = 16, BrandId = QUALCOMM.BrandId,ChipsetId=Mobile.ChipsetId, PerformanceCores = 8,TotalThreads = 8, MaxTurboFrequency = 2.84, Cache = 6.8, IntegratedGraphics = true, Name = "Snapdragon 865 5G" };

            // Adatok feltöltése a táblába.
            modelBuilder.Entity<Brand>().HasData(AMD, INTEL, QUALCOMM);
            modelBuilder.Entity<Processor>().HasData(i9k13th, i9ks12th, i9k11th, i9k9th, i9k8th, i7k13th, i7k12th, i7k11th, i7k9th, i7k8th, ryzen9gen4, ryzen9gen3, Snapdragon);
            modelBuilder.Entity<Chipsets>().HasData(Z790,Z690,AM4,AM5,Mobile);
        }
    }
}
