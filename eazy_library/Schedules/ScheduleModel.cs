namespace eazy_library.Schedules
{
    public class ScheduleModel
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public string Description { get; set; }

        public string cronExpression { get; set; }
    }
}