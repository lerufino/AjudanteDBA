using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudanteDBA.Models
{
    public class ActionLogging
    {
        public string DatabaseName { get; set; }
        public ICollection<SqlEvent> SqlEvents { get; set; }

        public bool Success { get; set; }

        public ActionLogging()
        {
            DatabaseName = string.Empty;
            SqlEvents = new List<SqlEvent>();
        }

        public ActionLogging(string db)
        {
            DatabaseName = db;
            SqlEvents = new List<SqlEvent>();
        }
    }
}
