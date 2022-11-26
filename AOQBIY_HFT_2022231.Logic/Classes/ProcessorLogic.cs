using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using AOQBIY_HFT_2022231.Repository.Interfaces;
using AOQBIY_HFT_2022231.Repository.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Logic.Classes
{
    public class ProcessorLogic : IProcessorLogic
    {
        IRepository<Processor> repository;
        public ProcessorLogic(IRepository<Processor> repo)
        {
            this.repository = repo;
        }

        public void Create(Processor item)
        {
            if (item.Name.Length < 4)
            {
                throw new ArgumentException("This name is too short");
            }
            repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Processor Read(int id)
        {
            var proc = repository.Read(id);
            if (proc == null)
            {
                throw new ArgumentException("****There is no sudc processor!****");
            }
            return proc;
        }

        public IEnumerable<Processor> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Processor item)
        {
            this.repository.Update(item);
        }
        //non-cruds
        public IEnumerable<Processor> z790ProcessorsWith10Core()
        {
            return from x in this.repository.ReadAll()
                     where x.Chipset.Name.Equals("Z790") && (x.PerformanceCores + x.EfficencyCores) > 10
                     select new Processor()
                     {
                         BrandId = x.BrandId,
                         Name = x.Name,
                         PerformanceCores = x.PerformanceCores,
                         EfficencyCores = x.EfficencyCores,
                         IntegratedGraphics=x.IntegratedGraphics,
                         MaxTurboFrequency=x.MaxTurboFrequency,
                         Cache=x.Cache,
                         TotalThreads=x.TotalThreads,
                     };
        }
        public IEnumerable<Processor> INTELProcessorsWithMorethan30mbCache()
        {
            return from x in this.repository.ReadAll()
                   where x.Brand.Name.Equals("INTEL") && x.Cache >= 30
                   select new Processor()
                   {
                       BrandId = x.BrandId,
                       Name = x.Name,
                       PerformanceCores = x.PerformanceCores,
                       EfficencyCores = x.EfficencyCores,
                       IntegratedGraphics = x.IntegratedGraphics,
                       MaxTurboFrequency = x.MaxTurboFrequency,
                       Cache = x.Cache,
                       TotalThreads = x.TotalThreads,
                   };
        }
        public IEnumerable<Processor> INTELProcessorsWithIntegratedGraph()
        {
            return from x in this.repository.ReadAll()
                   where x.Brand.Name.Equals("INTEL") && x.IntegratedGraphics == true
                   select new Processor()
                   {
                       BrandId = x.BrandId,
                       Name = x.Name,
                       PerformanceCores = x.PerformanceCores,
                       EfficencyCores = x.EfficencyCores,
                       IntegratedGraphics = x.IntegratedGraphics,
                       MaxTurboFrequency = x.MaxTurboFrequency,
                       Cache = x.Cache,
                       TotalThreads = x.TotalThreads,

                   };
        }
        public IEnumerable<Processor> MaxTurboFreqMoreThen49ProcessorFromAMD()
        {
            return from x in this.repository.ReadAll()
                   where x.Brand.Name.Equals("AMD") && x.MaxTurboFrequency >= 4.9
                   select new Processor()
                   {
                       BrandId = x.BrandId,
                       Name = x.Name,
                       PerformanceCores = x.PerformanceCores,
                       EfficencyCores = x.EfficencyCores,
                       IntegratedGraphics = x.IntegratedGraphics,
                       MaxTurboFrequency = x.MaxTurboFrequency,
                       Cache = x.Cache,
                       TotalThreads = x.TotalThreads,

                   };
        }
        public IEnumerable<Processor> MobileProcessorsWithMoreThan6Core()
        {
            return from x in this.repository.ReadAll()
                   where x.Brand.Name.Equals("QUALCOMM") && x.PerformanceCores > 6
                   select new Processor()
                   {
                       BrandId = x.BrandId,
                       Name = x.Name,
                       PerformanceCores = x.PerformanceCores,
                       EfficencyCores = x.EfficencyCores,
                       IntegratedGraphics = x.IntegratedGraphics,
                       MaxTurboFrequency = x.MaxTurboFrequency,
                       Cache = x.Cache,
                       TotalThreads = x.TotalThreads,
                   };
        }
        public IEnumerable<Processor> IntelProcessorsWithMoreTh30Threads()
        {
            return from x in this.repository.ReadAll()
                   where x.Brand.Name.Equals("INTEL") && x.TotalThreads > 30
                   select new Processor()
                   {
                       BrandId = x.BrandId,
                       Name = x.Name,
                       PerformanceCores = x.PerformanceCores,
                       EfficencyCores = x.EfficencyCores,
                       IntegratedGraphics = x.IntegratedGraphics,
                       MaxTurboFrequency = x.MaxTurboFrequency,
                       Cache = x.Cache,
                       TotalThreads = x.TotalThreads,
                   };
        }
        public IEnumerable<Processor.ProcessorInfo> ProcessorsByBrands()
        {
            return from x in this.repository.ReadAll()
                   group x by x.Brand.Name into g
                   select new Processor.ProcessorInfo()
                   {
                       Brand = g.Key.ToString(),
                       Number = g.Count(),
                       AvgCore = g.Average(t => t.PerformanceCores + t.EfficencyCores)
                   };
        }
    }
}
