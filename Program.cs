using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_NovaLynx
{
    class Program
    {
        static TDx.TDxInput.Device device;
        static NLX.Robot.Kuka.Controller.RobotController robotController;

        static void Main(string[] args)
        {

            /* Declaration des variables */
            double x_Min = 0;
            double y_Min = 0;
            double z_Min = 0;
            double x_Max = 0;
            double y_Max = 0;
            double z_Max = 0;
            double valeurX;
            double valeurY;
            double valeurZ;

            Console.WriteLine("Start...");
            device = new TDx.TDxInput.Device();
            device.Connect();
            robotController = new NLX.Robot.Kuka.Controller.RobotController();
            //robotController.Connect("192.168.1.1");

            ConsoleKeyInfo info;
            
            while (true)
            {
                var translation = device.Sensor.Translation;
                var rotation = device.Sensor.Rotation;
                int name = device.Keyboard.Keys;

                /* Affichage des translations et des rotations */
                //Console.WriteLine("Translation: " + translation.X + " : " + translation.Y + " : " + translation.Z);
                //Console.WriteLine("Rotation: " + rotation.X + " : " + rotation.Y + " : " + rotation.Z + "\n");

                valeurX = translation.X / 2353;
                valeurY = translation.Y / 2702;
                valeurZ = translation.Z / 2648;

                //Console.WriteLine("X: " + valeurX);
                //Console.WriteLine("Y: " + valeurY);
                //Console.WriteLine("Z: " + valeurZ);

                info = Console.ReadKey();

                if (info.Key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine("You pressed UP !");
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    Console.WriteLine("You pressed DOWN !");
                }
                else if (info.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("You pressed LEFT !");
                }
                else if (info.Key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("You pressed RIGHT !");
                }
                System.Threading.Thread.Sleep(100);
            }

        }
    }
}
