using System.Net.NetworkInformation;

Ping ping = new Ping();
PingReply pingReply;

while (true)
{
    Console.WriteLine("Type IP:");
    try
    {
        pingReply = ping.Send(Console.ReadLine()!);

        if (pingReply.Status == IPStatus.Success)
        {
            Console.WriteLine($"Ping success: {pingReply.RoundtripTime} ms");
        }
        else
        {
            Console.WriteLine($"Ping failed: {pingReply.Status}");

        }
    }
    catch (Exception ex) { Console.WriteLine("Wrong IP"); }
    System.Threading.Thread.Sleep(500);
}
