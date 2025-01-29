using AutoMapper;
using BackEndApp.Core.Context;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.HistoryDepartament;
using BackEndApp.Core.Dtos.HistorySubdivision;
using BackEndApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorySubdivisionController : ControllerBase
    {
        private AppDbContext _context { get; }
        public IMapper _mapper { get; }

        public HistorySubdivisionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateHistorySubdivision([FromBody]CreateHistorySubdidvisionDto dto)
        {
            HistorySubdivision newHistorySubdivision = _mapper.Map<HistorySubdivision>(dto);
            await _context.HistorySubdivisions.AddAsync(newHistorySubdivision);
            await _context.SaveChangesAsync();
            return Ok("История подразделения добавлена успешно");
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetDepartamentDto>>> GetHistorySubDivisions()
        {
            var historysubdivivisions = await _context.HistorySubdivisions.Include(historysubdivision => historysubdivision.Subdivision).ToListAsync();
            var convertedHistorySubDivisions = _mapper.Map<IEnumerable<GetHistorySubDivisionDto>>(historysubdivivisions);
            return Ok(convertedHistorySubDivisions);
        }
      
    }
}
