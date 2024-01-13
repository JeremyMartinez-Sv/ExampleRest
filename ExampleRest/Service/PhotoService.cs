using ExampleRest.Interface;
using ExampleRest.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ExampleRest.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly ILogger<PhotoService> logger;
        private readonly Constants constants;
        public PhotoService(ILogger<PhotoService> _logger, IOptions<Constants> _constants)
        {
            logger = _logger;
            constants = _constants.Value;
        }

        public async Task<DataTableResponse<Photo>> GetPhotosAsync(DataTableJS model)
        {
            var dataResponse = new DataTableResponse<Photo>()
            {
                CountFiltered = 5000 //la documentación dice que es de 5000 items para Photos en el apartado
                                     //"Resources" => https://jsonplaceholder.typicode.com/
            };

            dataResponse.Result = await RequestPhotos(model.Start, model.Length);

            dataResponse.CountTotal = dataResponse.Result.Count();

            return dataResponse;
        }

        private async Task<List<Photo>> RequestPhotos(int start, int limit)
        {
            string apiUrl = constants.APILink + "/photos?_start=" + start + " &_limit=" + limit;

            using HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(jsonContent);

                    return photos;
                }
                else
                {
                    logger.LogError(DateTime.UtcNow + " - Error en la solicitud: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.UtcNow + " - Error: " + ex.Message);
            }

            return new List<Photo>();
        }
    }
}
