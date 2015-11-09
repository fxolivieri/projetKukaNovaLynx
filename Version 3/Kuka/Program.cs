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
        private static int whichTrajectory = 0;
        private static RobotController robot = new RobotController();
        private static FormSouris ihm;

        [STAThread]
        static void Main()
        {

            Console.TreatControlCAsInput = true;

            // IHM
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ihm = new FormSouris();
            Application.Run(ihm);

            // Connection
            robot.Connect("192.168.1.1");
            Console.WriteLine("Robot connecté en position : x:" + robot.GetCurrentPosition().X + "; y:" + robot.GetCurrentPosition().Y + "; z: " + robot.GetCurrentPosition().Z);

            ProgramXML xmlProg = new ProgramXML();
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

                //trajectoryToAdd = xmlProg.readXml();

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
                
            }
            else if (teachMode == 1)
            {
                Console.WriteLine("Press 1 to register point, 2 for enable translation, 3 for enable rotation and 4 for launch animation. Press ESC if you want to stop the program. \n");
                int modeEnable = 0;
                int programRunning = 1;
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

                            case ConsoleKey.Z:
                                Console.WriteLine("Suivant");
                                break;
                            case ConsoleKey.Escape:
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
                                        robot.StopRelativeMovement();
                                        TrajectoriesList = creationPlateau(Trajectoire, 4, 4, ihm);
                                        modeEnable = 3;
                                        //if (!Robot.IsGripperOpen()) Robot.OpenGripper();

                                        robot.PlayTrajectory(TrajectoriesList[0]);
                                        TrajectoriesList.RemoveAt(0);
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
                            VectorToFollow.X = translateX * 12.0;
                            VectorToFollow.Y = translateY * 12.0;
                            VectorToFollow.Z = translateZ * 12.0;

                            System.Threading.Thread.Sleep(100);

                            if (robotCanMove(robot, translateX, translateY)) robot.SetRelativeMovement(VectorToFollow);

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

                            if (robotCanMove(robot, translateX, translateY)) robot.SetRelativeMovement(VectorToFollow);
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

                    }
                }
                if (modeEnable == 1 || modeEnable == 2) robot.StopRelativeMovement();
            }

        }


        // Fonction controle de securite
        public static bool robotCanMove(RobotController Robot, double X, double Y)
        {

            double cosTeta = 0.649352561565284; //teta=49.50...
            double sinTeta = 0.760487508634168; // sinTeta = System.Math.Cos(45);
            double rX = (Robot.GetCurrentPosition().X + X) * cosTeta - (Robot.GetCurrentPosition().Y + Y) * sinTeta;
            double rY = (Robot.GetCurrentPosition().X + X) * sinTeta + (Robot.GetCurrentPosition().Y + Y) * cosTeta;
            if ((-200 <= rX) && (rX <= 800) && (130 <= rY) && (rY <= 790) && (Robot.GetCurrentPosition().Z >= 50))
            {
                return true;
            }
            else
            {
                //robot s'arrete
                Console.WriteLine("Le robot va sortir de la zone");
                return false;
            }
        }


        // Fonction création plateau
        public static List<List<CartesianPosition>> creationPlateau(List<CartesianPosition> list, int nbPointLongueur, int nbPointHauteur, FormSouris form)
        {
            List<CartesianPosition> listPoints = new List<CartesianPosition>();
            List<List<CartesianPosition>> TrajectoriesList = new List<List<CartesianPosition>>();
            List<CartesianPosition> trajectoryToAdd = new List<CartesianPosition>();
            CartesianPosition leverRondin = new CartesianPosition();
            CartesianPosition lacherRondin = new CartesianPosition();

            // Ajout du point où se trouve les rondins
            listPoints.Add(list[0]);
            trajectoryToAdd.Add(list[0]);
            TrajectoriesList.Add(trajectoryToAdd);


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

            double Angle = Math.Atan2(deltaY, deltaX);

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
                        X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 3 + point1_X,
                        Y = ((distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle))) / 3 + point1_Y,
                        Z = point1_Z,
                        A = point1_A,
                        B = point1_B,
                        C = point1_C

                    });
                    double X = -((distY * i * Math.Cos(Angle)) + (distX * j * Math.Sin(Angle))) / 3 + point1_X;
                    double Y = ((distX * j * Math.Cos(Angle)) - (distY * i * Math.Sin(Angle))) / 3 + point1_Y;
                }
            }
            leverRondin.X = list[0].X;
            leverRondin.Y = list[0].Y;
            leverRondin.Z = list[0].Z + 100;
            leverRondin.A = list[0].A;
            leverRondin.B = list[0].B;
            leverRondin.C = list[0].C;
            Console.WriteLine("\n");

            for (int currentTrajectory = 1; currentTrajectory < trajectoryToAdd.Count(); currentTrajectory++)
            {
                lacherRondin = listPoints[currentTrajectory];
                lacherRondin.Z = 125.0;

                //Aller
                trajectoryToAdd.Clear();

                trajectoryToAdd.Add(leverRondin);
                trajectoryToAdd.Add(listPoints[currentTrajectory]);
                trajectoryToAdd.Add(lacherRondin);

                TrajectoriesList.Add(trajectoryToAdd);

                //Retour
                trajectoryToAdd.Clear();

                trajectoryToAdd.Add(lacherRondin);
                trajectoryToAdd.Add(listPoints[currentTrajectory]);
                trajectoryToAdd.Add(listPoints[0]);

                TrajectoriesList.Add(trajectoryToAdd);

                //Console.WriteLine("Trajectory " + currentTrajectory + " :" + leverRondin.X + ";" + leverRondin.Y + ";" + leverRondin.Z + " go to " + listPoints[currentTrajectory].X + ";" + listPoints[currentTrajectory].Y + ";" + listPoints[currentTrajectory].Z);
                //Console.WriteLine("And " + listPoints[currentTrajectory].X + ";" + listPoints[currentTrajectory].Y + ";" + listPoints[currentTrajectory].Z + " go to" + +listPoints[0].X + ";" + listPoints[0].Y + ";" + listPoints[0].Z);
            }
            
            // Actualise les coordonnées des points sur l'ihm
            ihm.point0x.Text = listPoints[1].X.ToString();
            ihm.point0y.Text = listPoints[1].Y.ToString();
            ihm.point1x.Text = listPoints[2].X.ToString();
            ihm.point1y.Text = listPoints[2].Y.ToString();
            ihm.point2x.Text = listPoints[3].X.ToString();
            ihm.point2y.Text = listPoints[3].Y.ToString();
            ihm.point3x.Text = listPoints[4].X.ToString();
            ihm.point3y.Text = listPoints[4].Y.ToString();
            ihm.point4x.Text = listPoints[5].X.ToString();
            ihm.point4y.Text = listPoints[5].Y.ToString();
            ihm.point5x.Text = listPoints[6].X.ToString();
            ihm.point5y.Text = listPoints[6].Y.ToString();
            ihm.point6x.Text = listPoints[7].X.ToString();
            ihm.point6y.Text = listPoints[7].Y.ToString();
            ihm.point7x.Text = listPoints[8].X.ToString();
            ihm.point7y.Text = listPoints[8].Y.ToString();
            ihm.point8x.Text = listPoints[9].X.ToString();
            ihm.point8y.Text = listPoints[9].Y.ToString();
            ihm.point9x.Text = listPoints[10].X.ToString();
            ihm.point9y.Text = listPoints[10].Y.ToString();
            ihm.point10x.Text = listPoints[11].X.ToString();
            ihm.point10y.Text = listPoints[11].Y.ToString();
            ihm.point11x.Text = listPoints[12].X.ToString();
            ihm.point11y.Text = listPoints[12].Y.ToString();
            ihm.point12x.Text = listPoints[13].X.ToString();
            ihm.point12y.Text = listPoints[13].Y.ToString();
            ihm.point13x.Text = listPoints[14].X.ToString();
            ihm.point13y.Text = listPoints[14].Y.ToString();
            ihm.point14x.Text = listPoints[15].X.ToString();
            ihm.point14y.Text = listPoints[15].Y.ToString();
            ihm.point15x.Text = listPoints[16].X.ToString();
            ihm.point15y.Text = listPoints[16].Y.ToString();


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
