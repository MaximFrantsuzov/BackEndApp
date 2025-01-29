using AutoMapper;
using BackEndApp.Core.Context;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.Employee;
using BackEndApp.Core.Dtos.SubDivision;
using BackEndApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private AppDbContext _context { get; }
        public IMapper _mapper { get; }

        public EmployeeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //CRUD

        //Create. Создание нового сотрудника
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            //Создание нового сотрудника
            Employee newEmployee = _mapper.Map<Employee>(dto);
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            //Добавление в трудовую деятельность записи о приёме на работу
            WorkActivity workActivity = new WorkActivity();
            workActivity.EmployeeId = newEmployee.Id;
            workActivity.TypeEventEmployee = Core.Enums.TypeEventEmployee.Приём;
            workActivity.DepartamentId = newEmployee.DepartamentId;
            workActivity.Date_Event = DateTime.Now;
            await _context.WorkActivities.AddAsync(workActivity);
            await _context.SaveChangesAsync();
            return Ok("Сотрудник успешно добавлен");

        }

        //Вывод всех сотрудников
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<GetEmployeeDto>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            var convertedemployees = _mapper.Map<IEnumerable<GetEmployeeDto>>(employees);
            return Ok(convertedemployees);
        }

        //Поиск сотрудника по ID
        [HttpGet]
        [Route("GET/id")]
        public async Task<ActionResult<GetEmployeeDto>> GetbyIdEmployees(int Id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }

            var convertemployee = _mapper.Map<GetEmployeeDto>(employee);
            return Ok(convertemployee);

        }

        //Перевод сотрудника в подразделение
        [HttpPut]
        [Route("TransderEmployee")]
        public async Task<IActionResult> TransferEmployee([FromBody] UpdateEmployeeDto transferEmployee)
        {
            if (transferEmployee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(employee=> employee.Id == transferEmployee.Id);
            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map<UpdateEmployeeDto, Employee>(transferEmployee, employee);
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            //Добавление записи в трудовую деятельность о переводе в другое подразделение
            WorkActivity workActivity = new WorkActivity();
            workActivity.TypeEventEmployee = Core.Enums.TypeEventEmployee.Перевод;
            workActivity.DepartamentId = transferEmployee.DepartamentId;
            workActivity.EmployeeId = transferEmployee.Id;
            workActivity.Date_Event= DateTime.Now;
            await _context.WorkActivities.AddAsync(workActivity);
            await _context.SaveChangesAsync();

            return Ok();

        }

        //Увольнение сотрудника
        [HttpPut]
        [Route("DismissalEmployee")]
        public async Task<IActionResult> DismissalEmployee([FromBody] UpdateEmployeeDto DismissalEmployee)
        {
            if (DismissalEmployee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == DismissalEmployee.Id);
            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map<UpdateEmployeeDto, Employee>(DismissalEmployee, employee);
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            //Добавление записи в трудовую деятельность о увольнении
            WorkActivity workActivity = new WorkActivity();
            workActivity.EmployeeId = employee.Id;
            workActivity.DepartamentId = employee.DepartamentId;
            workActivity.Date_Event = DateTime.Now;
            workActivity.TypeEventEmployee = Core.Enums.TypeEventEmployee.Увольнение;
            await _context.WorkActivities.AddAsync(workActivity);
            await _context.SaveChangesAsync();

            return Ok();

        }

        
    }
}
