using System;
using System.Net;
using System.Reflection;

namespace MQOBot.Webclients
{
    class WebClientEx : WebClient
    {
        private CookieContainer container = new CookieContainer();
        private WebRequest _Request = null;

        public WebClientEx(CookieContainer container)
        {
            this.container = container;
        }

        public WebClientEx()
        {
            // TODO: Complete member initialization
        }

        public CookieContainer CookieContainer
        {
            get { return container; }
            set { container = value; }
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            this._Request = base.GetWebRequest(address);
            var request = this._Request as HttpWebRequest;

            if (this._Request is HttpWebRequest)
            {
                ((HttpWebRequest)this._Request).AllowAutoRedirect = false;
            }

            if (request != null)
            {
                request.CookieContainer = container;
            }

            return this._Request;
        }

        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            try
            {
                WebResponse response = base.GetWebResponse(request, result);
                ReadCookies(response);
                return response;
            }
            catch (System.Net.WebException e)
            {
                return e.Response;
            }

        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            ReadCookies(response);

            return response;
        }

        private void ReadCookies(WebResponse r)
        {
            var response = r as HttpWebResponse;
            if (response != null)
            {
                CookieCollection cookies = response.Cookies;
                container.Add(cookies);
            }
        }

        public HttpStatusCode StatusCode()
        {
            HttpStatusCode result;

            if (this._Request == null)
            {
                throw (new InvalidOperationException("Unable to retrieve the status code, maybe you haven't made a request yet."));
            }

            HttpWebResponse response = base.GetWebResponse(this._Request) 
                                       as HttpWebResponse;

            if (response != null)
            {
                result = response.StatusCode;
            }
            else
            {
                throw (new InvalidOperationException("Unable to retrieve the status code, maybe you haven't made a request yet."));
            }

            return result;
        }
    }
}
