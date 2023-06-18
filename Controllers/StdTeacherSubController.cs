using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdTeacherSubController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StdTeacherSubController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetSubMap")]
        public async Task<IEnumerable<StdTeacherSubMap>> GetSubMap()
        {
            return await _studentDbContext.StdTeacherSubMaps.ToListAsync();
        }

        [HttpPost]
        [Route("AddSubMap")]
        public async Task<StdTeacherSubMap> AddSubMap(StdTeacherSubMap objSubMap)
        {
            _studentDbContext.StdTeacherSubMaps.Add(objSubMap);
            await _studentDbContext.SaveChangesAsync();
            return objSubMap;
        }

        [HttpPatch]
        [Route("UpdateSubMap/{id}")]
        public async Task<StdTeacherSubMap> UpdateSubMap(StdTeacherSubMap objSubMap)
        {
            _studentDbContext.Entry(objSubMap).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objSubMap;
        }

        [HttpDelete]
        [Route("DeleteSubMap/{id}")]
        public bool Delete(int id)
        {
            bool a = false;
            var sbumap = _studentDbContext.StdTeacherSubMaps.Find(id);
            if (sbumap != null)
            {
                a = true;
                _studentDbContext.Entry(sbumap).State = EntityState.Deleted;
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
