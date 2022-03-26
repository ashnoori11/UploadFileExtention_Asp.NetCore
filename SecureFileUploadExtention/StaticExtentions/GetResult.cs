using SecureFileUploadExtention.CustomResults;
using SecureFileUploadExtention.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureFileUploadExtention.StaticExtentions
{
    public static class GetResult
    {
        public static bool Succeeded(this Result result)
        {
            bool returnType = false;

            if (result == Result.Success)
                returnType = true;
            else
                returnType = false;

            return returnType;
        }

        public static bool IsFailde(this Result result)
        {
            bool returnType = false;

            if (result == Result.Faield)
                returnType = true;
            else
                returnType = false;

            return returnType;
        }

        public static bool IsNotFound(this Result result)
        {
            bool returnType = false;

            if (result == Result.NotFound)
                returnType = true;
            else
                returnType = false;

            return returnType;
        }

        public static bool HasError(this Result result)
        {
            bool returnType = false;

            if (result == Result.Error)
                returnType = true;
            else
                returnType = false;

            return returnType;
        }

        public static DeleteFileResult GetDeleteFileResult(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                return new DeleteFileResult(Result.Success, "");
            }
            catch (Exception exp)
            {
                return new DeleteFileResult(Result.Error, exp.Message);
            }
        }
    }
}
