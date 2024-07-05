using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Responses
{
    public class Response<TData>
    {
        private readonly int _code;

        //Parameterless and JSonContructor define the Construct that is necessary to use
        [JsonConstructor]
        public Response() => _code = Configuration.DefaultStatusCode;

        //Code is a option parameters
        public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            Data = data;
            Message = message;
            _code = code;
        }
        public TData? Data { get; set; }
        public string? Message { get; set; }
        
        //With JsonIgnore IsSucess is not showing in the page
        [JsonIgnore] 
        public bool IsSucess => _code is >= 200 and <= 299;
        public int Code => _code;

    }
}
