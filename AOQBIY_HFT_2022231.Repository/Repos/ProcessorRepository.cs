using AOQBIY_HFT_2022231.Models;
using AOQBIY_HFT_2022231.Repository.Data;
using AOQBIY_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Repository.Repos
{
    public class ProcessorRepository:Repository<Processor>, IProcessorRepository
    {
        public ProcessorRepository(ProcessorListDbContext ctx) : base(ctx)
        {
        }
        public void UpdateMaxTurboFrequency(int id, int newMaxFreq)
        {
            Processor old = Read(id);
            old.MaxTurboFrequency = newMaxFreq;
            ctx.SaveChanges();
        }
    }
}
