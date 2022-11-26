using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AOQBIY_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic brandlog;

        public BrandController(IBrandLogic brandlog)
        {
            this.brandlog = brandlog;
        }

        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.brandlog.ReadAll();
        }
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.brandlog.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand c)
        {
            this.brandlog.Create(c);
        }

        [HttpPut]
        public void Update([FromBody] Brand c)
        {
            this.brandlog.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.brandlog.Delete(id);
        }
    }
}
