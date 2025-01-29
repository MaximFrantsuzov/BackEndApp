using AutoMapper;
using BackEndApp.Core.Context;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.WorkActivity;
using BackEndApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkActivityController : ControllerBase
    {
        private AppDbContext _context { get; }
        private IMapper _mapper { get; }

        public WorkActivityController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //CRUD

        //Create.Создание записи трудовой деятельности для сотрудника
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateWorkActvity([FromBody]CreateWorkActivityDto dto)
        {
            WorkActivity newWorkActivity = _mapper.Map<WorkActivity>(dto);
            await _context.WorkActivities.AddAsync(newWorkActivity);
            await _context.SaveChangesAsync();
            return Ok("Трудовая деятельность добавлена успешна");
        }
        
        //Получение трудовой деятельности всех сотрудников
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetWorkActivityDto>>> GetWorksActivity()
        {
            var worksactivity = await _context.WorkActivities.Include(worksactivity => worksactivity.Departament).Include(worksactivity=>worksactivity.Employee).ToListAsync();
            var convertedWorskactivity = _mapper.Map<IEnumerable<GetWorkActivityDto>>(worksactivity);
            return Ok(convertedWorskactivity);
        }
       
    }
}
