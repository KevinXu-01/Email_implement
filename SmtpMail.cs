using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace E_mail_implements
{
    public class SmtpMail
    {
        private TcpClient SmtpClient;
        private NetworkStream stream;
        private StreamReader rstream;
        //private String smd;
        Byte[] data;
        //private String CRLF = "\r\n";

        public void Connect(String server)
        {
            try
            {
                // Create a TcpClient.
                Int32 port = 25;
                SmtpClient = new TcpClient(server, port);
            } 
            catch(ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public void sendMessage(String message)
        {
            try
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                stream = SmtpClient.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public String getStatus()
        {
            // Get a client stream for reading and writing.
            rstream = new StreamReader(SmtpClient.GetStream());

            String tmp = rstream.ReadLine();
            return tmp;
        }
    }
}
