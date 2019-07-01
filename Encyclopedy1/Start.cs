using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Encyclopedy
{
    public class Start
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENCYCLOPEDY 3.0");
            new DemoProgram().Run();

            Console.ReadKey();

        }
    }
}