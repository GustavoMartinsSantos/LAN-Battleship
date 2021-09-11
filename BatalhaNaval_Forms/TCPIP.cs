using SimpleTcp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatalhaNaval_Forms {
    public class TCPIP {
        public SimpleTcpServer server;
        public SimpleTcpClient client;
        private IPAddress ip;
        private int port;

        public IPAddress getIP () {
            return ip;
        }

        public int getPort () {
            return port;
        }

        // sending to current IP address: current port number
        public void sendMessage(string IP_Port, string message) {
            if (!string.IsNullOrEmpty(message)) {
                if (server != null)
                    server.Send(IP_Port, message);
                else
                    client.Send(message);
            }
        }

        public TCPIP(IPAddress IP, int porta, Insert_Ships form, bool isServer) {
            ip = IP;
            port = porta;

            if (isServer) {
                server = new SimpleTcpServer(ip.ToString() + ":" + port.ToString());

                server.Events.ClientConnected += form.Events_ClientConnected;

                server.Start();
            } else {
                client = new SimpleTcpClient(ip.ToString() + ":" + porta.ToString());

                client.Events.Connected += form.Events_ServerConnected;
            }
        }

        public static List<string> GetLocalIPAddress() {
            List<string> IPs = new List<string>();
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    IPs.Add(ip.ToString());
                }
            }

            return IPs;
        }

        public void setEventsForm2(PartidaForm form) {
            if (server != null) {
                server.Events.ClientDisconnected += form.Events_ClientDisconnected;
                server.Events.DataReceived += form.Events_ClientDataReceived;
            } else {
                client.Events.Disconnected += form.Events_Disconnected;
                client.Events.DataReceived += form.Events_ServerDataReceived;
            }
        }
    }
}
