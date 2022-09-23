using CosmosStrategy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmosStrategy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            GameManager gm = new GameManager(200, 200);
            //gm.PrintMap();
            gm.CreateUnit(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
            gm.AddResources();
            gm.CreateUnit(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
            gm.ShowPattern(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), true);
            gm.ShowPattern(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), false);
            gm.AttackSelected(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
        }
    }
}
