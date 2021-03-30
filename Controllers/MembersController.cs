using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<AppMember>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }
        private async Task<bool> MemberExists(string firstName)
        {
            return await _context.Members.AnyAsync(x => x.FirstName == firstName.ToLower());
        }
        //api/members (Json Body)
        [HttpPost]
        public async Task<ActionResult<MemberDTO>> Register(RegisterDTO registerDto)
        {
            if (await MemberExists(registerDto.FirstName)) return BadRequest("Username is taken");
            var user = new AppMember()
            {
                FirstName = registerDto.FirstName.ToLower(),
                LastName = registerDto.LastName.ToLower(),
                Email = registerDto.Email.ToLower(),
                City= registerDto.City.ToLower(),
                Country = registerDto.Country.ToLower(),
                Zip = registerDto.Zip.ToLower(),
                Birthday = registerDto.Birthday.ToLower(),
                Password = registerDto.Password.ToLower(),
            };
            _context.Members.Add(user);
            await _context.SaveChangesAsync();
            return new MemberDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                Country = user.City,
                Zip = user.Zip,
                Birthday = user.Birthday,
                Password = user.Password,
            };
        }

        //api/members/id
        [HttpGet("{id}")]
        public async Task<ActionResult<AppMember>> GetMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(member);
            }
        }

        //api/members/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppMember>> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member is null)
            {
                return NotFound();
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}