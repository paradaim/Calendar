using CrossVertise.Models;

public class CalendarViewModel{
    public List<string> months {set;get;}
    public string selectedMonth {set;get;}

}
public class TasksDetailsViewModel{
    public TasksDetailsViewModel(){
        this.task = new TblTask();
        this.Attendees = new List<TblAttendee>();
    }
    public TblTask task{set;get;}
    public List<TblAttendee> Attendees{set;get;}

}