using AutoMapper;
using BackEndApp.Core.Context;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.HistoryDepartament;
using BackEndApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryDepartamentController : ControllerBase
    {
        private AppDbContext _context { get; }
        public IMapper _mapper { get; }

        public HistoryDepartamentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateHistoryDepartament([FromBody]CreateHistoryDepartamentDto dto)
        {
            HistoryDepartament newHistoryDepartament = _mapper.Map<HistoryDepartament>(dto);
            await _context.HistoryDepartamentes.AddAsync(newHistoryDepartament);
            await _context.SaveChangesAsync();
            return Ok("История отдела добавлена успешна");
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetDepartamentDto>>> GetHistoryDepartements()
        {
            var historydepartaments = await _context.HistoryDepartamentes.Include(historydepartament => historydepartament.Departament).ToListAsync();
            var convertedHistoryDepartaments = _mapper.Map<IEnumerable<GetHistoryDepartamentDto>>(historydepartaments);
            return Ok(convertedHistoryDepartaments);
        }
        /*
      //Read
      [HttpGet]
      [Route("Read")]

      //Update
      [HttpPut]
      [Route("Update")]
      //Delete
      [HttpDelete]
      [Route("Delete")]
      */
    }
}
