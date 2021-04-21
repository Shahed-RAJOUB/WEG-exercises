using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.DTOs;
using MyApp.Entities;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MembersController : ControllerBase
    {
        private readonly DataContext _context;

        // Database dependency injection
        public MembersController(DataContext context)
        {
            _context = context;
        }

        // IEnumerable is better than a list
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AppMember>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

    }
}