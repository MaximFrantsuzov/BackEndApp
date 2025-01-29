using AutoMapper;
using BackEndApp.Core.Context;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.JobTitle;
using BackEndApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        private AppDbContext _context { get; }
        public IMapper _mapper { get; }

        public JobTitleController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create. Добавление новой должности
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJobTitle([FromBody]CreateJobTitileDto dto)
        {
            JobTitle newJobtitle = _mapper.Map<JobTitle>(dto);
            await _context.JobTitles.AddAsync(newJobtitle);
            await _context.SaveChangesAsync();
            return Ok("Должность добавлена успешно"); 
        }

        //Получение списка всех должностей
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetJobTitleDto>>> GetJobsTitle()
        {
            var jobstitle = await _context.JobTitles.ToListAsync();
            var convertedjobstitle = _mapper.Map<IEnumerable<GetJobTitleDto>>(jobstitle);
            return Ok(convertedjobstitle);
        }
     
    }
}
