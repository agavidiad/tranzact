using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Shared.Files
{
    public static class Functions
    {
        public static List<string> GetFileContent(string compressedFilePath, string directoryPath)
        {
            List<string> lines = new List<string>();
            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);

            #region Decompress
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                Decompress(fileToDecompress);
            }
            #endregion

            #region ReadAllLines
            var decompressedFilePath = compressedFilePath.Replace(".gz", "");

            using (StreamReader sr = new StreamReader(decompressedFilePath))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    lines.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                sr.Dispose();
            }
            #endregion

            return lines;
        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }


    }
}
