using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace LibraryManagementSystem.Models
{
    public partial class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

    }
}
