
using CrossVertise.Models;

public partial interface ITaskService
    {
       List<TblTask> Appointments(string month);
       TasksDetailsViewModel AppointmentsDetails(string TaskID);
    }
