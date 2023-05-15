using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generyki
{
    public interface IEntity
    {
        int id { get; set; }
    }
    public class Restautrant : IEntity
    {
        public int id { get; set; }
    }

    public class User : IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
    public class PaginatedResult <T>
    {
        public int ResultsFrom { get; set; }
        public int ResultsTo { get; set; }
        public int TotalPages { get; set; }
        public int TotalResaults { get; set; }
        public List<T>Results { get; set; }
    }
}
