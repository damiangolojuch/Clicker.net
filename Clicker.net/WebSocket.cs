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

        public async void Send(string message)
        {
            ws.Send(message);
        }

        public async void Connect(string url, Action onSuccess)
        {
            try
            {
                ws = new WebSocket(url);
                ws.Connect();
                ws.Send("hello :0");
                onSuccess.Invoke();
            } catch (Exception e)
            {

            }
        }

        public async void Disconnect()
        {
            ws.Close();
        }
    }
}
