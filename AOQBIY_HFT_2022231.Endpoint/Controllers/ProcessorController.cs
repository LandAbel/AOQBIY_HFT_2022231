using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AOQBIY_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        IProcessorLogic prolog;

        public ProcessorController(IProcessorLogic prolog)
        {
            this.prolog = prolog;
        }

        [HttpGet]
        public IEnumerable<Processor> ReadAll()
        {
            return this.prolog.ReadAll();
        }
        [HttpGet("{id}")]
        public Processor Read(int id)
        {
            return this.prolog.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Processor c)
        {
            this.prolog.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Processor c)
        {
            this.prolog.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.prolog.Delete(id);
        }

    }
}
