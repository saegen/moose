using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Models.Content
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class EditableContent
    {
        [Key]
        [Column(Order = 0)]
        public string ElementId { get; set; }
        [Column(Order = 1)]
        public string Content { get; set; }
        [Column(Order = 2)]
        public string View { get; set; }
    }
}
