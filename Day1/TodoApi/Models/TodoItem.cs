using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("TodoItems")]
    public class TodoItem
    {
        [Column("todo_id")]
        [Required]
        public long Id {get;set;}

        [Column("todo_name")]
        [StringLength(50)]
        public string Name {get;set;} = "";

        [Column("todo_status")]
        public bool IsComplete {get;set;}

        [Column("todo_address")]
        [StringLength(50)]
        public string Address {get;set;} = "";

    }
}
