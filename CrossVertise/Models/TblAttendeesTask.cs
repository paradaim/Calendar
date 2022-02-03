using System;
using System.Collections.Generic;

namespace CrossVertise.Models
{
    public partial class TblAttendeesTask
    {
        public string? AttenderId { get; set; }
        public string? TaskId { get; set; }

        public virtual TblAttendee? Attender { get; set; }
        public virtual TblTask? Task { get; set; }
    }
}
