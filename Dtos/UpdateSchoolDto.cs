namespace SchoolApi.Dtos
{
    public class UpdateSchoolDto
    {
        public string Name { get; set; }
        public string? Director { get; set; }
        public List<string>? Teachers { get; set; } = new();
        public List<string>? Students { get; set; } = new();

    }
}
