using NLX.Robot.Kuka.Controller;
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
        private static double translateX;
        private static double translateY;
        private static double translateZ;
        private static double rotateX;
        private static double rotateY;
        private static double rotateZ;
        private static List<CartesianPosition> Trajectoire;

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Console.TreatControlCAsInput = true;
            RobotController Robot = new RobotController();
            Robot.Connect("192.168.1.1");
            Console.WriteLine("Robot connecté en position : x:" + Robot.GetCurrentPosition().X + "; y:" + Robot.GetCurrentPosition().Y + "; z: " + Robot.GetCurrentPosition().Z);

            Device Mouse = new Device();
            Mouse.Connect();
            Trajectoire = new List<CartesianPosition>();

            /*for (int i = 1; i <= 100; i++)
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
            TestMode = 0;

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
                Robot.StartRelativeMovement();
                do
                {
                    VectorToFollow.X = VectorToFollow.Y = VectorToFollow.Z = VectorToFollow.A = VectorToFollow.B = VectorToFollow.C = 0;
                    var translation = Mouse.Sensor.Translation;
                    var rotation = Mouse.Sensor.Rotation;

                    /* Affichage des translations et des rotations */

                    translateX = translation.X / 2353;
                    translateZ = translation.Y / 2702;
                    translateY = translation.Z / 2648;

                    rotateX = rotation.X;
                    rotateZ = rotation.Y;
                    rotateY = rotation.Z;

                    VectorToFollow.X = translateX;
                    VectorToFollow.Y = translateY;
                    VectorToFollow.Z = translateZ;
                    //Console.WriteLine("Translation: " + translateX + " : " + translateY + " : " + translateZ + " Rotation: " + rotateX + " : " + rotateY + " : " + rotateZ);


                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.A:
                                if (Trajectoire.Count() <= 3)
                                {
                                    Console.WriteLine("Point enregistré : x:" + Robot.GetCurrentPosition().X + "; y:" + Robot.GetCurrentPosition().Y + "; z: " + Robot.GetCurrentPosition().Z);
                                    Trajectoire.Add(new CartesianPosition
                                    {
                                        X = Robot.GetCurrentPosition().X,
                                        Y = Robot.GetCurrentPosition().Y,
                                        Z = Robot.GetCurrentPosition().Z,
                                        A = Robot.GetCurrentPosition().A,
                                        B = Robot.GetCurrentPosition().B,
                                        C = Robot.GetCurrentPosition().C

                                    });
                                }
                                break;
                            case ConsoleKey.Z:
                                if (Trajectoire.Count() == 4)
                                {
                                    Console.WriteLine("Go");
                                }
                                break;
                            case ConsoleKey.E:
                                Console.WriteLine("E");
                                break;
                            case ConsoleKey.R:
                                Console.WriteLine("R");
                                break;
                            default:
                                break;
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                     Robot.SetRelativeMovement(VectorToFollow);
                } while (cki.Key != ConsoleKey.Escape);
                Robot.StopRelativeMovement();
            }

        }
        public static void parcoursPlateau(int nbPointX, int nbPointY, double ecartX, double ecartY)
        {
            int nbPointTotal = 0;

            for (int i = 0; i < nbPointY; i++)
            {
                for (int j = 0; j < nbPointX; j++)
                {
                    nbPointTotal++;
                    Console.WriteLine("Point numéro: " + nbPointTotal + " --> " + (j * ecartX) + "; " + (i * ecartY));

                }
            }
        }
    }
}
