using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApiGetPost
{
    public class Todo
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
