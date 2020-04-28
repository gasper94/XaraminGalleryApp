using System;
using System.IO;

namespace Sample
{
    public interface IFileService
    {
        void SavePicture(string name, Stream data, string location = "temp");
    }
}
