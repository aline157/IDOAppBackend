using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDOApplication.Models;
using IDOApplication.Api.Models;
namespace IDOApplication.Api.Repository
{
    public interface ITodoRepository
    {
        Task<Todo> addTodo(Todo todo);
        Task<Todo> getTodoById(int id);
        Task<IEnumerable<Todo>> getTodo(UserDtoGet user);
        Task<IEnumerable<Todo>> getDone(UserDtoGet user);
        Task<IEnumerable<Todo>> getDoing(UserDtoGet user);
        Task<Todo> updateTodoStatus(int id, string status);
        Task<Todo> updateTodo(TodoDtoUpdate todo);

    }
}
