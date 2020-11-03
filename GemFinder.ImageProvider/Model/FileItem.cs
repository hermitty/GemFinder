using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.ImageProvider.Model
{
    public class FileItem
    {
        public Guid Id { get; }
        public string FileName { get; set; }
        public string Label { get; }
        public string Source { get; }
        public string Path { get; set; }
        public FileItem(Guid id, string label, string source, string path, string fileName)
        {
            Id = id;
            Label = label;
            FileName = fileName;
            Source = source;
            Path = path;
        }
    }
}
