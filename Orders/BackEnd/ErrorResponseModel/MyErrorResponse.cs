﻿namespace BackEnd.ErrorResponseModel
{
    public class MyErrorResponse
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public int StatusCode { get; set; }


        public MyErrorResponse(Exception ex, int statusCode)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.ToString();
            StatusCode = statusCode;
        }
    }
}
