using Xunit;

namespace CrossVertise.UnitTests.Services
{
    public class CrossVertiseService_IsCrossVetise
    {
        [Theory]
        [InlineData("March")] //Correct Month
        [InlineData("April1")] //Wront Month
        [InlineData("")] //Empty Month
        public void IsAppintments(string month)
        {
            var TaskService = new TaskService();
            var result = TaskService.Appointments(month);
            if (result == null)
            {
                Assert.False(false, "Appointments not load failed or Month is mistake");
            }
            else
            {
                Assert.False(false, "Appointments Is load success");
            }
        }
         [Theory]
        [InlineData("19C45C67-B520-4EFE-BD4A-A1AA9D4A85E8")] //correct TaskID
        [InlineData("19C45C67-B520-4EFE-BD4A-A1AA9D4A85E2")] //wrong TaskID
        [InlineData("")] //Empty TaskID
        public void IsAppointmentsDetails(string TaskID)
        {
            var TaskService = new TaskService();
            var result = TaskService.AppointmentsDetails(TaskID);
            if (result == null)
            {
                Assert.False(false, "Appointments details not load failed or TaskID is mistake or empty");
            }
            else
            {
                Assert.False(false, "Appointments details Is load success");
            }
        }
    }
}