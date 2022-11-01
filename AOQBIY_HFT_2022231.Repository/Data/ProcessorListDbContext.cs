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
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Chipsets>(entity =>
            {
                entity.HasOne(chipsets => chipsets.Processor)
                    .WithMany(processor => processor.Chipsets)
                    .HasForeignKey(chipsets => chipsets.ProcessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //Adattal való feltöltés

            Brand AMD = new Brand() {Id=1,Name= "AMD" };
            Brand INTEL = new Brand() {Id=2,Name = "INTEL" };
            Brand QUALCOMM = new Brand() {Id=3, Name = "QUALCOMM"};

            Processor i9k13th=new Processor() {Id=1, BrandId=INTEL.Id,PerformanceCores=8,EfficencyCores=16,TotalThreads=32,MaxTurboFrequency=5.8,Cache=36,IntegratedGraphics=true,Name= "Intel Core i9-13900K"};
            Processor i9ks12th = new Processor() { Id = 2, BrandId = INTEL.Id, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.5, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-12900KS Processor" };
            Processor ryzen9gen4 = new Processor() { Id = 3, BrandId = AMD.Id, PerformanceCores =16, TotalThreads = 32, MaxTurboFrequency = 4.9, Cache = 72, IntegratedGraphics = false, Name = "AMD Ryzen 9 5950X" };
            Processor ryzen9gen3 = new Processor() { Id = 4, BrandId = AMD.Id, PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.7, Cache = 81, IntegratedGraphics = false, Name = "AMD Ryzen 9 7950X" };
            Processor Snapdragon = new Processor() { Id = 5, BrandId = QUALCOMM.Id, PerformanceCores = 8,TotalThreads = 8, MaxTurboFrequency = 2.84, Cache = 6.8, IntegratedGraphics = true, Name = "Snapdragon 865 5G" };
            Chipsets Z790 = new Chipsets() {ProcessorId = i9k13th.Id, Name = "Z790"};
            Chipsets Z690 = new Chipsets() { ProcessorId = i9ks12th.Id, Name = "Z690" };
            Chipsets AM4 = new Chipsets() { ProcessorId = ryzen9gen3.Id, Name = "AM4" };
            Chipsets AM5 = new Chipsets() { ProcessorId = ryzen9gen4.Id, Name = "AM5" };
            Chipsets Mobile = new Chipsets() { ProcessorId = Snapdragon.Id, Name = "Mobile" };

            // Adatok feltöltése a táblába.
            modelBuilder.Entity<Brand>().HasData(AMD, INTEL, QUALCOMM);
            modelBuilder.Entity<Processor>().HasData(i9k13th, i9ks12th, ryzen9gen4, ryzen9gen3, Snapdragon);
            modelBuilder.Entity<Chipsets>().HasData(Z790,Z690,AM4,AM5,Mobile);
        }
    }
}
