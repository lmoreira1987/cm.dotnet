using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQ
{
    /// <summary>
    /// In this part of the code we'll write two programs in C#; a producer that sends a single message, 
    ///   and a consumer that receives messages and prints them out
    ///   * Install the Server 
    ///       Firstly, download and run the Erlang Windows Binary File. It takes around 5 minutes.
    ///       Then just run the installer, rabbitmq-server-3.6.4.exe. It takes around 2 minutes, and will set RabbitMQ up and running as a service, with a default configuration.
    /// </summary>
    /// <install>
    ///   * Install the Server 
    ///       Firstly, download and run the Erlang Windows Binary File. It takes around 5 minutes.
    ///       Then just run the installer, rabbitmq-server-3.6.4.exe. It takes around 2 minutes, and will set RabbitMQ up and running as a service, with a default configuration.
    ///       
    /// *** RUN rabbitMQ management: C:\Program Files\RabbitMQ Server\rabbitmq_server-3.6.4\sbin>rabbitmq-plugins enable rabbitmq_management ***
    /// *** Restart services.msc RabbitMQ
    /// 
    /// http://localhost:15672/
    /// USER: guest
    /// PASSWORD: guest
    /// 
    ///   https://www.rabbitmq.com/install-windows.html
    ///   http://www.erlang.org/downloads
    /// </install>
    class Program
    {


        static void Main(string[] args)
        {
        }
    }
}
