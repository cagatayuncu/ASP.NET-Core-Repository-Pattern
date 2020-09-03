using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.Entities
{
    public class Articles
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? Date { get; set; }

        public string WriterName { get; set; }

        public string WriterSurname { get; set; }
    }
}
