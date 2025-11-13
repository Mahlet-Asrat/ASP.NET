namespace SchoolApi.SchoolProject.Dtos
{
    public class ReadSchoolDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? Director { get; set; }
        public List<string>? Teachers { get; set; }
        public List<string>? Students { get; set; }
    }
}
