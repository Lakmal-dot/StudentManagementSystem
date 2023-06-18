using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        [HttpGet]
        [Route("GetSelectedStudent")]
        public async Task<ActionResult<Student>> GetSelectedStudent(int id)
        {
            var student = _studentDbContext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student objStudent)
        {
            var existingStudent = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.stname == objStudent.stname && s.lstname == objStudent.lstname);
            if (existingStudent == null)
            {
                objStudent.age = DateTime.Today.Year - objStudent.dob.Year;
                _studentDbContext.Students.Add(objStudent);
                await _studentDbContext.SaveChangesAsync();
                return objStudent;
            }
            else
            {
                existingStudent.conperson = objStudent.conperson;
                existingStudent.connumber = objStudent.connumber;
                existingStudent.dob = objStudent.dob;
                existingStudent.email = objStudent.email;
                await _studentDbContext.SaveChangesAsync();
                return existingStudent;
            }
        }   

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student objStudent)
        {
            _studentDbContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool Delete(int id)
        {
            bool a = false;
            var student = _studentDbContext.Students.Find(id);
            if (student != null)
            {
                a = true;
                _studentDbContext.Entry(student).State = EntityState.Deleted;
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
