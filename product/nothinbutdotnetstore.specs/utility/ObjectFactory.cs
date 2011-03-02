using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
    public class ObjectFactory
    {
        public class web
        {
            public static HttpContext create_http_context()
            {
                return new HttpContext(create_request(), create_response());
            }

            static HttpRequest create_request()
            {
                return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
            }

            static HttpResponse create_response()
            {
                return new HttpResponse(new StringWriter());
            }
        }

        public static IEnumerable<T> create_a_set_of<T>(int number_to_create, Func<T> factory)
        {
            return Enumerable.Range(1, number_to_create).Select(x => factory());
        }
    }
}