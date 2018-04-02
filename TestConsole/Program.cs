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
            db.Partner.Add(new Partner{ Name = "MedicalCentre" });
            db.SaveChanges();

            Console.WriteLine("Changes have been saved.");
        }
    }
}
