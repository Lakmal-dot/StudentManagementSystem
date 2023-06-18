using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasRoomController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public ClasRoomController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetClass")]
        public async Task<IEnumerable<ClassRoom>> GetClass()
        {
            return await _studentDbContext.ClassRooms.ToListAsync();
        }

        [HttpPost]
        [Route("AddClass")]
        public async Task<ClassRoom> AddClassRoom(ClassRoom objClassroom)
        {
            var existingClass = await _studentDbContext.ClassRooms.FirstOrDefaultAsync(s => s.clsname == objClassroom.clsname);
            if (existingClass == null)
            {
                _studentDbContext.ClassRooms.Add(objClassroom);
                await _studentDbContext.SaveChangesAsync();
            }
            return objClassroom;
        }

        [HttpPatch]
        [Route("UpdateClass/{id}")]
        public async Task<ClassRoom> UpdateClass(ClassRoom objClassroom)
        {
            _studentDbContext.Entry(objClassroom).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objClassroom;
        }

        [HttpDelete]
        [Route("DeleteClass/{id}")]
        public bool Delete(int id)
        {
            bool a = false;
            var classroom = _studentDbContext.ClassRooms.Find(id);
            if (classroom != null)
            {
                a = true;
                _studentDbContext.Entry(classroom).State = EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }

            return a;
        }
    }
}
