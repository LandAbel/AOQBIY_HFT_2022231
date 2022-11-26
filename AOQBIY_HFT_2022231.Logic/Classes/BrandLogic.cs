using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using AOQBIY_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Logic.Classes
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repository;
        public BrandLogic(IRepository<Brand> rep)
        {
            this.repository = rep;
        }
        public void Create(Brand item)
        {
            this.repository.Create(item);
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Brand Read(int id)
        {
            var brand=repository.Read(id);
            if (brand==null)
            {
                throw new ArgumentException("****There is no such brand!****");
            }
            return brand;
        }

        public IEnumerable<Brand> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Brand item)
        {
            this.repository.Update(item);
        }
    }
}
