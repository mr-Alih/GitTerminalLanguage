
using System;
using System.IO;

namespace GTL.ProcessRunner
{
    public class ConnectionRunner
    {
        public void Start()
        {
            if (!File.Exists(".con"))
                EstablishConnection();

            Directory.CreateDirectory("./Server");
            Directory.CreateDirectory("./Local");

            if (!File.Exists("./Server/.server"))
                EstablishSession();

            if (!File.Exists("./Local/.local"))
                EstablishLocal();

            Console.WriteLine("[GTL] Connection established.");
        }

        private void EstablishConnection()
        {
            string content =
                Random.Shared.Next(1111111, 8999999).ToString();

            File.WriteAllText(".con", content);
        }

        private void EstablishSession()
        {
            string content =
                Random.Shared.Next(1111111, 8999999).ToString();

            File.WriteAllText("./Server/.server", content);
        }

        private void EstablishLocal()
        {
            string content =
                Random.Shared.Next(1111111, 8999999).ToString();

            File.WriteAllText("./Local/.local", content);
        }
    }
}
