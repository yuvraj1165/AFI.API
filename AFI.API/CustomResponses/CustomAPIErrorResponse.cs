using AFI.API.Enums;
using AFI.API.Models;
using System;
using System.Collections.Generic;

namespace AFI.API.CustomResponses
{
    public static class CustomAPIErrorResponse
    {
        private static int _apiId = 31;

        private static string _errorMoreInfo = "https://somedeveloperinfo.afi.com";

        private static string _httpResponseCode;
        private static string _subCode;

        private static string _errorCode
        {
            get
            {
                return $"{_httpResponseCode}.{_apiId}.{_subCode}";
            }
        }

        public static APIErrorResponse CreateResponse(string httpResponseCode, ApiErrorSubCode apiErrorSubCode, string errorMessage)
        {
            return CreateResponse(httpResponseCode, apiErrorSubCode, errorMessage, null);
        }

        public static APIErrorResponse CreateResponse(string httpResponseCode, ApiErrorSubCode apiErrorSubCode, string errorMessage, List<string> errorList)
        {
            if (errorList != null)
                errorMessage = $"{errorMessage}-{string.Join<string>("," + Environment.NewLine, errorList)}";

            _httpResponseCode = httpResponseCode;
            _subCode = ((int)apiErrorSubCode).ToString();

            return new APIErrorResponse
            {
                ErrorCode = _errorCode,
                ErrorMessage = errorMessage,
                ErrorMoreInfo = _errorMoreInfo,
                HttpResponseCode = _httpResponseCode
            };
        }
    }
}