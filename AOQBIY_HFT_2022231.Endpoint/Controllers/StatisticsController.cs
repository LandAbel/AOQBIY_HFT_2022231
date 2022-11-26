using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static AOQBIY_HFT_2022231.Logic.Classes.ProcessorLogic;

namespace AOQBIY_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        IProcessorLogic prolog; 
        public StatisticsController(IProcessorLogic prolog)
        {
            this.prolog = prolog;
        }
        [HttpGet]
        public IEnumerable<Processor> z790ProcessorsWith10Core()
        {
            return this.prolog.z790ProcessorsWith10Core();
        }
        [HttpGet]
        public IEnumerable<Processor> INTELProcessorsWithMorethan30mbCache()
        {
            return this.prolog.INTELProcessorsWithMorethan30mbCache();
        }
        [HttpGet]
        public IEnumerable<Processor> INTELProcessorsWithIntegratedGraph()
        {
            return this.prolog.INTELProcessorsWithIntegratedGraph();
        }
        [HttpGet]
        public IEnumerable<Processor> MaxTurboFreqMoreThen49ProcessorFromAMD()
        {
            return this.prolog.MaxTurboFreqMoreThen49ProcessorFromAMD();
        }
        [HttpGet]
        public IEnumerable<Processor> MobileProcessorsWithMoreThan6Core()
        {
            return this.prolog.MobileProcessorsWithMoreThan6Core();
        }
        [HttpGet]
        public IEnumerable<Processor> IntelProcessorsWithMoreTh30Threads()
        {
            return this.prolog.IntelProcessorsWithMoreTh30Threads();
        }
        [HttpGet]
        public IEnumerable<Processor.ProcessorInfo> ProcessorsByBrands()
        {
            return this.prolog.ProcessorsByBrands();
        }

    }
}
