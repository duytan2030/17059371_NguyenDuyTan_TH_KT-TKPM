using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_sim
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("192.168.1.69", 5000);
            Console.WriteLine("connect successfull");
            Stream stream = tcpClient.GetStream();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString());
            stream.Write(data, 0, data.Length);
            data = new byte[1024];
            stream.Read(data, 0, 1024);
            Console.WriteLine(encoding.GetString(data));
            Console.ReadKey();
        }
    }
}
