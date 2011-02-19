using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTService
{
    public class Result
    {
        public int ErrorCode = 0;
        public string Message = string.Empty;
        public object Data;

        public Result()
        {
        }

        public Result(string message)
        {
            this.Message = message;
        }

        public Result(int code, string message)
        {
            this.ErrorCode = code;
            this.Message = message;
        }

        public Result(int code, object data)
        {
            this.ErrorCode = code;
            this.Data = data;
        }

        public Result(int code, string message, object data)
        {
            this.ErrorCode = code;
            this.Message = message;
            this.Data = data;
        }
    }
}
