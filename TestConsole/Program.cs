using System;
using OmniSenseNetwork.GSP.DAL.Entities;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var db = new GSPEntities();
            for (int i = 0; i < 3; i++)
            {
                db.Partner.Add(new Partner { Name = $"MedicalCentre_{i}" });
                db.SaveChanges();
            }

            Console.WriteLine("Changes have been saved.");
        }
    }
}
