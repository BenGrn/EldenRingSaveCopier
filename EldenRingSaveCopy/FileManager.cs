using EldenRingSaveCopy.Saves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRingSaveCopy
{
    public class FileManager
    {
        private const int ID_LOCATION = 0x19003B4;

        private byte[] sourceFile;
        private byte[] targetFile;
        private byte[] sourceID;
        private byte[] targetID;
        private string sourcePath;
        private string targetPath;

        public FileManager()
        {
            sourceFile = new byte[0];
            targetFile = new byte[0];
            sourceID = new byte[8];
            targetID = new byte[8];
        }

        public byte[] SourceFile {
            get => sourceFile;
            set
            {
                sourceFile = value ?? new byte[0];
                if(sourceFile.Length > 0)
                {
                    try
                    {
                        Array.Copy(sourceFile, ID_LOCATION, sourceID, 0, 8);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public byte[] TargetFile
        {
            get => targetFile;
            set
            {
                targetFile = value ?? new byte[0];
                if (targetFile.Length > 0)
                {
                    try
                    {
                        Array.Copy(targetFile, ID_LOCATION, targetID, 0, 8);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public string TargetPath
        {
            get => targetPath;
            set
            {
                targetPath = value ?? string.Empty;
            }
        }

        public string SourcePath
        {
            get => sourcePath;
            set
            {
                sourcePath = value ?? string.Empty;
            }
        }

        public byte[] TargetID
        {
            get => targetID;
        }

        public byte[] SourceID
        {
            get => sourceID;
        }
    }
}
