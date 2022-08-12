using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDOApplication.Models;
using Microsoft.EntityFrameworkCore;
using IDOApplication.Api.Models;

namespace IDOApplication.Api.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext appDbContext;

        public TodoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

      
        public async Task<Todo> addTodo(Todo todo)
        {
            var result = await appDbContext.Todos.AddAsync(todo);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Todo> getTodoById(int id)
        {
            return await appDbContext.Todos
                 .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<IEnumerable<Todo>> getTodo(UserDtoGet user)
        {
            return await appDbContext.Todos.
                 Where(e => e.Status == "To Do" && e.UserEmail == user.Email)
                 .OrderByDescending(s => s.Id)
                 .ToListAsync();
        }
        public async Task<IEnumerable<Todo>> getDone(UserDtoGet user)
        {
            return await appDbContext.Todos.
                 Where(e => e.Status == "Done" && e.UserEmail == user.Email).OrderByDescending(s => s.Id).ToListAsync();
        }
        public async Task<IEnumerable<Todo>> getDoing(UserDtoGet user)
        {
            return await appDbContext.Todos.
                 Where(e => e.Status == "Doing" && e.UserEmail == user.Email).OrderByDescending(s => s.Id).ToListAsync();
        }

        public async Task<Todo> updateTodoStatus(int id, string status)
        {
            var result = await appDbContext.Todos
               .FirstOrDefaultAsync(e => e.Id==id);

            if (result != null)
            {
                result.Status = status;


                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async Task<Todo> updateTodo(TodoDtoUpdate todo)
        {
            var result = await appDbContext.Todos
               .FirstOrDefaultAsync(e => e.Id == int.Parse(todo.Id));

            if (result != null)
            {
                result.Title = todo.Title;
                result.Category = todo.Category;
                result.Importance = todo.Importance;
                result.DueDate = todo.DueDate;
               
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }



    }
}
