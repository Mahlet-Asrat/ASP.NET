
namespace SchoolApi.Models
{
    public interface ISchool
    {
        string? Director { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        List<string>? Students { get; set; }
        List<string>? Teachers { get; set; }
    }
}