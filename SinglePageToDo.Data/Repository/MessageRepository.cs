using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePageToDo.Data.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SinglePageToDoDBEntities context;
        public MessageRepository(SinglePageToDoDBEntities context)
        {
            this.context = context;
        }

        public async Task<List<ToDoLogger>> GetAllMessages()
        {
            return await context.ToDoLoggers.Select(x => x).ToListAsync();
        }

        public async Task AddNewMessage(string message)
        {
            try
            {
                context.ToDoLoggers.Add(new ToDoLogger
                {
                    MessageText = message,
                    DatePosted = DateTime.UtcNow
                });
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
