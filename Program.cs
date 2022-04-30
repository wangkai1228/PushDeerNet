using System;

namespace PushDeer
{
    class Program
    {
        static void Main(string[] args)
        {
            PushDeerClient pushDeerClient = new PushDeerClient(new Uri("http://nas.wangkai.pro:8800/"));
            //pushDeerClient.Rename("69b0db91aa7e49490c5dd8d09ef81006", 1, "王凯的iPhone");
            //pushDeerClient.RegenKey("69b0db91aa7e49490c5dd8d09ef81006", 1);
            //pushDeerClient.GetKeyList("69b0db91aa7e49490c5dd8d09ef81006");
            //pushDeerClient.RemoveKey("69b0db91aa7e49490c5dd8d09ef81006", 1);
            //pushDeerClient.PushMessage("PDU1T5fOwGyo3bnx6twYX4ghI0yscQiTKbGRN", "C#测试2");
            //pushDeerClient.GetMessageList("69b0db91aa7e49490c5dd8d09ef81006");
            //pushDeerClient.RemoveMessage("69b0db91aa7e49490c5dd8d09ef81006", 12);
            //pushDeerClient.GenerateKey("69b0db91aa7e49490c5dd8d09ef81006");
            pushDeerClient.ClearAllMessage("69b0db91aa7e49490c5dd8d09ef81006");

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
