using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinglePageToDo;

namespace SinglePageToDo.Data.Repository
{
    public interface IMessageRepository
    {
        Task<List<ToDoLogger>> GetAllMessages();
        Task AddNewMessage(string message);
    }
}
