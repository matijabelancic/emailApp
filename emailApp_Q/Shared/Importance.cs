using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace emailApp_Q.Shared
{
    public class Importance
    {
        [Column("ImportanceId")]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
