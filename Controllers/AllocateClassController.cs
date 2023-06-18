using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateClassController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public AllocateClassController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetAllocateClass")]
        public async Task<IEnumerable<AllocateClass>> GetAllocateClass()
        {
            return await _studentDbContext.AllocateClasses.ToListAsync();
        }

        [HttpPost]
        [Route("AddAllocateClass")]
        public async Task<AllocateClass> AddAllocateClass(AllocateClass objAllocateClass)
        {
            var existingAllocation = await _studentDbContext.AllocateClasses.FirstOrDefaultAsync(s => s.teacher == objAllocateClass.teacher && s.classroom == objAllocateClass.classroom);
            if (existingAllocation == null)
            {
                _studentDbContext.AllocateClasses.Add(objAllocateClass);
                await _studentDbContext.SaveChangesAsync();
            }
            return objAllocateClass;
        }

        [HttpPatch]
        [Route("UpdateAllocateClass/{id}")]
        public async Task<AllocateClass> UpdateAllocateClass(AllocateClass objAllocateClass)
        {
            _studentDbContext.Entry(objAllocateClass).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objAllocateClass;
        }

        [HttpDelete]
        [Route("DeleteAllocateClass/{id}")]
        public bool Delete(int id)
        {
            bool a = false;
            var allocateclass = _studentDbContext.AllocateClasses.Find(id);
            if (allocateclass != null)
            {
                a = true;
                _studentDbContext.Entry(allocateclass).State = EntityState.Deleted;
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
