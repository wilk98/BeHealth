using BeHealthBackend.DTOs.ImageDto;

namespace BeHealthBackend.Services.FileServices;
public interface IFileService
{
    Task<string> SaveFile(CreateImageDto file);
}