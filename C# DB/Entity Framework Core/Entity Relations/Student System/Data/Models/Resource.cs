namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Url { get; set; }
    }
}