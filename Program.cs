﻿using NLX.Robot.Kuka.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDx.TDxInput;

namespace KukkaMove
{
    class Program
    {
        private static CartesianPosition VectorToFollow = new CartesianPosition();
        private static double valeurX;
        private static double valeurY;
        private static double valeurZ;

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Console.TreatControlCAsInput = true;
            //RobotController Robot = new RobotController();
            //Robot.Connect("192.168.1.1");
            //Console.WriteLine("Robot connecté en position : x:" + Robot.GetCurrentPosition().X + "; y:" + Robot.GetCurrentPosition().Y + "; z: " + Robot.GetCurrentPosition().Z);

            Device Mouse = new Device();
            Mouse.Connect();

            /*List<CartesianPosition> Trajectoire = new List<CartesianPosition>();
            for (int i = 1; i <= 100; i++)
            {

                Trajectoire.Add(new CartesianPosition
                {
                    X = i + Robot.GetCurrentPosition().X,
                    Y = i + Robot.GetCurrentPosition().Y,
                    Z = i + Robot.GetCurrentPosition().Z,
                    A = 0 + Robot.GetCurrentPosition().A,
                    B = 0 + Robot.GetCurrentPosition().B,
                    C = 0 + Robot.GetCurrentPosition().C

                });
            }
            Robot.PlayTrajectory(Trajectoire);
            Robot.StartRelativeMovement();
            CartesianPosition Test = new CartesianPosition
            {

                X = -1,
                Y = 0,
                Z = 0,
                A = 0,
                B = 0,
                C = 0
            };
           
            Robot.SetRelativeMovement(Test);
            System.Threading.Thread.Sleep(2000);
            Robot.StopRelativeMovement();

            */
            int TestMode;
            TestMode = 1;

            Console.WriteLine("Press the Escape (Esc) key to quit: \n");

            if (TestMode == 1)
            {
                do
                {
                        cki = Console.ReadKey();
                        VectorToFollow.X = VectorToFollow.Y = VectorToFollow.Z = VectorToFollow.A = VectorToFollow.B = VectorToFollow.C = 0;
                        if (cki.Key.ToString() == "UpArrow")
                        {
                            Console.WriteLine("Up");
                            VectorToFollow.X = 1;
                        }
                        else if (cki.Key.ToString() == "RightArrow")
                        {
                               Console.WriteLine("Right");
                            VectorToFollow.Y = 1;
                        }

                        else if (cki.Key.ToString() == "LeftArrow")
                        {
                             Console.WriteLine("Left");
                            VectorToFollow.Y = -1;
                        }

                        else if (cki.Key.ToString() == "DownArrow")
                        {
                             Console.WriteLine("Down");
                            VectorToFollow.X = -1;
                        }

                        else if (cki.Key.ToString() == "Add")
                        {
                            Console.WriteLine("Add");
                            VectorToFollow.Z = 1;
                        }

                        else if (cki.Key.ToString() == "Subtract")
                        {
                            Console.WriteLine("Sub");
                            VectorToFollow.Z = -1;
                        }

                        /*Robot.StartRelativeMovement();
                        Robot.SetRelativeMovement(VectorToFollow);
                        System.Threading.Thread.Sleep(1000);
                        Robot.StopRelativeMovement();*/

                } while (cki.Key != ConsoleKey.Escape);
            }
            else
            {
                //Robot.StartRelativeMovement();
                do
                {
                    var translation = Mouse.Sensor.Translation;
                    var rotation = Mouse.Sensor.Rotation;

                    /* Affichage des translations et des rotations */

                    valeurX = translation.X / 2353;
                    valeurZ = translation.Y / 2702;
                    valeurY = translation.Z / 2648;

                    VectorToFollow.X = valeurX;
                    VectorToFollow.Y = valeurY;
                    VectorToFollow.Z = valeurZ;
                    Console.WriteLine("Translation: " + valeurX + " : " + valeurY + " : " + valeurZ);

                    System.Threading.Thread.Sleep(500);
                    // Robot.SetRelativeMovement(VectorToFollow);
                } while (cki.Key != ConsoleKey.Escape);
                //Robot.StopRelativeMovement();
            }

        }
    }
}