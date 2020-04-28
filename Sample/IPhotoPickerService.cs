using System;
using System.IO;
using System.Threading.Tasks;

namespace Sample
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
