using my_books.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class LogsService
    {

        private AppDbContext context;
        public LogsService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Log> GetLogs() => context.Logs.ToList();
    }
}
