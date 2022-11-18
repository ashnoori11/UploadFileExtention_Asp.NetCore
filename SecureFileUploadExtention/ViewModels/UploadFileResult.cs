using System.Collections.Generic;

namespace SecureFileUploadExtention.CustomResults
{
    public record UploadFileResult
    {
        public UploadFileResult(bool _IsSuccess, List<string> _Errors)
        {
            IsSuccess = _IsSuccess;
            Errors = _Errors;
        }

        public UploadFileResult(bool _IsSuccess, string error)
        {
            IsSuccess = _IsSuccess;
            this.Errors.Add(error);
        }

        public UploadFileResult(bool _IsSuccess, string _NewFileName, List<string> _Errors)
        {
            IsSuccess = _IsSuccess;
            Errors = _Errors;
            NewFileName = _NewFileName;
        }

        public UploadFileResult(string _NewFileName)
        {
            IsSuccess =true;
            NewFileName = _NewFileName;
        }

        #region methods
        public void AddUploadFileErrors(List<string> errors)
        => this.Errors = errors;
        #endregion

        public bool IsSuccess { get; private set; }
        public IList<string> Errors { get; private set; }
        public string NewFileName { get; private set; }
    }
}

