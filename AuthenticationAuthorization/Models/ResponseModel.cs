using AuthenticationAuthorization.Generics;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace AuthenticationAuthorization.Models
{
    public class ResponseModel<T> where T: class
    {
        public Pagination<T> Result { get; set; }
    }

    public class ResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
