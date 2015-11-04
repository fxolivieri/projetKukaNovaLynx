using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLX.Robot.Kuka.Controller;
using TDx.TDxInput;

namespace Securite
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotController Robot = new RobotController();
            Robot.Connect("192.168.1.1");
            Console.WriteLine("Robot connecté ... ");

            double cosTeta = 0.649352561565284; //teta=49.50...
            double sinTeta = 0.760487508634168; // sinTeta = System.Math.Cos(45);
   
            while(true)
            {
                double rX =  Robot.GetCurrentPosition().X * cosTeta - Robot.GetCurrentPosition().Y * sinTeta;
                double rY =  Robot.GetCurrentPosition().X * sinTeta + Robot.GetCurrentPosition().Y * cosTeta;

                //while((30 <= rX <= -30)&&(30 <= rY <= -20)&&(Robot.GetCurrentPosition().Z < 5))
                //if ((-300 >= rX) && (rX >= 300) && (-200 >= rY) && (rY >= 300) && (Robot.GetCurrentPosition().Z <= 50))
                if ((-200 <= rX) && (rX <= 800) && (130 <= rY) && (rY <= 790) && (Robot.GetCurrentPosition().Z >= 50))
                {
                   //move robot
                    Console.WriteLine("Robot reste dans la zone de securité YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
                    Console.WriteLine("Robot position : x:" + Robot.GetCurrentPosition().X + "; y:" + Robot.GetCurrentPosition().Y + "; z: " + Robot.GetCurrentPosition().Z);
                    Console.WriteLine("   Rotation de X : " + rX +"; Y : " + rY);
                }
                else
                {   
                    //robot s'arrete
                    Console.WriteLine("!!! Robot a sorti de la zone de securité !!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Robot position : x:" + Robot.GetCurrentPosition().X + "; y:" + Robot.GetCurrentPosition().Y + "; z: " + Robot.GetCurrentPosition().Z);
                    Console.WriteLine("   Rotation de X : " + rX + "; Y : " + rY);
                }
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
