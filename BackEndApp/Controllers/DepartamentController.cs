using AutoMapper;
using BackEndApp.Core.Context;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.SubDivision;
using BackEndApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private AppDbContext _context { get; }
        private IMapper _mapper { get; }

        public DepartamentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create. Создание нового отдела
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateDepartament([FromBody] CreateDepartamentCreateDto dto)
        {
            Departament newDepartament = _mapper.Map<Departament>(dto);
            await _context.Departamentes.AddAsync(newDepartament);
            await _context.SaveChangesAsync();

            //Добавление записи в историю отдела о создании
            HistoryDepartament historyDepartament = new HistoryDepartament();
            historyDepartament.DepartamentId = newDepartament.Id;
            historyDepartament.TypeEventDepSub = Core.Enums.TypeEventDepSub.Создание;
            historyDepartament.DateChangeHistory = DateTime.Now;
            await _context.HistoryDepartamentes.AddAsync(historyDepartament);
            await _context.SaveChangesAsync();
            return Ok("Отдел добавлен успешно");
        }
        
        //Read. Получение списка всех отделов
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetDepartamentDto>>> GetDepartaments ()
        {
            var departaments = await _context.Departamentes.Include(departament=>departament.Subdivision).ToListAsync();
            var convertedDepartaments = _mapper.Map<IEnumerable<GetDepartamentDto>>(departaments);
            return Ok(convertedDepartaments);
        }
        //Поиск отдела по ID
        [HttpGet]
        [Route("GET/id")]
        public async Task<ActionResult<GetDepartamentDto>> GetbyIdDepartament(int Id)
        {
            var departament = await _context.Departamentes.FirstOrDefaultAsync(departament => departament.Id == Id);
            if (departament == null)
            {
              return  NotFound();
            }
           
            
                var convertdepartament = _mapper.Map<GetDepartamentDto>(departament);
                return Ok(convertdepartament);
            
        }

        //Поиск отделов по ID подразделения
        [HttpGet]
        [Route("GET/idsubdivision")]
        public async Task<ActionResult<IEnumerable<GetDepartamentDto>>> GetbyIdDepartaments(int idsubdivision)
        {
            var departaments = await _context.Departamentes.Where(departament => departament.SubdivisionId == idsubdivision).ToListAsync();
            if (departaments.Count == 0)
            {
              return  BadRequest();
            }
           
                var convertdepartaments = _mapper.Map<IEnumerable<GetDepartamentDto>>(departaments);
                return Ok(convertdepartaments);
            
        }

        //Обновление данных об отделе
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateDepartament([FromBody] UpdateDepartamentDto updateDepartament)
        {
            if (updateDepartament == null)
            {
                return NotFound();
            }
            var departament = await _context.Departamentes.FirstOrDefaultAsync(departament => departament.Id == updateDepartament.Id);
            if (departament == null)
            {
                return NotFound();
            }
            _mapper.Map<UpdateDepartamentDto, Departament>(updateDepartament, departament);
            _context.Entry(departament).State = EntityState.Modified;
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
        //Закрытие отдела
        [HttpPut]
        [Route("CloseDepartament")]
        public async Task<IActionResult> CloseDepartament([FromBody] UpdateDepartamentDto closeDepartament)
        {
            if (closeDepartament == null)
            {
                return NotFound();
            }

            
            var departament = await _context.Departamentes.FirstOrDefaultAsync(departament => departament.Id == closeDepartament.Id);
            
             if (departament == null)
             {
                 return NotFound();
             }
             closeDepartament.IsDeleted = true;
             _mapper.Map<UpdateDepartamentDto, Departament>(closeDepartament, departament);
             _context.Entry(departament).State = EntityState.Modified;
             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 throw;
             }

             //Добавление записи об закрытие отдела
             HistoryDepartament historyDepartament = new HistoryDepartament();
             historyDepartament.DepartamentId = closeDepartament.Id;
             historyDepartament.TypeEventDepSub = Core.Enums.TypeEventDepSub.Закрытие;
             historyDepartament.DateChangeHistory = DateTime.Now;
             await _context.HistoryDepartamentes.AddAsync(historyDepartament);
             await _context.SaveChangesAsync();
            
            return Ok();
           
          
        }

        /*
        //Удаление отдела
        [HttpDelete]
        [Route("Delete/id")]
        public async Task<ActionResult> DeleteDepartament(int id)
        {

            var subdivision = await _context.Subdivisions.FindAsync(id);
            if (subdivision == null)
            {
                return NotFound();
            }
            var departament = await _context.Departamentes.Where(x => x.SubdivisionId == subdivision.Id).ToListAsync();
            if (departament.Count != 0)
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
