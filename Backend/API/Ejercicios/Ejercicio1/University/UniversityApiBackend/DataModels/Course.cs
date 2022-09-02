namespace UniversityApiBackend.DataModels
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string LongDescription { get; set; } = string.Empty;

        public string TargetAudience { get; set; } = string.Empty;

        public string Objectives { get; set; } = string.Empty;

        public string Requirements { get; set; } = string.Empty;
    }

    public enum Level
    {
        Basic, Intermediate, Advanced
    }
}
