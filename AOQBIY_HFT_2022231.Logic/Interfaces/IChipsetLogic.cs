using AOQBIY_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace AOQBIY_HFT_2022231.Logic.Interfaces
{
    public interface IChipsetLogic
    {
        void Create(Chipsets item);
        void Delete(int id);
        Chipsets Read(int id);
        IEnumerable<Chipsets> ReadAll();
        void Update(Chipsets item);
    }
}