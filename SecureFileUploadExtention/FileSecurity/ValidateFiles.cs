using Microsoft.AspNetCore.Http;
using SecureFileUploadExtention.CustomResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SecureFileUploadExtention.FileSecurity
{
    public static class ValidateFiles
    {
        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".zip","application/zip" },
                {".rar","application/x-rar" }
            };
        }

        private enum ImageFileExtension
        {
            none = 0,
            jpg = 1,
            jpeg = 2,
            bmp = 3,
            gif = 4,
            png = 5
        }

        private enum VideoFileExtension
        {
            none = 0,
            wmv = 1,
            mpg = 2,
            mpeg = 3,
            mp4 = 4,
            avi = 5,
            flv = 6
        }

        private enum PdfFileExtension
        {
            none = 0,
            PDF = 1
        }

        private enum DocDocxFileExtention
        {
            none = 0,
            DOC = 1,
            DOCX = 2
        }

        private enum ZipRarFileExtention
        {
            none = 0,
            ZIP = 1,
            RAR = 2
        }

        public enum FileType
        {
            Image = 1,
            Video = 2,
            PDF = 3,
            Text = 4,
            DOC = 5,
            DOCX = 6,
            PPT = 7,
            ZIP = 8,
            RAR = 9
        }

        public static bool IsValidFile(byte[] bytFile, FileType flType, string fileContentType)
        {
            bool isvalid = false;

            if (flType == FileType.Image)
            {
                isvalid = IsValidImageFile(bytFile, fileContentType);
            }
            else if (flType == FileType.Video)
            {
                isvalid = IsValidVideoFile(bytFile, fileContentType);
            }
            else if (flType == FileType.PDF)
            {
                isvalid = IsValidPdfFile(bytFile, fileContentType);
            }

            else if (flType == FileType.DOC || flType == FileType.DOCX)
            {
                isvalid = IsValidDocDocxFile(bytFile, fileContentType);
            }

            else if (flType == FileType.RAR || flType == FileType.ZIP)
            {
                isvalid = IsValidZipRarFile(bytFile, fileContentType);
            }

            return isvalid;
        }

        public static bool IsValidImageFile(byte[] bytFile, string fileContentType)
        {
            bool isvalid = false;

            byte[] chkBytejpg = { 255, 216, 255 };
            byte[] chkBytebmp = { 66, 77 };
            byte[] chkBytegif = { 71, 73, 70, 56 };
            byte[] chkBytepng = { 137, 80, 78, 71 };


            ImageFileExtension imgfileExtn = ImageFileExtension.none;

            if (fileContentType.Contains("jpg") | fileContentType.Contains("jpeg"))
            {
                imgfileExtn = ImageFileExtension.jpg;
            }
            else if (fileContentType.Contains("png"))
            {
                imgfileExtn = ImageFileExtension.png;
            }
            else if (fileContentType.Contains("bmp"))
            {
                imgfileExtn = ImageFileExtension.bmp;
            }
            else if (fileContentType.Contains("gif"))
            {
                imgfileExtn = ImageFileExtension.gif;
            }

            if (imgfileExtn == ImageFileExtension.jpg || imgfileExtn == ImageFileExtension.jpeg)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        if (bytFile[i] == chkBytejpg[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }


            else if (imgfileExtn == ImageFileExtension.png)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepng[i])
                        {
                            j = j + 1;
                            if (j == 4)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (imgfileExtn == ImageFileExtension.bmp)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytebmp[i])
                        {
                            j = j + 1;
                            if (j == 2)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (imgfileExtn == ImageFileExtension.gif)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytegif[i])
                        {
                            j = j + 1;
                            if (j == 2)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }

        private static bool IsValidVideoFile(byte[] bytFile, string fileContentType)
        {
            byte[] chkBytewmv = { 48, 38, 178, 117 };
            byte[] chkByteavi = { 82, 73, 70, 70 };
            byte[] chkByteflv = { 70, 76, 86, 1 };
            byte[] chkBytempg = { 0, 0, 1, 186 };
            byte[] chkBytemp4 = { 0, 0, 0 };
            bool isvalid = false;

            VideoFileExtension vdofileExtn = VideoFileExtension.none;
            if (fileContentType.Contains("wmv"))
            {
                vdofileExtn = VideoFileExtension.wmv;
            }
            else if (fileContentType.Contains("mpg") || fileContentType.Contains("mpeg"))
            {
                vdofileExtn = VideoFileExtension.mpg;
            }
            else if (fileContentType.Contains("mp4"))
            {
                vdofileExtn = VideoFileExtension.mp4;
            }
            else if (fileContentType.Contains("avi"))
            {
                vdofileExtn = VideoFileExtension.avi;
            }
            else if (fileContentType.Contains("flv"))
            {
                vdofileExtn = VideoFileExtension.flv;
            }

            if (vdofileExtn == VideoFileExtension.wmv)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytewmv[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if ((vdofileExtn == VideoFileExtension.mpg || vdofileExtn == VideoFileExtension.mpeg))
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytempg[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (vdofileExtn == VideoFileExtension.mp4)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        if (bytFile[i] == chkBytemp4[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (vdofileExtn == VideoFileExtension.avi)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteavi[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (vdofileExtn == VideoFileExtension.flv)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteflv[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;

        }

        public static bool IsValidPdfFile(byte[] bytFile, string fileContentType)
        {
            byte[] chkBytepdf = { 37, 80, 68, 70 };
            bool isvalid = false;

            PdfFileExtension pdffileExtn = PdfFileExtension.none;
            if (fileContentType.Contains("pdf"))
            {
                pdffileExtn = PdfFileExtension.PDF;
            }

            if (pdffileExtn == PdfFileExtension.PDF)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepdf[i])
                        {
                            j = j + 1;
                            if (j == 4)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        public static bool IsValidDocDocxFile(byte[] bytFile, string fileContentType)
        {
            byte[] chkByteDoc = { 208, 207, 17, 224 };
            byte[] chkByteDocx = { 80, 75, 3, 4 };
            bool isvalid = false;

            DocDocxFileExtention docfileExtn = DocDocxFileExtention.none;
            if (fileContentType.Contains("doc"))
            {
                docfileExtn = DocDocxFileExtention.DOC;
            }

            else if (fileContentType.Contains("docx"))
            {
                docfileExtn = DocDocxFileExtention.DOCX;
            }

            if (docfileExtn == DocDocxFileExtention.DOC)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDoc[i])
                        {
                            j = j + 1;
                            if (j == 4)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            else if (docfileExtn == DocDocxFileExtention.DOCX)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteDocx[i])
                        {
                            j = j + 1;
                            if (j == 4)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        public static bool IsValidZipRarFile(byte[] bytFile, string fileContentType)
        {
            byte[] chkByteZip = { 80, 75, 3, 4 };
            byte[] chkByteRar = { 82, 97, 114, 33 };
            bool isvalid = false;

            ZipRarFileExtention ziprarfileExtn = ZipRarFileExtention.none;
            if (fileContentType.Contains("zip"))
            {
                ziprarfileExtn = ZipRarFileExtention.ZIP;
            }

            else if (fileContentType.Contains("rar"))
            {
                ziprarfileExtn = ZipRarFileExtention.RAR;
            }

            if (ziprarfileExtn == ZipRarFileExtention.ZIP)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteZip[i])
                        {
                            j = j + 1;
                            if (j == 4)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            else if (ziprarfileExtn == ZipRarFileExtention.RAR)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkByteRar[i])
                        {
                            j = j + 1;
                            if (j == 4)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        /// <summary>
        /// upload and validating files
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <param name="fileName"></param>
        /// <param name="generateNewFileName"></param>
        /// <returns>UploadFileResult(bool IsSuccess, string NewFileName, List<string> Errors)</returns>
        public static async Task<UploadFileResult> UploadFileAsync(this IFormFile file, FileType type, string path, string fileName = "", bool generateNewFileName = false)
        {
            try
            {
                string FileExtension = Path.GetExtension(file.FileName);
                string newFileName = string.Empty;

                if (generateNewFileName)
                    newFileName = $"{Guid.NewGuid()}{FileExtension}";
                else
                    newFileName = string.IsNullOrWhiteSpace(fileName) == true ? file.FileName : fileName;

                if (Directory.Exists(path) == false)
                    Directory.CreateDirectory(path);

                string fullPath = string.IsNullOrWhiteSpace(newFileName) == false ?
                 $"{path}/{newFileName}" : $"{path}/{file.FileName}";

                bool result = default;
                using (var memory = new MemoryStream())
                {
                    await file.CopyToAsync(memory);
                    result = IsValidFile(memory.ToArray(), type, FileExtension.Replace('.', ' '));

                    if (!result)
                    {
                        memory.Close();
                        return new UploadFileResult(false, "invalid file type !");
                    }
                }

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return new UploadFileResult(newFileName);
            }
            catch (Exception exp)
            {
#if DEBUG
                return new UploadFileResult(false, new List<string>() { exp.Message, exp.StackTrace });
#else
     return new UploadFileResult(false, "There was an error uploading the file");
#endif
            }
        }

        /// <summary>
        /// removes any kind of files with file path
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// upload file with base64 string and path
        /// </summary>
        /// <param name="base64"></param>
        /// <param name="path"></param>
        public static void UploadFileBase64(this string base64, string path)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(path, bytes);
        }
    }
}
