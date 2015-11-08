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
            String bouton = device.Keyboard.GetKeyName(1);
            Console.WriteLine(bouton);
            
            bouton = device.Keyboard.GetKeyName(2);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(3);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(4);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(5);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(6);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(7);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(8);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(9);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(10);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(11);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(12);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(13);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(14);
            Console.WriteLine(bouton);

            bouton = device.Keyboard.GetKeyName(15);
            Console.WriteLine(bouton);

            while (true)
            {
                var translation = device.Sensor.Translation;
                var rotation = device.Sensor.Rotation;

                /* Affichage des translations et des rotations */
                //Console.WriteLine("Translation: " + translation.X + " : " + translation.Y + " : " + translation.Z);
                //Console.WriteLine("Rotation: " + rotation.X + " : " + rotation.Y + " : " + rotation.Z + "\n");

                valeurX = translation.X / 2353;
                valeurY = translation.Y / 2702;
                valeurZ = translation.Z / 2648;
                

                System.Threading.Thread.Sleep(200);
            }

        }
    }
}
