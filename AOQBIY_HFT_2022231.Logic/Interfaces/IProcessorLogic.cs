using AOQBIY_HFT_2022231.Logic.Classes;
using AOQBIY_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace AOQBIY_HFT_2022231.Logic.Interfaces
{
    public interface IProcessorLogic
    {
        void Create(Processor item);
        void Delete(int id);
        IEnumerable<Processor> INTELProcessorsWithIntegratedGraph();
        IEnumerable<Processor> IntelProcessorsWithMoreTh30Threads();
        IEnumerable<Processor> INTELProcessorsWithMorethan30mbCache();
        IEnumerable<Processor> MaxTurboFreqMoreThen49ProcessorFromAMD();
        IEnumerable<Processor> MobileProcessorsWithMoreThan6Core();
        IEnumerable<Processor.ProcessorInfo> ProcessorsByBrands();
        Processor Read(int id);
        IEnumerable<Processor> ReadAll();
        void Update(Processor item);
        IEnumerable<Processor> z790ProcessorsWith10Core();
    }
}