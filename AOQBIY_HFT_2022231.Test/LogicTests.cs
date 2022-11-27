using AOQBIY_HFT_2022231.Logic.Classes;
using AOQBIY_HFT_2022231.Models;
using AOQBIY_HFT_2022231.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static AOQBIY_HFT_2022231.Logic.Classes.ProcessorLogic;

namespace AOQBIY_HFT_2022231.Test
{
    [TestFixture]
    public class LogicTests
    {
        ProcessorLogic ProLogic;
        BrandLogic BrandLogic;
        ChipsetLogic ChipsetLogic;
        Mock<IRepository<Processor>> mockProcRepo;
        Mock<IRepository<Brand>> mockBrandRepo;
        Mock<IRepository<Chipsets>> mockChipsetsRepo;

        [SetUp]
        public void Initialize()
        {
            Brand AMD = new Brand() { BrandId = 2, Name = "AMD" };
            Brand INTEL = new Brand() { BrandId = 1, Name = "INTEL" };
            Brand QUALCOMM = new Brand() { BrandId = 3, Name = "QUALCOMM" };
            var brands = new List<Brand>() { INTEL, AMD, QUALCOMM }.AsQueryable(); 

            Chipsets Z790 = new Chipsets() {ChipsetId = 1, Name = "Z790" };
            Chipsets Z690 = new Chipsets() { ChipsetId = 2, Name = "Z690" };
            Chipsets AM4 = new Chipsets() { ChipsetId = 8, Name = "AM4" };
            Chipsets AM5 = new Chipsets() { ChipsetId = 9, Name = "AM5" };
            Chipsets Mobile = new Chipsets() { ChipsetId = 10, Name = "Mobile" };

            var chipsets = new List<Chipsets>()
            {
                Z790,
                Z690,
                AM5,
                AM4,
                Mobile
            }.AsQueryable();
            var processors = new List<Processor>()
            {
                new Processor() { ProcessorId = 1,Brand=INTEL, BrandId = INTEL.BrandId, Chipset=Z790,ChipsetId = Z790.ChipsetId, PerformanceCores = 8, EfficencyCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.8, Cache = 36, IntegratedGraphics = true, Name = "Intel Core i9-13900K" },
                new Processor() { ProcessorId = 2, Brand=INTEL,BrandId = INTEL.BrandId,Chipset=Z690, ChipsetId = Z690.ChipsetId, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.5, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-12900KS Processor" },
                new Processor() { ProcessorId = 3, Brand=INTEL,BrandId = INTEL.BrandId,Chipset=Z790, ChipsetId = Z790.ChipsetId, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-13700K" },
                new Processor() { ProcessorId = 4,Brand=INTEL, BrandId = INTEL.BrandId,Chipset=Z690, ChipsetId = Z690.ChipsetId, PerformanceCores = 8, EfficencyCores = 4, TotalThreads = 20, MaxTurboFrequency = 5.0, Cache = 25, IntegratedGraphics = true, Name = "Intel Core i9-12700K Processor" },
                new Processor() { ProcessorId =5, Brand=INTEL,BrandId = INTEL.BrandId,Chipset=Z790, ChipsetId = Z790.ChipsetId, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = false, Name = "Intel Core i9-13700KF" },
                new Processor() { ProcessorId = 6,Brand=AMD, BrandId = AMD.BrandId,Chipset=AM4, ChipsetId = AM4.ChipsetId, PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 4.9, Cache = 72, IntegratedGraphics = false, Name = "AMD Ryzen 9 5950X" },
                new Processor() { ProcessorId = 7,Brand=AMD, BrandId = AMD.BrandId,Chipset=AM5, ChipsetId = AM5.ChipsetId, PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.7, Cache = 81, IntegratedGraphics = false, Name = "AMD Ryzen 9 7950X" },
                new Processor() { ProcessorId = 8,Brand=AMD, BrandId = AMD.BrandId,Chipset=AM4, ChipsetId = AM4.ChipsetId, PerformanceCores = 10, TotalThreads = 20, MaxTurboFrequency = 4.7, Cache = 60, IntegratedGraphics = false, Name = "AMD Ryzen 7 5750X" },
                new Processor() { ProcessorId = 9, Brand=QUALCOMM,BrandId = QUALCOMM.BrandId,Chipset=Mobile, ChipsetId = Mobile.ChipsetId, PerformanceCores = 8, TotalThreads = 8, MaxTurboFrequency = 2.84, Cache = 6.8, IntegratedGraphics = true, Name = "Snapdragon 865 5G" },
            }.AsQueryable();

            mockProcRepo = new Mock<IRepository<Processor>>();
            mockProcRepo.Setup(x => x.ReadAll()).Returns(processors);
            ProLogic = new ProcessorLogic(mockProcRepo.Object);

            mockBrandRepo = new Mock<IRepository<Brand>>();
            mockBrandRepo.Setup(x => x.ReadAll()).Returns(brands);
            BrandLogic = new BrandLogic(mockBrandRepo.Object);

            mockChipsetsRepo = new Mock<IRepository<Chipsets>>();
            mockChipsetsRepo.Setup(x => x.ReadAll()).Returns(chipsets);
            ChipsetLogic = new ChipsetLogic(mockChipsetsRepo.Object);
        }

        [Test]
        public void z790ProcessorsWith10CoreTEST()
        {
            var result = ProLogic.z790ProcessorsWith10Core();
            var expected = new List<Processor>()
            {
                new Processor() { BrandId=1,ChipsetId=1,ProcessorId = 1, PerformanceCores = 8, EfficencyCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.8, Cache = 36, IntegratedGraphics = true, Name = "Intel Core i9-13900K" },
                new Processor() { BrandId=1,ChipsetId=1,ProcessorId = 3, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-13700K" },
                new Processor() { BrandId=1,ChipsetId=1,ProcessorId =5, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = false, Name = "Intel Core i9-13700KF" },
            }.AsQueryable();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void INTELProcessorsWithMorethan30mbCacheTEST()
        {
            var result=ProLogic.INTELProcessorsWithMorethan30mbCache();
            var expected = new List<Processor>()
            {
                new Processor() {BrandId=1,ChipsetId=1, ProcessorId = 1, PerformanceCores = 8, EfficencyCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.8, Cache = 36, IntegratedGraphics = true, Name = "Intel Core i9-13900K" },
                new Processor() { BrandId=1,ChipsetId = 2, ProcessorId = 2,PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.5, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-12900KS Processor" },
                new Processor() { BrandId=1,ChipsetId = 1, ProcessorId = 3, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-13700K" },
                new Processor() { BrandId=1,ChipsetId = 1, ProcessorId = 5, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = false, Name = "Intel Core i9-13700KF" },
            }.AsQueryable();
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void INTELProcessorsWithIntegratedGraph()
        {
            var result=ProLogic.INTELProcessorsWithIntegratedGraph();
            var expected = new List<Processor>()
            {
                new Processor() {BrandId=1, ChipsetId = 1, ProcessorId = 1, PerformanceCores = 8, EfficencyCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.8, Cache = 36, IntegratedGraphics = true, Name = "Intel Core i9-13900K" },
                new Processor() { BrandId=1,ChipsetId = 2, ProcessorId = 2,PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.5, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-12900KS Processor" },
                new Processor() { BrandId=1,ChipsetId = 1, ProcessorId = 3, PerformanceCores = 8, EfficencyCores = 8, TotalThreads = 24, MaxTurboFrequency = 5.4, Cache = 30, IntegratedGraphics = true, Name = "Intel Core i9-13700K" },
                new Processor() { BrandId = 1,ChipsetId = 2, ProcessorId=4,PerformanceCores = 8, EfficencyCores = 4, TotalThreads = 20, MaxTurboFrequency = 5.0, Cache = 25, IntegratedGraphics = true, Name = "Intel Core i9-12700K Processor" },
            }.AsQueryable();
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void MaxTurboFreqMoreThen49ProcessorFromAMDTEST()
        {
            var result = ProLogic.MaxTurboFreqMoreThen49ProcessorFromAMD();
            var expected = new List<Processor>()
            {
                new Processor() { ProcessorId = 6,ChipsetId=8,BrandId=2,PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 4.9, Cache = 72, IntegratedGraphics = false, Name = "AMD Ryzen 9 5950X" },
                new Processor() { ProcessorId = 7,ChipsetId=9,BrandId=2,PerformanceCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.7, Cache = 81, IntegratedGraphics = false, Name = "AMD Ryzen 9 7950X" },
            }.AsQueryable();
            ;
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void MobileProcessorsWithMoreThan6CoreTEST()
        {
            var result = ProLogic.MobileProcessorsWithMoreThan6Core();
            var expected = new List<Processor>()
            {
                new Processor() { ProcessorId = 9,ChipsetId=10, BrandId = 3, PerformanceCores = 8, TotalThreads = 8, MaxTurboFrequency = 2.84, Cache = 6.8, IntegratedGraphics = true, Name = "Snapdragon 865 5G" },
            };
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void IntelProcessorsWithMoreTh30ThreadsTEST()
        {
            var result = ProLogic.IntelProcessorsWithMoreTh30Threads();
            var expected = new List<Processor>()
            {
                new Processor() { BrandId=1,ProcessorId = 1,ChipsetId=1, PerformanceCores = 8, EfficencyCores = 16, TotalThreads = 32, MaxTurboFrequency = 5.8, Cache = 36, IntegratedGraphics = true, Name = "Intel Core i9-13900K" },
            };
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void CreateProcessorCorectTEST()
        {
            var proc = new Processor() { Name = "Intel14gen" ,PerformanceCores=5,TotalThreads=10,MaxTurboFrequency=2.0, IntegratedGraphics=false};
            ProLogic.Create(proc);
            mockProcRepo.Verify(x=>x.Create(proc),Times.Once());
        }
        [Test]
        public void CreateProcessorInCorectTEST()
        {
            var proc = new Processor() { Name = "0" };
            try
            {
                ProLogic.Create(proc);
            }
            catch
            {
            }
            mockProcRepo.Verify(t => t.Create(proc), Times.Never);
        }
        [Test]
        public void CreateProcessorNullTEST()
        {
            var proc = new Processor();
            try
            {
                ProLogic.Create(proc);
            }
            catch
            {
            }
            Assert.That(() => ProLogic.Create(proc), Throws.TypeOf<NullReferenceException>());
        }
        [Test]
        public void DeleteTEST()
        {
            ProLogic.Delete(1);
            mockProcRepo.Verify(t => t.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void ReadWithCorrextIDTEST()
        {
            Processor expected = new Processor() { ProcessorId=44,Name = "Intel14gen", PerformanceCores = 5, TotalThreads = 10, MaxTurboFrequency = 2.0, IntegratedGraphics = false };
            mockProcRepo.Setup(t => t.Read(44)).Returns(expected);
            var result=ProLogic.Read(44);
            Assert.AreEqual(expected, result);

        }
        [Test]
        public void ByBrandTEST()
        {
            var result = ProLogic.ProcessorsByBrands();
            var expected = new List<Processor.ProcessorInfo>()
            {
                new Processor.ProcessorInfo() { Brand="INTEL", AvgCore=16.8, Number=5 },
                new Processor.ProcessorInfo() {Brand="AMD", AvgCore=14,Number=3},
                new Processor.ProcessorInfo(){Brand="QUALCOMM", AvgCore=8,Number=1},
            };
            Assert.AreEqual(result, expected);
        }
    }

}
