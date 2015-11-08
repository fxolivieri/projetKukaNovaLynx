﻿using NLX.Robot.Kuka.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDx.TDxInput;

namespace pinceConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotController Robot = new RobotController();
            Robot.Connect("192.168.1.1");
            Console.WriteLine("Robot connecté ... ");
    //        Console.WriteLine("Robot position : x:" + Robot.GetCurrentPosition().X + "; y:" + Robot.GetCurrentPosition().Y + "; z: " + Robot.GetCurrentPosition().Z);
    /*
            List<CartesianPosition> Trajectoire = new List<CartesianPosition>();
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
            //Robot.PlayTrajectory(Trajectoire);
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
            Device Mouse = new Device();

            //-------------------------------------------------
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Type number and press Return");
                Console.WriteLine("press 2 pour ouvrir la pince");
                Console.WriteLine("press 3 pour fermer la pince");
                try
                {
                    int i = int.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 0:
                            {
                                for (int ii = 1; ii <= 20; ii++)
                                {
                                    bool pinceOuverte = Robot.IsGripperOpen();
                                    //bool pinceOuverte = true;
                                    Console.WriteLine("Pince ouverte : ");
                                    Console.WriteLine(pinceOuverte);                                
                                }
                                break;
                            }
                        case 1:
                            {
                                for (int ii = 1; ii <= 20; ii++)
                                {
                                    var valeurCapteur = Robot.ReadSensor();
                                    //int valeurCapteur = 12345;
                                    Console.WriteLine("Valeur du capteur : ");
                                    Console.WriteLine(valeurCapteur);
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Ouvrir la pince");
                                Robot.OpenGripper();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Fermer la pince");
                                Robot.CloseGripper();
                                break;
                            }
                        default:
                            {
                                System.Console.WriteLine("Other number");
                                break;
                            }
                    }
                }
                catch
                {
                }
                System.Threading.Thread.Sleep(50);
            }
            //-------------------------------------------------

        }
    }
}