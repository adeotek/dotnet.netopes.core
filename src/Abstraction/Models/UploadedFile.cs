using System;
using System.IO;

namespace Netopes.Core.Abstraction.Models
{
    public class UploadedFile
    {
        /// <summary>
        /// Gets the name of the file as specified by the browser.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the last modified date as specified by the browser.
        /// </summary>
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// Gets the size of the file in bytes as specified by the browser.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Gets the MIME type of the file as specified by the browser.
        /// </summary>
        public string ContentType { get; }
        
        /// <summary>
        /// Gets the file StreamReader.
        /// </summary>
        public StreamReader StreamReader { get; }
        
        /// <summary>
        /// Optional flag to test if file is valid or not. 
        /// </summary>
        public bool IsValid { get; set; }
        
        /// <summary>
        /// Optional message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public string FileExtension => Path.GetExtension(Name)?.ToLower();

        public UploadedFile(string name, DateTimeOffset lastModified, long size, string contentType, StreamReader streamReader)
        {
            Name = name;
            LastModified = lastModified;
            Size = size;
            ContentType = contentType;
            StreamReader = streamReader;
        }
        
        public UploadedFile(string name, long size, string contentType, StreamReader streamReader)
        {
            Name = name;
            Size = size;
            ContentType = contentType;
            StreamReader = streamReader;
        }
        
        public UploadedFile(string name, long size, StreamReader streamReader)
        {
            Name = name;
            Size = size;
            StreamReader = streamReader;
        }
        
        public UploadedFile(string name, StreamReader streamReader)
        {
            Name = name;
            StreamReader = streamReader;
        }
    }
}