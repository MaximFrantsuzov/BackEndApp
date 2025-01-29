using AutoMapper;
using BackEndApp.Core.Context;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.SubDivision;
using BackEndApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubdivisionController : ControllerBase
    {
     
        private AppDbContext _context { get; }
        public IMapper _mapper { get; }

        public SubdivisionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //CRUD

       
        
        //Create. Создание нового подразделения (отделения)
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSubdivision([FromBody] CreateSubdivisionDto dto)
        {
            Subdivision newSubdivision = _mapper.Map<Subdivision>(dto);
            await _context.Subdivisions.AddAsync(newSubdivision);
            await _context.SaveChangesAsync();
            HistorySubdivision historySubdivision = new HistorySubdivision();
            historySubdivision.SubdivisionId = newSubdivision.Id;
            historySubdivision.TypeEventDepSub = Core.Enums.TypeEventDepSub.Создание;
            historySubdivision.DateChangeHistory = DateTime.Now;
            await _context.HistorySubdivisions.AddAsync(historySubdivision);
            await _context.SaveChangesAsync();
            return Ok("Подразделение добавлено успешно");
        }

        //Read. Получение списка всех подразделений
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetSubdivisionDto>>> GetSubdivisions()
        {
            var subdivisions = await _context.Subdivisions.ToListAsync();
            var convertedSubdivisions = _mapper.Map<IEnumerable<GetSubdivisionDto>>(subdivisions);
            return Ok(convertedSubdivisions);
        }
        // Получение списка открытых подразделений на  конкретную дату
        [HttpGet]
        [Route("GetSubdivisionDate")]
        public async Task<ActionResult<IEnumerable<GetSubdivisionDto>>> GetSelectedDateSubdivisions(DateTime selectedDate)
        {
            var subdivisions = await _context.Subdivisions.Include(history => history.HistorySubdivisions).Include(departament=>departament.Departaments).ToListAsync();
            var newsubdivisions = new List<Subdivision>();
            foreach (var subdivision in subdivisions)
            {

              
                var historysubdivisions = subdivision.HistorySubdivisions.Where(historysubdivision => historysubdivision.SubdivisionId == subdivision.Id).ToList();
             
              
                var historySubdivisionOpen = historysubdivisions.FirstOrDefault(history=>history.TypeEventDepSub== Core.Enums.TypeEventDepSub.Создание && history.DateChangeHistory<=selectedDate);
                if (historySubdivisionOpen!=null)
                {
                    var historySubDivisionClose = historysubdivisions.FirstOrDefault(history => history.TypeEventDepSub == Core.Enums.TypeEventDepSub.Закрытие);
                    if (historySubDivisionClose != null)
                    {
                        if (historySubDivisionClose.DateChangeHistory < selectedDate)
                        {
       
                            newsubdivisions.Add(subdivision);
                        }
                    }
                    else 
                    {
                       
                        newsubdivisions.Add(subdivision);
                    }
                }
               
            }
            
            var convertedSubdivisions = _mapper.Map<IEnumerable<GetSubdivisionDto>>(newsubdivisions);
            return Ok(convertedSubdivisions);
        }

   
        //Read. Поиск подразделения по ID

        [HttpGet]
        [Route("GET/id")]
        public async Task<ActionResult<GetSubdivisionDto>> GetbyIdSubdivision(int Id)
        {
            var subdivision = await _context.Subdivisions.FirstOrDefaultAsync(subdivision=>subdivision.Id==Id);
            if (subdivision==null)
            {
                NotFound();
            }
            var convertsubdivision =_mapper.Map<GetSubdivisionDto>(subdivision);
            return  Ok(convertsubdivision);
        }

        //Обновление данных о подразделении

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateSubdivision([FromBody]UpdateSubdivisionDto updateSubdivision)
        {
            if (updateSubdivision==null)
            {
                return NotFound();
            }
            var subdivision = await _context.Subdivisions.FirstOrDefaultAsync(subdivision => subdivision.Id == updateSubdivision.Id);
            if (subdivision==null)
            {
                return NotFound();
            }
            _mapper.Map<UpdateSubdivisionDto, Subdivision>(updateSubdivision, subdivision);
            _context.Entry(subdivision).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();

        }
        //Закрытие подразделения (отделения)
        [HttpPut]
        [Route("CloseSubdivision")]
        public async Task<IActionResult> CloseSubdivision([FromBody] UpdateSubdivisionDto closeSubdivision)
        {
            if (closeSubdivision == null)
            {
                return NotFound();
            }
            var subdivision = await _context.Subdivisions.FirstOrDefaultAsync(subdivision => subdivision.Id == closeSubdivision.Id);
            if (subdivision == null)
            {
                return NotFound();
            }
            //Проверяем все ли отделы закрыты в данном подразделении(отделении)
            var subdivisiondepartaments = await _context.Departamentes.Where(d => d.SubdivisionId == closeSubdivision.Id && d.IsDeleted != true).ToListAsync();
            if (subdivisiondepartaments.Count!=0)
            {
                return BadRequest();
            }

           
            _mapper.Map<UpdateSubdivisionDto, Subdivision>(closeSubdivision, subdivision);
            _context.Entry(subdivision).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            // добавление в историю действий закрытие подразделения
            HistorySubdivision historySubdivision = new HistorySubdivision();
            historySubdivision.SubdivisionId = subdivision.Id;
            historySubdivision.TypeEventDepSub = Core.Enums.TypeEventDepSub.Закрытие;
            historySubdivision.DateChangeHistory = DateTime.Now;
            await _context.HistorySubdivisions.AddAsync(historySubdivision);
            await _context.SaveChangesAsync();
           

            return Ok();

        }


        /*
        [HttpDelete]
        [Route("Delete/id")]
        public async Task<ActionResult> DeleteSubdivision(int id)
        {

            var subdivision = await _context.Subdivisions.FindAsync(id);
            if (subdivision==null)
            {
                return NotFound();
            }
            var departament = await _context.Departamentes.Where(x => x.SubdivisionId == subdivision.Id).ToListAsync();
            if (departament.Count!=0)
            {
                return BadRequest();
            }
            _context.Subdivisions.Remove(subdivision);
            await _context.SaveChangesAsync();
            return Ok();

        }
        */
    }
}
