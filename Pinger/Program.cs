using System.Net.NetworkInformation;

Ping ping = new Ping();
PingReply pingReply;

while (true)
{
    Console.WriteLine("Type IP:");
    pingReply = ping.Send(Console.ReadLine()!);

    if (pingReply.Status == IPStatus.Success)
    {
        Console.WriteLine($"Ping success: {pingReply.RoundtripTime} ms");
    }
    else
    {
        Console.WriteLine($"Ping failed: {pingReply.Status}");
    }
    System.Threading.Thread.Sleep(1000);
}
