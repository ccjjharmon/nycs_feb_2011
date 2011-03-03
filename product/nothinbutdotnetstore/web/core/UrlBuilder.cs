using System;
using System.Linq.Expressions;
using nothinbutdotnetstore.utility;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.web.core
{
    public class UrlBuilder<PayloadType>
    {
        private string url;
        private PayloadType payload;
        
        public UrlBuilder() : this("")
        {
        }

        public UrlBuilder(string url)
        {
            this.url = url;
        }
        
        public UrlBuilder<PayloadType> include_in_payload(PayloadType payload)
        {
            this.payload = payload;
            return this;
        }

        static string get_name_of_property<ItemToInspect>(Expression<Func<ItemToInspect, object>> property_accessor)
        {
            return property_accessor.Body.downcast_to<MemberExpression>()
                .Member.Name;
        }

        public UrlBuilder<PayloadType> the_detail(Expression expression)
        {
            AddToUrl(expression);
            return this;
        }

        void AddToUrl(Expression expression)
        {
            //throw new NotSupportedException();
            this.url = this.url + "?" + "name" + "=" + "value";
            //this.url = this.url + "?" + expression.Body.downcast_to<PayloadType>().Member.Name + "=" + "value";
        }

        public string ToString()
        {
            return this.url;
        }
    }
}