using System;
using System.Text.Json.Serialization;

namespace Netopes.Core.App.Models
{
    public class DownloadFileModel
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileContent { get; set; }

        [JsonIgnore]
        public string FileNameWithExtension => string.IsNullOrWhiteSpace(FileName) ? $"{DateTime.Now:yyyyMMddHHmmss}{FileExtension}" : $"{FileName}{FileExtension}";

        [JsonIgnore]
        public string FileContentType
        {
            get
            {
                return FileExtension.Trim('.').ToLower() switch
                {
                    "xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    _ => "application/octet-stream"
                };
            }
        }
    }
}