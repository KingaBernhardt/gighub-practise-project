using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers
{
    public class AttendancesController : ApiController
    {
        private AppDbContext _context;
        public AttendancesController()
        {
            _context = new AppDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody]AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(a => a.AttendeId == userId && a.GigId == dto.GigId);
            if (exists)
            {
                return BadRequest("The attendance already exist.");
            }
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
