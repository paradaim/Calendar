using System;
using System.Collections.Generic;

namespace CrossVertise.Models
{
    public partial class TblTask
    {
        public string TaskId { get; set; } = null!;
        public string? Organizer { get; set; }
        public string? Subject { get; set; }
        public DateTime? Date { get; set; }
        public int? Month { get; set; }
    }
}
