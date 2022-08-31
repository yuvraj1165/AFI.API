namespace AFI.API.Models
{
    public class APIErrorResponse
    {
        public string HttpResponseCode { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorMoreInfo { get; set; }
    }
}