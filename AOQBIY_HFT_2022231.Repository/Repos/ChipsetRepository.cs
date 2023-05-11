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
    public class ChipsetRepository : Repository<Chipset>, IRepository<Chipset>
    {
        public ChipsetRepository(ProcessorListDbContext ctx) : base(ctx)
        {
        }

        public override Chipset Read(int id)
        {
            return ctx.Chipsets.FirstOrDefault(t => t.ChipsetId == id);
        }

        public override void Update(Chipset item)
        {
            var old = Read(item.ChipsetId);
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
