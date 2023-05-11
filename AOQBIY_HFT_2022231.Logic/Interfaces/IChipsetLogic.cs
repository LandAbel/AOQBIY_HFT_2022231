using AOQBIY_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace AOQBIY_HFT_2022231.Logic.Interfaces
{
    public interface IChipsetLogic
    {
        void Create(Chipset item);
        void Delete(int id);
        Chipset Read(int id);
        IEnumerable<Chipset> ReadAll();
        void Update(Chipset item);
    }
}