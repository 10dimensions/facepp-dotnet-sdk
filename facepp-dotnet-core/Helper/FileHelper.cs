using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Cody.FacePP.Core
{
    public class FileHelper
    {
        public static string GetBoundary()
        {
            return "---------------------------" + DateTime.Now.Ticks.ToString("x");
        }

        public static string GetContentType(string boundary)
        {
            return "multipart/form-data; boundary=" + boundary;
        }

        public static byte[] GetMultipartBytes(FileInfo file, string boundary, Dictionary<string, string> options, string paraName = "image_file1")
        {
            var bytes = new List<byte>();
            bytes.AddRange(BoundaryBytes(boundary));
            if (options != null && options.Count > 0)
            {
                foreach (var opt in options)
                    bytes.AddRange(FieldBytes(opt.Key, opt.Value, boundary));
            }
            bytes.AddRange(FileHeaders(file, paraName));
            bytes.AddRange(File.ReadAllBytes(file.FullName));
            bytes.AddRange(TailBytes(boundary));
            return bytes.ToArray();
        }

        public static byte[] GetMultipartBytes(
            FileInfo file1,
            FileInfo file2,
            string boundary,
            Dictionary<string, string> options,
            string paraName1 = "image_file1",
            string paraName2 = "image_file2")
        {
            var bytes = new List<byte>();
            bytes.AddRange(BoundaryBytes(boundary));
            if (options != null && options.Count > 0)
            {
                foreach (var opt in options)
                    bytes.AddRange(FieldBytes(opt.Key, opt.Value, boundary));
            }
            bytes.AddRange(FileHeaders(file1, paraName1));
            bytes.AddRange(File.ReadAllBytes(file1.FullName));

            bytes.AddRange(BoundaryBytes(boundary));
            bytes.AddRange(FileHeaders(file2, paraName2));
            bytes.AddRange(File.ReadAllBytes(file2.FullName));

            bytes.AddRange(TailBytes(boundary));
            return bytes.ToArray();
        }

        private static byte[] BoundaryBytes(string boundary)
        {
            return Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
        }

        private static byte[] FileHeaders(FileInfo file, string paraName = "image_file1")
        {
            string header = "Content-Disposition: form-data;";
            header += string.Format(" name=\"{0}\";", paraName);
            header += string.Format(" filename=\"{0}\"\r\n", file.Name);
            header += string.Format("Content-Type: {0}\r\n\r\n", GetFileType(file));
            return Encoding.UTF8.GetBytes(header);
        }

        private static byte[] FieldBytes(string key, string value, string boundary)
        {
            string field = "Content-Disposition: form-data;";
            field += string.Format(" name=\"{0}\"\r\n\r\n{1}", key, value);
            byte[] fdBytes = Encoding.UTF8.GetBytes(field);
            byte[] bdBytes = BoundaryBytes(boundary);
            var bytes = new List<byte>();
            bytes.AddRange(fdBytes);
            bytes.AddRange(bdBytes);
            return bytes.ToArray();
        }

        private static byte[] TailBytes(string boundary)
        {
            string tail = string.Format("\r\n--{0}--\r\n", boundary);
            return Encoding.UTF8.GetBytes(tail);
        }

        private static string GetFileType(FileInfo _file)
        {
            switch (_file.Extension.ToLower())
            {
                case ".png":
                    return "image/png";
                case ".jpg":
                    return "image/jpeg";
                case ".gif":
                    return "image/gif";
                case ".bmp":
                    return "image/bmp";
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".txt":
                    return "text/plain";
                case ".xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }

            return "text/plain";
        }
    }
}