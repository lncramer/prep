using System.Web;

namespace code.web
{
    public static class SendResponse
    {
        public static void asp_net(string formattedData)
        {
            HttpContext.Current.Response.Write(formattedData);
        }
    }
}