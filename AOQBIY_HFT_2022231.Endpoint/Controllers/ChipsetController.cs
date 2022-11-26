using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AOQBIY_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChipsetController : ControllerBase
    {
        IChipsetLogic chiplog;

        public ChipsetController(IChipsetLogic chiplog)
        {
            this.chiplog = chiplog;
        }

        [HttpGet]
        public IEnumerable<Chipsets> ReadAll()
        {
            return this.chiplog.ReadAll();
        }
        [HttpGet("{id}")]
        public Chipsets Read(int id)
        {
            return this.chiplog.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Chipsets c)
        {
            this.chiplog.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Chipsets c)
        {
            this.chiplog.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.chiplog.Delete(id);
        }
    }
}
