using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDoList
    {

        [Key]
        public int Id { get; set; }
        public string work { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime dateFrom { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateTo { get; set; }
        public int completed { get; set; }
    }
}
