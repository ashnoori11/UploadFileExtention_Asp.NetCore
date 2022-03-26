using SecureFileUploadExtention.Enums;

namespace SecureFileUploadExtention.CustomResults
{
    public class DeleteFileResult
    {
        public DeleteFileResult(Result DeleteResult, string Errors)
        {
            this.DeleteResult = DeleteResult;
            this.Errors = Errors;
        }

        public Result DeleteResult { get; set; }
        public string Errors { get; set; }
    }
}

