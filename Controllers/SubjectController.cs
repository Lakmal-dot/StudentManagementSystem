using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public SubjectController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetSubject")]
        public async Task<IEnumerable<Subject>> GetSubject()
        {
            return await _studentDbContext.Subjects.ToListAsync();
        }

        [HttpPost]
        [Route("AddSubject")]
        public async Task<Subject> AddSubject(Subject objSubject)
        {
            var existingSubject = await _studentDbContext.Subjects.FirstOrDefaultAsync(s => s.subjectname == objSubject.subjectname);
            if (existingSubject == null)
            {
                _studentDbContext.Subjects.Add(objSubject);
                await _studentDbContext.SaveChangesAsync();
            }
            return objSubject;
        }

        [HttpPatch]
        [Route("UpdateSubject/{id}")]
        public async Task<Subject> UpdateSubject(Subject objSubject)
        {
            _studentDbContext.Entry(objSubject).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objSubject;
        }

        [HttpDelete]
        [Route("DeleteSubject/{id}")]
        public bool Delete(int id)
        {
            bool a = false;
            var subject = _studentDbContext.Subjects.Find(id);
            if (subject != null)
            {
                a = true;
                _studentDbContext.Entry(subject).State = EntityState.Deleted;
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
