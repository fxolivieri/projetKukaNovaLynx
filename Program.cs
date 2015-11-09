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
        private static int closeGripper;
        private static List<CartesianPosition> Trajectoire;
        private static List<CartesianPosition> BeginningPoint;
        private static List<CartesianPosition> PointToGo;
        private static ConsoleKeyInfo key;
        private static List<CartesianPosition> TrajectoriesList = new List<CartesianPosition>();

        static void Main(string[] args)
        {
            Console.TreatControlCAsInput = true;
            RobotController Robot = new RobotController();

            Device Mouse = new Device();
            Mouse.Connect();

            ProgramXML xmlProg = new ProgramXML();

            Trajectoire = new List<CartesianPosition>();
            BeginningPoint = new List<CartesianPosition>();
            PointToGo = new List<CartesianPosition>();

            int whichTrajectory = 0;
            closeGripper = 0;

            //Robot.Connect("192.168.1.1");
            //Console.WriteLine("Robot connecté en position : x:" + Robot.GetCurrentPosition().X + "; y:" + Robot.GetCurrentPosition().Y + "; z: " + Robot.GetCurrentPosition().Z);

            List<CartesianPosition> trajectoryToAdd = new List<CartesianPosition>();
            trajectoryToAdd.Add(new CartesianPosition
            {
                X = 513.64,
                Y = 133.94,
                Z = 219.75,
                A = -69.23,
                B = 86.72,
                C = -165.68,
            });
            //if (!Robot.IsGripperOpen()) Robot.OpenGripper();
            //Robot.PlayTrajectory(trajectoryToAdd);

            int teachMode = 0;
            Console.WriteLine("Press 1 for launch program with predefined points or 2 for take new points. \n");
            while (teachMode == 0)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        teachMode = 2;
                        Console.WriteLine("Predefined points enable");
                        break;
                    case ConsoleKey.Z:
                        Console.WriteLine("Teach mode enable");
                        teachMode = 1;
                        break;

                }
            }

            if (teachMode == 2)
            {
                Console.WriteLine("Predefined mode go");
                trajectoryToAdd.Clear();

                trajectoryToAdd.Add(new CartesianPosition
                {
                    X = 498.30,
                    Y = 228.18,
                    Z = 213.9987,
                    A = -69.23,
                    B = 86.72,
                    C = -165.68,
                });

                //Robot.PlayTrajectory(trajectoryToAdd);
                trajectoryToAdd.Clear();

                trajectoryToAdd = xmlProg.readXml("C:/Users/Brice-PC/Desktop/kukaAgilus.xml");
                TrajectoriesList = creationPlateau(trajectoryToAdd, 4, 4);

                for (int i=0; i< TrajectoriesList.Count(); i++)
                {

                    if (TrajectoriesList[whichTrajectory] != null)
                    {
                        PointToGo.Clear();
                        PointToGo.Add(TrajectoriesList[whichTrajectory]);
                        //Robot.PlayTrajectory(PointToGo);
                        Console.WriteLine(TrajectoriesList[whichTrajectory].X + " " + TrajectoriesList[whichTrajectory].Y + " " + TrajectoriesList[whichTrajectory].Z);
                        if (closeGripper < 2 && closeGripper > 0)
                        {
                            closeGripper++;
                            Console.WriteLine("++");
                        }
                        else if (closeGripper == 2)
                        {
                            //Robot.CloseGripper();
                            closeGripper = 0;
                            Console.WriteLine("Pince Fermée");
                        }
                            if (TrajectoriesList[whichTrajectory].Z == 100)
                        {
                            //Robot.OpenGripper();
                            closeGripper++;
                            Console.WriteLine("Pince Ouverte");
                        }
                        whichTrajectory++;
                        Console.WriteLine("Press ESC for stopping. \n");
                        key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.Escape:
                                Console.WriteLine("Stop");
                                System.Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                }


            }
            else if (teachMode == 1)
            {
                Console.WriteLine("Press 1 to register point, 2 for enable translation, 3 for enable rotation and 4 for launch animation. Press ESC if you want to stop the program. \n");
                int modeEnable = 0;
                int programRunning = 1;

                Robot.StartRelativeMovement();
                while(programRunning != 0)
                {
                    if (modeEnable == 3)
                    {
                        Console.WriteLine("Press 1 to rebegin, press 2 to continue and ESC for stopping. \n");
                        key = Console.ReadKey(true);
                        switch (key.Key)
                        {

                            case ConsoleKey.A:
                                modeEnable = 1;
                                Console.WriteLine("Rebegin");
                                Trajectoire.Clear();
                                break;

                            case ConsoleKey.Z:
                                Console.WriteLine("Suivant");
                                break;
                            case ConsoleKey.Escape:
                                Console.WriteLine("Stop");
                                programRunning = 0;
                                break;
                        }
                    }
                    else
                    {
                        VectorToFollow.X = VectorToFollow.Y = VectorToFollow.Z = VectorToFollow.A = VectorToFollow.B = VectorToFollow.C = 0;
                        if (Console.KeyAvailable)
                        {
                            key = Console.ReadKey(true);
                            switch (key.Key)
                            {
                                case ConsoleKey.A:
                                    if (Trajectoire.Count() <= 3 && modeEnable != 0)
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
                                    Console.WriteLine("Translation mode");
                                    modeEnable = 1;
                                    break;
                                case ConsoleKey.E:
                                    Console.WriteLine("Rotation mode");
                                    modeEnable = 2;
                                    break;
                                case ConsoleKey.R:
                                    if (Trajectoire.Count() == 4)
                                    {
                                        Console.WriteLine("\nGo");
                                        Robot.StopRelativeMovement();
                                        BeginningPoint.Add(Trajectoire[0]);
                                        TrajectoriesList = creationPlateau(Trajectoire, 4, 4);
                                        if (!Robot.IsGripperOpen()) Robot.OpenGripper();
                                        Robot.PlayTrajectory(BeginningPoint);
                                        modeEnable = 3;
                                    }
                                    break;
                                case ConsoleKey.Escape:
                                    programRunning = 0;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    if (modeEnable != 0)
                    {

                        /* Affichage des translations et des rotations */

                        if (modeEnable == 1)
                        {
                            var translation = Mouse.Sensor.Translation;
                            translateX = -translation.Z / 2648;
                            translateZ = translation.Y / 2702;
                            translateY = -translation.X / 2648;
                            VectorToFollow.X = translateX*12.0;
                            VectorToFollow.Y = translateY*12.0;
                            VectorToFollow.Z = translateZ*12.0;

                            System.Threading.Thread.Sleep(100);

                            if (robotCanMove(Robot, translateX, translateY))Robot.SetRelativeMovement(VectorToFollow);

                        }
                        else if (modeEnable == 2)
                        {
                            var rotation = Mouse.Sensor.Rotation;
                            rotateX = rotation.X * (rotation.Angle / 2062);
                            rotateZ = rotation.Y * (rotation.Angle / 2062);
                            rotateY = rotation.Z * (rotation.Angle / 2062);
                            VectorToFollow.A = rotateX;
                            VectorToFollow.B = rotateZ;
                            VectorToFollow.C = rotateY;

                            System.Threading.Thread.Sleep(100);

                            if (robotCanMove(Robot, translateX, translateY)) Robot.SetRelativeMovement(VectorToFollow);
                        }
                        else if (modeEnable == 3)
                        {
                            if (TrajectoriesList[whichTrajectory] != null)
                            {
                                PointToGo.Clear();
                                PointToGo.Add(TrajectoriesList[whichTrajectory]);
                                Robot.PlayTrajectory(PointToGo);
                                Console.WriteLine(TrajectoriesList[whichTrajectory].X + " " + TrajectoriesList[whichTrajectory].Y + " " + TrajectoriesList[whichTrajectory].Z);
                                if (closeGripper < 2 && closeGripper > 0)
                                {
                                    closeGripper++;
                                }
                                else if (closeGripper == 2)
                                {
                                    Robot.CloseGripper();
                                    closeGripper = 0;
                                }
                                if (TrajectoriesList[whichTrajectory].Z == 100)
                                {
                                    Robot.OpenGripper();
                                    closeGripper++;
                                }
                                whichTrajectory++;
                            }
                        }

                    }
                }
                if (modeEnable == 1 || modeEnable == 2) Robot.StopRelativeMovement();
            }

        }
        public static List<CartesianPosition> creationPlateau(List<CartesianPosition> list, int nbPointLongueur, int nbPointHauteur)
        {
            List<CartesianPosition> listPoints = new List<CartesianPosition>();
            CartesianPosition leverRondin = new CartesianPosition();
            CartesianPosition currentPoint = new CartesianPosition();

            // Déterminer tes 16 points
            double point1_X = list[1].X;
            double point1_Y = list[1].Y;
            double point1_Z = list[1].Z;
            double point1_A = list[1].A;
            double point1_B = list[1].B;
            double point1_C = list[1].C;


            double deltaY = Math.Abs(list[1].Y - list[2].Y);
            double deltaX = Math.Abs(list[1].X - list[2].X);

            double Angle = Math.Atan2(deltaY, deltaX);

            // Distance y et x
            double distX = Math.Sqrt(Math.Pow(list[2].X - list[1].X, 2) + Math.Pow(list[2].Y - list[1].Y, 2));
            double distY = Math.Sqrt(Math.Pow(list[3].X - list[1].X, 2) + Math.Pow(list[3].Y - list[1].Y, 2));
            Console.WriteLine("Distance X :"+ distX +" Distance en Y :"+ distY + "\n");

            for (int j = 0; j < nbPointHauteur; j++)
            {
                for (int i = 0; i < nbPointLongueur; i++)
                {
                    // Ajout du point a la liste
                    listPoints.Add(new CartesianPosition
                    {
                        X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 3 + point1_X,
                        Y =  ((distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle))) / 3 + point1_Y,
                        Z = point1_Z,
                        A = point1_A,
                        B = point1_B,
                        C = point1_C

                    });
                    double X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 3 + point1_X;
                    double Y = ((distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle))) / 3 + point1_Y;
                    Console.WriteLine(X + " ; " + Y + " ; " + point1_Z + " ; " + point1_A + " ; " + point1_B + " ; "+ point1_C);
                }
            }
            leverRondin.X = list[0].X;
            leverRondin.Y = list[0].Y;
            leverRondin.Z = list[0].Z + 100;
            leverRondin.A = list[0].A;
            leverRondin.B = list[0].B;
            leverRondin.C = list[0].C;
            Console.WriteLine("\n");

            for (int currentTrajectory = 1; currentTrajectory < listPoints.Count(); currentTrajectory++)
            {
                CartesianPosition lacherRondin = new CartesianPosition
                {
                    X = listPoints[currentTrajectory].X,
                    Y = listPoints[currentTrajectory].Y,
                    Z = 100,
                    A = listPoints[currentTrajectory].A,
                    B = listPoints[currentTrajectory].B,
                    C = listPoints[currentTrajectory].C,

                };

                currentPoint = listPoints[currentTrajectory];

                //Aller

                TrajectoriesList.Add(leverRondin);
                TrajectoriesList.Add(currentPoint);
                TrajectoriesList.Add(lacherRondin);

                //Retour
                
                TrajectoriesList.Add(currentPoint);
                TrajectoriesList.Add(list[0]);

                lacherRondin = null;
                //Console.WriteLine("Trajectory " + currentTrajectory + " :" + leverRondin.X + ";" + leverRondin.Y + ";" + leverRondin.Z + " go to " + listPoints[currentTrajectory].X + ";" + listPoints[currentTrajectory].Y + ";" + listPoints[currentTrajectory].Z);
                //Console.WriteLine("And " + listPoints[currentTrajectory].X + ";" + listPoints[currentTrajectory].Y + ";" + listPoints[currentTrajectory].Z + " go to" + +listPoints[0].X + ";" + listPoints[0].Y + ";" + listPoints[0].Z);
            }
            // Toutes les trajectoire à la suite dans une liste globale
            return TrajectoriesList;
        }
        public static bool robotCanMove(RobotController Robot ,double X, double Y)
        {

            double cosTeta = 0.649352561565284; //teta=49.50...
            double sinTeta = 0.760487508634168; // sinTeta = System.Math.Cos(45);
            double rX = (Robot.GetCurrentPosition().X + X) * cosTeta - (Robot.GetCurrentPosition().Y + Y) * sinTeta;
            double rY = (Robot.GetCurrentPosition().X + X) * sinTeta + (Robot.GetCurrentPosition().Y + Y) * cosTeta;
            if ((-200 <= rX) && (rX <= 950) && (130 <= rY) && (rY <= 790) && (Robot.GetCurrentPosition().Z >= 50))
            {
                return true;
            }
            else
            {
                //robot s'arrete
                Console.WriteLine("Le robot va sortir de la zone");
                Robot.StopRelativeMovement();
                return false;
            }
        }
    }
}
