using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateSubjectController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public AllocateSubjectController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetAllocateSubject")]
        public async Task<IEnumerable<AllocateSubject>> GetAllocateSubject()
        {
            return await _studentDbContext.AllocateSubjects.ToListAsync();
        }

        [HttpPost]
        [Route("AddAllocateSubject")]
        public async Task<AllocateSubject> AddAllocateSubject(AllocateSubject objAllocateSubject)
        {
            var existingAllocation = await _studentDbContext.AllocateSubjects.FirstOrDefaultAsync(s => s.teacher == objAllocateSubject.teacher && s.subject == objAllocateSubject.subject);
            if (existingAllocation == null)
            {
                _studentDbContext.AllocateSubjects.Add(objAllocateSubject);
                await _studentDbContext.SaveChangesAsync();
            }
            return objAllocateSubject;
        }

        [HttpPatch]
        [Route("UpdateAllocateSubject/{id}")]
        public async Task<AllocateSubject> UpdateAllocateSubject(AllocateSubject objAllocateSubject)
        {
            _studentDbContext.Entry(objAllocateSubject).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objAllocateSubject;
        }

        [HttpDelete]
        [Route("DeleteAllocateSubject/{id}")]
        public bool Delete(int id)
        {
            bool a = false;
            var allocatesubject = _studentDbContext.AllocateSubjects.Find(id);
            if (allocatesubject != null)
            {
                a = true;
                _studentDbContext.Entry(allocatesubject).State = EntityState.Deleted;
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
