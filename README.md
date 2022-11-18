# UploadFileExtention

A Library to perform file-related operations on the .net core applications

> Description

##### :100: By using this library and adding it to your project, you can skip writing codes for uploading file any types.
##### :robot: The library also performs rigorous validation when uploading files by check the file mime types.
##### :boom: By adding this package to your project, you can implement the parts related to working with files much faster.
##### :point_right: The methods and classes of this library are implemented in static and the codes are implemented executed in parallel.

---------------------------------

# [How to Install](https://www.nuget.org/packages/UploadFileExtentions/2.0.0) 

#### PackageManager : [Install-Package UploadFileExtentions -Version 2.0.0](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-powershell)

#### .Net CLI : [dotnet add package UploadFileExtentions --version 2.0.0](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli)

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

- :octopus: UploadFileAsync(this IFormFile file, string path,FileType type,string fileName="", bool generateNewFileName = false)

- :snail: UploadFileBase64(this string base64,string path)

- :whale: void(string path)


---------------------------

# How To Use

> using SecureFileUploadExtention.FileSecurity;


IFormFile file=attachment;
var uploadFileResult = await file.UploadFileAsync(path,FileType.Video,file.Name,true);
            



-----------------------------------------------------

### :gift_heart: Dedicated with love to all programmers in the world _ [Ashkan Noori](https://ashkannooridev.com) :gift_heart:


