using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("jokenpo")]
    public class JokenpoController : ControllerBase
    {
        private readonly DbContext _context;

        public JokenpoController(DbContext context){
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> Post()
        {
            return Ok();
        }
    }
}