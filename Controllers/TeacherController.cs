using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public TeacherController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetTeacher")]
        public async Task<IEnumerable<Teacher>> GetTeacher()
        {
            return await _studentDbContext.Teachers.ToListAsync();
        }

        [HttpPost]
        [Route("AddTeacher")]
        public async Task<Teacher> AddTeacher(Teacher objTeacher)
        {
            var existingTeacher = await _studentDbContext.Teachers.FirstOrDefaultAsync(s => s.fstname == objTeacher.fstname && s.lstname == objTeacher.lstname);
            if (existingTeacher == null)
            {
                _studentDbContext.Teachers.Add(objTeacher);
                await _studentDbContext.SaveChangesAsync();
                return objTeacher;
            }
            else
            {
                existingTeacher.connumber = objTeacher.connumber;
                existingTeacher.email = objTeacher.email;
                await _studentDbContext.SaveChangesAsync();
                return existingTeacher;
            }
        }

        [HttpPatch]
        [Route("UpdateTeacher/{id}")]
        public async Task<Teacher> UpdateTeacher(Teacher objTeacher)
        {
            _studentDbContext.Entry(objTeacher).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objTeacher;
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public bool Delete(int id)
        {
            bool a = false;
            var teacher = _studentDbContext.Teachers.Find(id);
            if (teacher != null)
            {
                a = true;
                _studentDbContext.Entry(teacher).State = EntityState.Deleted;
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

