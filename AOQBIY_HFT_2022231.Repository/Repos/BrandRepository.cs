using AOQBIY_HFT_2022231.Models;
using AOQBIY_HFT_2022231.Repository.Data;
using AOQBIY_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Repository.Repos
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(ProcessorListDbContext ctx) : base(ctx)
        {
        }
    }
}
