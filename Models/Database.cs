using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudanteDBA.Models
{
    public class Database
    {
        public string TableName { get; set; }
        public List<string> FilePaths { get; set; }

        public Database()
        {
            FilePaths = new List<string>();
        }
    }
}
