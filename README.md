# UploadFileExtention

A Library to perform file-related operations on the .net core applications

> Description

##### :100: By using this library and adding it to your project, you can skip writing codes for uploading file any types.
##### :robot: The library also performs rigorous validation when uploading files by check the file mime types.
##### :boom: By adding this package to your project, you can implement the parts related to working with files much faster.
##### :point_right: The methods and classes of this library are implemented in static and the codes are implemented executed in parallel.

---------------------------------

# [How to Install](https://www.nuget.org/packages/UploadFileExtentions/1.0.0) 

#### PackageManager : [Install-Package UploadFileExtentions -Version 1.0.0](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-powershell)

#### .Net CLI : [dotnet add package UploadFileExtentions --version 1.0.0](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli)

--------------------------------

# Methods

> Get Content Type

- GetContentType(string path) returns file type as string


> Validation :vampire:

- IsValidFile(byte[] bytFile, FileType flType, string fileContentType) returns bool as result

- IsValidImageFile(byte[] bytFile, string fileContentType) returns bool as result

- IsValidVideoFile(byte[] bytFile, string fileContentType) returns bool as result

- IsValidPdfFile(byte[] bytFile, string fileContentType) returns bool as result

- IsValidDocDocxFile(byte[] bytFile, string fileContentType) returns bool as result

- IsValidZipRarFile(byte[] bytFile, string fileContentType) returns bool as result


> Upload and Delete Files

- :octopus: UploadFileAsync(this IFormFile file, string path,string fileName="", bool generateNewFileName = false) returns UploadFileResult

- :snail: UploadFileBase64(this string base64,string path) void method

- :whale: GetDeleteFileResult(string path) returns DeleteFileResult


---------------------------

# How To Use

> using SecureFileUploadExtention.FileSecurity;


        public async Task<IActionResult> Index(IFormFile file,string path)
        {
            var uploadFileResult = await file.UploadFileAsync(path,file.Name,true);

            bool? result = uploadFileResult.IsSuccess;
            List<string> errors = uploadFileResult.Errors;
            string newFileName = uploadFileResult.NewFileName;

            return View();
        }
        
        
        
       public async Task<IActionResult> Index(IFormFile file,string path)
        {
            var uploadFileResult = await file.UploadFileAsync(path,file.Name,true);
            string newFileName = "";

            if (uploadFileResult.IsSuccess == true) newFileName = uploadFileResult.NewFileName;
            else
            {
                ViewBag.Errors= uploadFileResult.Errors;
            }

            return View(newFileName);
        }



-----------------------------------------------------

### :gift_heart: Dedicated with love to all programmers in the world _ [Ashkan Noori](https://ashkannooridev.com) :gift_heart:


