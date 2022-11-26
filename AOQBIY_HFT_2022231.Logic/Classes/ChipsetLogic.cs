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
    public class ChipsetLogic : IChipsetLogic
    {
        IRepository<Chipsets> repository;
        public ChipsetLogic(IRepository<Chipsets> repo)
        {
            this.repository = repo;
        }
        public void Create(Chipsets item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Chipsets Read(int id)
        {
            var chip = repository.Read(id);
            if (chip == null)
            {
                throw new ArgumentException("****There is no sudc chipset!****");
            }
            return chip;
        }

        public IEnumerable<Chipsets> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Chipsets item)
        {
            this.repository.Update(item);
        }
    }
}
