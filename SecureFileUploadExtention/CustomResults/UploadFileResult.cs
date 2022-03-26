using System.Collections.Generic;

namespace SecureFileUploadExtention.CustomResults
{
    public class UploadFileResult
    {
        public UploadFileResult()
        {

        }
        public UploadFileResult(bool _IsSuccess, List<string> _Errors)
        {
            IsSuccess = _IsSuccess;
            Errors = _Errors;
        }

        public UploadFileResult(bool _IsSuccess, string _NewFileName, List<string> _Errors)
        {
            IsSuccess = _IsSuccess;
            Errors = _Errors;
            NewFileName = _NewFileName;
        }

        public bool? IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public string NewFileName { get; set; }
    }
}

