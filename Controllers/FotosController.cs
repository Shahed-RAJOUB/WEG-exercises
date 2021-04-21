using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class FotosController : ControllerBase
    {
        private readonly DataContext _context;

        // Database dependency injection
        public FotosController(DataContext context)
        {
            _context = context;
        }

        // IEnumerable is better than a list
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AppFoto>>> GetFotos()
        {
            return await _context.Fotos.ToListAsync();
        }

        private async Task<bool> MemberExists(string title)
        {
            return await _context.Fotos.AnyAsync(x => x.FotoTitle == title.ToLower());
        }
        
        public async Task<ActionResult<MemberDTO>> Register(RegisterDTO registerDto)
        {
            var user = new AppMember()
            {
                UserName = registerDto.UserName.ToLower(),
                UserEmail = registerDto.UserEmail.ToLower(),
                FotoTitle = registerDto.fotoTitle.ToLower(),
            };
            _context.Members.Add(user);
            await _context.SaveChangesAsync();
            return new MemberDTO()
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                fotoTitle = user.FotoTitle,
            };
        }
        //api/fotos (Json Body)
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> addFoto(AppFoto appFoto)
        {
            
            if (await MemberExists(appFoto.FotoTitle)) return BadRequest("Title is taken");
            var foto = new AppFoto()
            {
                AlbumName = appFoto.AlbumName.ToLower(),
                FotoTitle = appFoto.FotoTitle.ToLower(),
                Tag = appFoto.Tag.ToLower(),
                Location = appFoto.Location.ToLower(),
                Description = appFoto.Description.ToLower(),
                Date = appFoto.Date.ToLower(),
            };
            _context.Fotos.Add(foto);
            var claims = User.Claims;
            var member = new RegisterDTO()
            {
                UserName = claims.FirstOrDefault(x => x.Type == "name")?.Value,
                UserEmail = claims.FirstOrDefault(x => x.Type == "email")?.Value,
                fotoTitle = appFoto.FotoTitle,
                UserSubject = claims.FirstOrDefault(x => x.Type == "sub")?.Value,
            };
            await Register(member);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //api/fotos/id
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppFoto>> GetFoto(int id)
        {
            var member = await _context.Fotos.FindAsync(id);
            if (member is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(member);
            }
        }
        
        public async Task<ActionResult<AppMember>> Delete(int id)
        {
            var foto = await _context.Fotos.FindAsync(id);
            var member = await _context.Members.Where(a => a.FotoTitle == foto.FotoTitle).SingleAsync();
            if (member is null)
            {
                return NotFound();
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //api/members/id
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<AppFoto>> DeleteFoto(int id)
        {
            var member = await _context.Fotos.FindAsync(id);
            if (member is null)
            {
                return NotFound();
            }

            _context.Fotos.Remove(member);
            await Delete(id);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}