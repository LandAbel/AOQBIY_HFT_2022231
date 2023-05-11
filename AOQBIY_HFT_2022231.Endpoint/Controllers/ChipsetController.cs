using AOQBIY_HFT_2022231.Endpoint.Services;
using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace AOQBIY_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChipsetController : ControllerBase
    {
        IChipsetLogic chiplog;
        IHubContext<SignalRHub> hub;

        public ChipsetController(IChipsetLogic chiplog, IHubContext<SignalRHub> hub)
        {
            this.chiplog = chiplog;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Chipset> ReadAll()
        {
            return this.chiplog.ReadAll();
        }
        [HttpGet("{id}")]
        public Chipset Read(int id)
        {
            return this.chiplog.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Chipset c)
        {
            this.chiplog.Create(c);
            this.hub.Clients.All.SendAsync("ChipsetCreated", c);
        }

        [HttpPut]
        public void Update([FromBody] Chipset c)
        {
            this.chiplog.Update(c);
            this.hub.Clients.All.SendAsync("ChipsetUpdated", c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var chipsetsToDelete = (Chipset)this.chiplog.Read(id);
            this.chiplog.Delete(id);
            this.hub.Clients.All.SendAsync("ChipsetDeleted", chipsetsToDelete);
        }
    }
}
