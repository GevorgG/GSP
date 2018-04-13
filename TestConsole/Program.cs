using System;
using OmniSenseNetwork.GSP.BLL.Redis;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var db = new GSPEntities();
            //for (int i = 0; i < 3; i++)
            //{
            //    db.Partner.Add(new Partner { Name = $"MedicalCentre_{i}" });
            //    db.SaveChanges();
            //}

            //var redisCoreBL = RedisBLFactory.CreateRedisCoreBL() as RedisCoreBL;
            //redisCoreBL.SetStringValue("key_1", "value_1");
            //redisCoreBL.SetStringValue("key_2", "value_2");

            //var v2 = redisCoreBL.GetStringValue("key_2");

            Console.WriteLine(RedisEventType.Expired);
        }
    }
}
