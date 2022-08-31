using AFI.API.CustomResponses;
using AFI.API.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AFI.API.Controllers
{
    public class AFIAPIControllerBase : ControllerBase
    {
        internal ObjectResult AFIAPIErrorResponse(string httpResponseCode, ApiErrorSubCode apiErrorSubCode, string errorMessage)
        {
            return base.StatusCode(Convert.ToInt32(httpResponseCode), CustomAPIErrorResponse.CreateResponse(httpResponseCode, apiErrorSubCode, errorMessage, null));
        }

        internal ObjectResult AFIAPIErrorResponse(string httpResponseCode, ApiErrorSubCode apiErrorSubCode, string errorMessage, ModelStateDictionary modelState)
        {
            List<string> modelErrors = modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage)).ToList();
            return base.StatusCode(Convert.ToInt32(httpResponseCode), CustomAPIErrorResponse.CreateResponse(httpResponseCode, apiErrorSubCode, errorMessage, modelErrors));
        }
    }
}