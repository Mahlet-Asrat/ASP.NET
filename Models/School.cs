namespace SchoolApi.Models
{
    public class School : ISchool
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Director { get; set; }
        public List<string>? Teachers { get; set; };
        public List<string>? Students { get; set; }
    }
}
