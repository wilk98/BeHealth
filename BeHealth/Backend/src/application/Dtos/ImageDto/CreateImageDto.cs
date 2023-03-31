using Microsoft.AspNetCore.Http;

namespace application.Dtos.ImageDtoFolder;

public class CreateImageDto
{
    public IFormFile Image { get; set; }
}