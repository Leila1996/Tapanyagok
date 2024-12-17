using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapanyagok.Server.Models;

namespace Tapanyagok.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapanyagokController : ControllerBase
    {
        private readonly TapanyagContext context;

        public TapanyagokController(TapanyagContext context)
        {
            this.context = context;   
        }

        // GET: api/Tapanyagok
        [HttpGet]
        public async Task<List<Tapanyag>> Get()
        {
            return await context.tapanyagok.ToListAsync();
        }
    }
}
