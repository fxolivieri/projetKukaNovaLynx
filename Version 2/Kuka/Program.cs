using NLX.Robot.Kuka.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDx.TDxInput;

namespace Kuka
{
    static class Program
    {
        private static CartesianPosition VectorToFollow = new CartesianPosition();
        private static double translateX;
        private static double translateY;
        private static double translateZ;
        private static double rotateX;
        private static double rotateY;
        private static double rotateZ;
        private static List<CartesianPosition> Trajectoire;
        private static ConsoleKeyInfo key;
        private static RobotController robot = new RobotController();
        private static FormSouris ihm;

        [STAThread]
        static void Main()
        {

            //Console.TreatControlCAsInput = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ihm = new FormSouris();
            Application.Run(ihm);
            robot.Connect("192.168.1.1");
            Console.WriteLine("Robot connecté en position : x:" + robot.GetCurrentPosition().X + "; y:" + robot.GetCurrentPosition().Y + "; z: " + robot.GetCurrentPosition().Z);

            Device Mouse = new Device();
            Mouse.Connect();
            Trajectoire = new List<CartesianPosition>();

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
                // Actualise les coordonnees du robot
                rempliCoordonneesrobot();

                Console.WriteLine("Predefined mode go");
                List<CartesianPosition> trajectoryToAdd = new List<CartesianPosition>();
                if (!robot.IsGripperOpen()) robot.OpenGripper();
                trajectoryToAdd.Add(new CartesianPosition
                {
                    X = 513.64,
                    Y = 133.94,
                    Z = 219.75,
                    A = -69.23,
                    B = 86.72,
                    C = -165.68,
                });
                trajectoryToAdd.Add(new CartesianPosition
                {
                    X = 513.64,
                    Y = 233.63,
                    Z = 219.75,
                    A = -69.23,
                    B = 86.72,
                    C = -165.68,
                });
                robot.PlayTrajectory(trajectoryToAdd);
                robot.CloseGripper();
                robot.StartRelativeMovement();
                robot.SetRelativeMovement(new CartesianPosition
                {
                    X = 0,
                    Y = 0,
                    Z = 100
                });
                System.Threading.Thread.Sleep(200);
                robot.StopRelativeMovement();
                /*List<List<CartesianPosition>> TrajectoriesList = new List<List<CartesianPosition>>();
                CartesianPosition leverRondin = new CartesianPosition();
                leverRondin.X = point1_X;
                leverRondin.Y = point1_Y;
                leverRondin.Z = point1_Z;
                leverRondin.A = point1_A;
                leverRondin.B = point1_B;
                leverRondin.C = point1_C;
                for (int i = 0; i < listPoints.Count; i++)
                {
                    //Aller
                    trajectoryToAdd.Clear();
                    trajectoryToAdd.Add(leverRondin);
                    trajectoryToAdd.Add(listPoints[i]);
                    TrajectoriesList.Add(trajectoryToAdd);

                    //Retour
                    trajectoryToAdd.Clear();
                    trajectoryToAdd.Add(listPoints[i]);
                    trajectoryToAdd.Add(listPoints[0]);
                    TrajectoriesList.Add(trajectoryToAdd);
                }*/

            }
            else if (teachMode == 1)
            {
                Console.WriteLine("Press 1 to register point, 2 for enable translation, 3 for enable rotation and 4 for launch animation. Press ESC if you want to stop the program. \n");
                int modeEnable = 0;
                int programRunning = 1;
                int whichTrajectory = 0;
                List<List<CartesianPosition>> TrajectoriesList = new List<List<CartesianPosition>>();

                robot.StartRelativeMovement();
                while (programRunning != 0)
                {
                    // Actualise les coordonnees du robot
                    rempliCoordonneesrobot();

                    if (modeEnable == 3)
                    {
                        key = Console.ReadKey(true);
                        switch (key.Key)
                        {

                            case ConsoleKey.A:
                                modeEnable = 1;
                                Console.WriteLine("Rebegin");
                                Trajectoire.Clear();
                                break;
                            case ConsoleKey.Escape:
                                programRunning = 0;
                                break;
                        }
                    }
                    else
                    {
                        VectorToFollow.X = VectorToFollow.Y = VectorToFollow.Z = VectorToFollow.A = VectorToFollow.B = VectorToFollow.C = 0;
                        robot.SetRelativeMovement(VectorToFollow);
                        if (Console.KeyAvailable)
                        {
                            key = Console.ReadKey(true);
                            switch (key.Key)
                            {
                                case ConsoleKey.A:
                                    if (Trajectoire.Count() <= 3 && modeEnable != 0)
                                    {
                                        Console.WriteLine("Point enregistré : x:" + robot.GetCurrentPosition().X + "; y:" + robot.GetCurrentPosition().Y + "; z: " + robot.GetCurrentPosition().Z);
                                        Trajectoire.Add(new CartesianPosition
                                        {
                                            X = robot.GetCurrentPosition().X,
                                            Y = robot.GetCurrentPosition().Y,
                                            Z = robot.GetCurrentPosition().Z,
                                            A = robot.GetCurrentPosition().A,
                                            B = robot.GetCurrentPosition().B,
                                            C = robot.GetCurrentPosition().C

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
                                        TrajectoriesList = creationPlateau(Trajectoire, 4, 4);
                                        modeEnable = 3;
                                        if (!robot.IsGripperOpen()) robot.OpenGripper();
                                        Console.WriteLine("Pince ouverte");
                                        Trajectoire.RemoveRange(1, 3);
                                        Trajectoire.Insert(0, robot.GetCurrentPosition());
                                        robot.StopRelativeMovement();
                                        robot.PlayTrajectory(Trajectoire);
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
                        var translation = Mouse.Sensor.Translation;
                        var rotation = Mouse.Sensor.Rotation;

                        /* Affichage des translations et des rotations */

                        if (modeEnable == 1)
                        {
                            translateX = translation.X / 2353;
                            translateZ = translation.Y / 2702;
                            translateY = translation.Z / 2648;
                            VectorToFollow.X = translateX * 12.0;
                            VectorToFollow.Y = translateY * 12.0;
                            VectorToFollow.Z = translateZ * 12.0;
                        }
                        else if (modeEnable == 2)
                        {
                            rotateX = rotation.X;
                            rotateZ = rotation.Y;
                            rotateY = rotation.Z;
                            VectorToFollow.A = rotateX * 2.0;
                            VectorToFollow.B = rotateZ * 2.0;
                            VectorToFollow.C = rotateY * 2.0;
                        }
                        else if (modeEnable == 3)
                        {
                            if (whichTrajectory % 2 == 0)
                            {
                                robot.CloseGripper();
                            }
                            else
                            {
                                robot.OpenGripper();
                            }
                            robot.PlayTrajectory(TrajectoriesList[whichTrajectory]);
                            whichTrajectory++;
                        }

                        System.Threading.Thread.Sleep(50);
                        robot.SetRelativeMovement(VectorToFollow);

                    }
                }
                robot.StopRelativeMovement();
            }

        }

        // Fonction création plateau
        public static List<List<CartesianPosition>> creationPlateau(List<CartesianPosition> list, int nbPointLongueur, int nbPointHauteur)
        {
            List<CartesianPosition> listPoints = new List<CartesianPosition>();

            // Ajout du point où se trouve les rondins
            listPoints.Add(list[0]);

            // Déterminer tes 16 points
            // Recupere les coordonnees de l'origine du stock
            double point1_X = list[1].X;
            double point1_Y = list[1].Y;
            double point1_Z = list[1].Z;
            double point1_A = list[1].A;
            double point1_B = list[1].B;
            double point1_C = list[1].C;


            double deltaY = Math.Abs(list[1].Y - list[2].Y);
            double deltaX = Math.Abs(list[1].X - list[2].X);

            double Angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;
            Console.WriteLine(Angle + " Degré");

            Angle = Angle * (Math.PI / 180);
            Console.WriteLine(Angle + " Radiant");

            // Distance y et x
            double distX = Math.Sqrt(Math.Pow(list[2].X - list[1].X, 2) + Math.Pow(list[2].Y - list[1].Y, 2));
            double distY = Math.Sqrt(Math.Pow(list[3].X - list[1].X, 2) + Math.Pow(list[3].Y - list[1].Y, 2));
            Console.WriteLine("Distance X :" + distX + " Distance en Y :" + distY + "\n");

            for (int j = 0; j < nbPointHauteur; j++)
            {
                for (int i = 0; i < nbPointLongueur; i++)
                {
                    // Ajout du point a la liste
                    listPoints.Add(new CartesianPosition
                    {
                        X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 4 + point1_X,
                        Y = (distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle)) / 4 + point1_Y,
                        Z = point1_Z,
                        A = point1_A,
                        B = point1_B,
                        C = point1_C

                    });
                    double X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 4 + point1_X;
                    double Y = (distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle)) / 4 + point1_Y;
                    Console.WriteLine(X + " ; " + Y + " ; " + point1_Z + " ; " + point1_A + " ; " + point1_B + " ; " + point1_C);
                }
            }
            List<List<CartesianPosition>> TrajectoriesList = new List<List<CartesianPosition>>();
            List<CartesianPosition> trajectoryToAdd = new List<CartesianPosition>();
            CartesianPosition leverRondin = new CartesianPosition();
            leverRondin.X = point1_X;
            leverRondin.Y = point1_Y;
            leverRondin.Z = point1_Z;
            leverRondin.A = point1_A;
            leverRondin.B = point1_B;
            leverRondin.C = point1_C;
            for (int i = 0; i < listPoints.Count; i++)
            {
                //Aller
                trajectoryToAdd.Clear();
                trajectoryToAdd.Add(leverRondin);
                trajectoryToAdd.Add(listPoints[i]);
                TrajectoriesList.Add(trajectoryToAdd);

                //Retour
                trajectoryToAdd.Clear();
                trajectoryToAdd.Add(listPoints[i]);
                trajectoryToAdd.Add(listPoints[0]);
                TrajectoriesList.Add(trajectoryToAdd);
            }

            // Toutes les trajectoire à la suite dans une liste globale
            return TrajectoriesList;
        }

        // Fonction qui actualise les coordonnees du robot
        public static void rempliCoordonneesrobot()
        {
            ihm.dataX.Text = robot.GetCurrentPosition().X.ToString();
            ihm.dataY.Text = robot.GetCurrentPosition().Y.ToString();
            ihm.dataZ.Text = robot.GetCurrentPosition().Z.ToString();
            ihm.dataA.Text = robot.GetCurrentPosition().A.ToString();
            ihm.dataB.Text = robot.GetCurrentPosition().B.ToString();
            ihm.dataC.Text = robot.GetCurrentPosition().C.ToString();
        }
    }
}
