using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Configuration
    {
        public const int DefaultStatusCode = 200;
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;

        public static string ConnectionString { get; set; }

        public static string BackendUrl { get; set; }

        public static string FrontendUrl { get; set; }
    }
}
