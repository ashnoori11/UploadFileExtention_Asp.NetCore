using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureFileUploadExtention.Enums
{
    public enum Result
    {
        Success = 1,
        Faield = 2,
        NotFound = 3,
        Error = 4,
        CantDelete = 6,
        NotAllowed = 7,
    }
}
