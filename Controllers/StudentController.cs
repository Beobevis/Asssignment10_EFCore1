using Microsoft.AspNetCore.Mvc;
using EntitySample.Services;
using EntitySample.Models;
namespace EntitySample.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger, IStudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var dataStudent = await _studentService.GetAllAsync();
        var resultStudent = from student in dataStudent
                            select new StudentViewModel
                            {
                                Id = student.Id,
                                FullName = $"{student.FirstName} {student.LastName}",
                                City = student.City,
                            };
        return new JsonResult(resultStudent);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var dataStudent = await _studentService.GetOneAsync(id);
        if (dataStudent == null) return NotFound();


        return new JsonResult(new StudentViewModel
        {

            Id = dataStudent.Id,
            FullName = $"{dataStudent.FirstName} {dataStudent.LastName}",
            City = dataStudent.City,
        });
    }
    [HttpPost]
    public async Task<IActionResult> CreateStudentAsync(StudentCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                State = model.State,
            };
            var resultStudent = await _studentService.AddAsync(entity);
            return new JsonResult(resultStudent);
        }
        catch (System.Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditStudentAsync(int id, StudentEditModel model)
    {

        var dataStudent = await _studentService.GetOneAsync(id);
        dataStudent.FirstName = model.FirstName;
        dataStudent.LastName = model.LastName;
        dataStudent.City = model.City;
        dataStudent.State = model.State;

        var resultStudent = await _studentService.EditAsync(id, dataStudent);
        return new JsonResult(resultStudent);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudentAsync(int id) {
        try{
            await _studentService.Remove(id);
            return  Ok();
        }
        catch(IndexOutOfRangeException ex){
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    
    }




}
