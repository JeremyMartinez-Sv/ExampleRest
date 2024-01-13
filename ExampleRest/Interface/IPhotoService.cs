using ExampleRest.Models;

namespace ExampleRest.Interface
{
    public interface IPhotoService
    {
        Task<DataTableResponse<Photo>> GetPhotosAsync(DataTableJS model);
    }
}
