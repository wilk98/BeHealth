using application.Dtos.ImageDtoFolder;

namespace BeHealthBackend.Services.FileServices;
public interface IFileService
{
    Task<string> SaveFile(CreateImageDto file);
}