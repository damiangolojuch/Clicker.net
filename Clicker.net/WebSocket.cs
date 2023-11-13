using System;
using WebSocketSharp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clicker.net
{
    internal class WebSocketHandler
    {
        private WebSocket ws;

        public void Send(string message)
        {
            ws.Send(message);
        }

        public void Connect(string url, Action onSuccess)
        {
            try
            {
                ws = new WebSocket(url);
                ws.Connect();
                ws.Send("{\"event\":\"connect\"}");
                onSuccess.Invoke();
            } catch (Exception e)
            {

            }
        }

        public void Disconnect()
        {
            ws.Send("{\"event\":\"disconect\"}");
            ws.Close();
        }
    }
}
