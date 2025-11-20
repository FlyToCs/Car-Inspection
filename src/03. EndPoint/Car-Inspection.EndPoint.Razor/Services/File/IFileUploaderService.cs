namespace Car_Inspection.EndPoint.Razor.Services.File;

public interface IFileUploaderService
{
    List<string> UploadImages(List<IFormFile> files, string folderName);
}