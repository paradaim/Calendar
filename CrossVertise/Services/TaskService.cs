
using CrossVertise.Models;

public partial class TaskService : ITaskService
{
    public List<TblTask> Appointments(string month)
    {
        List<TblTask> Tasks = new List<TblTask>();
        if (!string.IsNullOrEmpty(month))
        {
            if (Enum.IsDefined(typeof(Months), month))
            {
                var db = new CalendarDBContext();
                var EnumFindMonth = (int)Enum.Parse(typeof(Months), month);
                Tasks = db.TblTasks.Where(x => x.Month == Convert.ToInt32(EnumFindMonth)).ToList();
            }
        }
        return Tasks;
    }
    public TasksDetailsViewModel AppointmentsDetails(string TaskID)
    {
        var db = new CalendarDBContext();
        TasksDetailsViewModel tasksDetailsViewModel = new TasksDetailsViewModel();
        tasksDetailsViewModel.task = db.TblTasks.FirstOrDefault(x => x.TaskId == TaskID);
        tasksDetailsViewModel.Attendees = db.TblAttendeesTasks.Join(
        db.TblAttendees,
        AT => AT.AttenderId,
        A => A.AttenderId,
        (AT, A) => new { AT, A }
    ).Where(m => m.AT.TaskId == TaskID).Select(x => x.A).ToList();
        return tasksDetailsViewModel;
    }

}