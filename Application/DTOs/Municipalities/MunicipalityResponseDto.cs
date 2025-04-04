namespace Application.DTOs.Municipalities;

public class MunicipalityResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
}