using System;
using System.Collections.Generic;

namespace cw6.Models.DTO
{
    public class SomeSortOfAll
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public IEnumerable<string> Medicaments { get; set; }
    }
}
