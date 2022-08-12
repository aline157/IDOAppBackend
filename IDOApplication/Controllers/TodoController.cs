using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using IDOApplication.Models;
using System.Data;
using System.Data.SqlClient;
using IDOApplication.Api.Repository;
using IDOApplication.Api.Models;

namespace IDOApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        
        private readonly ITodoRepository todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }


        [HttpPost]
        public async Task<ActionResult> Post(TodoDtoAdd todo)
        {
            try
            {
                var todoToAdd = new Todo(todo.Title, todo.Category, todo.DueDate, todo.Importance, "To Do", todo.UserEmail);
                var add = await todoRepository.addTodo(todoToAdd);
               
                return Ok("todo added successfully");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }

        }

        [HttpPost("/api/Todo/get")]
        public async Task<ActionResult> GetTodoById(TodoDtoGet todo)
        {
            try
            {
                var result = await todoRepository.getTodoById((todo.Id));
                if(result != null)
                {
                    return Ok(result);
                }

                return NotFound("Todo not exists");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }
        }

        [HttpPost("/api/Todo/todo")]
        public async Task<ActionResult> GetToDo(UserDtoGet user)
        {

            try
            {
                var result = await todoRepository.getTodo(user);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound("Todo not exists");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }

        }

        [HttpPost("/api/Todo/done")]
        public async Task<ActionResult> GetDone(UserDtoGet user)
        {
            try
            {
                var result = await todoRepository.getDone(user);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound("Done not exists");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }

            

        }

        [HttpPost("/api/Todo/doing")]
        public async Task<ActionResult> GetDoing(UserDtoGet user)
        {
            try
            {
                var result = await todoRepository.getDoing(user);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound("Done not exists");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateTodoStatus(TodoDtoUpdateStatus todo)
        {
            try
            {
                var result = await todoRepository.updateTodoStatus(todo.Id,todo.Status );
                

                return Ok("Updated successfully");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }


        }

        [HttpPut("/api/Todo/update")]
        public async Task<ActionResult> UpdateTodo(TodoDtoUpdate todo)
        {
            try
            {
                var result = await todoRepository.updateTodo(todo);


                return Ok("Updated successfully");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error");
            }


        }

    }
}
