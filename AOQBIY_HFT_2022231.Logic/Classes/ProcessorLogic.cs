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
    public class ProcessorLogic
    {
        IRepository<Processor> repository;
        public void Create(Processor item)
        {
            if (item.Name.Length<4)
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

        public IQueryable<Processor> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Processor item)
        {
            this.repository.Update(item);
        }
        //non-cruds
    }
}
