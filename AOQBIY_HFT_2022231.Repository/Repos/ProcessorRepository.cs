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
    public class ProcessorRepository:Repository<Processor>, IRepository<Processor>
    {
        public ProcessorRepository(ProcessorListDbContext ctx) : base(ctx)
        {
        }

        public override Processor Read(int id)
        {
            return ctx.Processors.FirstOrDefault(t => t.ProcessorId == id);
        }

        public override void Update(Processor item)
        {
            var old = Read(item.ProcessorId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
