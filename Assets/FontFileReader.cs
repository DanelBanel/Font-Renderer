using System.IO;
using UnityEngine;
using System.Reflection;
using System;
using System.Text;

namespace FontRenderer
{
    public class FontFileReader
    {
        private Stream fileStream;
        private string fullPath;
        private BinaryReader binaryReader;

        public FontFileReader(string relativePathToFont)
        {
            string scriptDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            DirectoryInfo directoryInfo = new DirectoryInfo(scriptDirectory);
            string projectDirectory = directoryInfo.Parent.Parent.FullName;

            this.fullPath = Path.Combine(projectDirectory, relativePathToFont);
            Debug.Log($"FontFileParser constructor relativePathToFont: {relativePathToFont}");
            Debug.Log($"FontFileParser constructor scriptDirectory: {scriptDirectory}");
            Debug.Log($"FontFileParser constructor projectDirectory: {projectDirectory}");
            Debug.Log($"FontFileParser constructor this.fullPath: {this.fullPath}");
            ReadFile();
        }

        ~FontFileReader()
        {
            if (binaryReader != null)
            {
                binaryReader.Close();
                binaryReader = null;
            }
            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }
        }

        private void ReadFile()
        {
            Debug.Log($"ReadFile inarg: {this.fullPath}");

            if (File.Exists(this.fullPath))
            {
                Debug.Log($"File exists on path: {this.fullPath}");

                fileStream = File.Open(this.fullPath, FileMode.Open);
                binaryReader = new BinaryReader(fileStream, Encoding.UTF8, false);
            }
            else
            {
                Debug.Log($"File does not exist on path: {this.fullPath}");
            }
        }

        public void ReadFile(string fullPath)
        {
            throw new NotImplementedException();
        }

        public byte ReadUInt8()
        {
            return binaryReader.ReadByte();
        }

        public ushort ReadUInt16()
        {
            byte[] bytes = binaryReader.ReadBytes(2);
            Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
        }

        public uint ReadUInt32()
        {
            byte[] bytes = binaryReader.ReadBytes(4);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
