using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLX.Robot.Kuka.Controller;
using TDx.TDxInput;

using System.Xml;


namespace xmlTestJordi3    //namespace xmlTest
{
    public class GenerateXml
    {
        private static void Main()
        {
            RobotController Robot = new RobotController();
            Robot.Connect("192.168.1.1");
            Console.WriteLine("Robot connecté ... ");
        /*    //System.Console.ReadLine();
            System.Console.WriteLine("Ecrivez la valeur de X");
            string valeurX = (Console.ReadLine());
            System.Console.WriteLine("Ecrivez la valeur de Y");
            string valeurY = (Console.ReadLine());
            System.Console.WriteLine("Ecrivez la valeur de Z");
            string valeurZ = (Console.ReadLine());
            System.Console.WriteLine("Ecrivez la valeur de A");
            string valeurA = (Console.ReadLine());
            System.Console.WriteLine("Ecrivez la valeur de B");
            string valeurB = (Console.ReadLine());
            System.Console.WriteLine("Ecrivez la valeur de C");
            string valeurC = (Console.ReadLine());
            //int valeruZ = int.Parse(Console.ReadLine());
        */

            string valeurX = "0", valeurY = "0", valeurZ = "0", valeurA = "0", valeurB = "0", valeurC = "0", valeurPince = "0", valeurDetection = "0";
            
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            //XmlNode productsNode = doc.CreateElement("products");
            XmlNode RobotNode = doc.CreateElement("Coordonees_Robot");
            doc.AppendChild(RobotNode);

            XmlNode PositonNode = doc.CreateElement("Position");
            XmlAttribute postitionAttribute = doc.CreateAttribute("id");
            postitionAttribute.Value = "00";
            PositonNode.Attributes.Append(postitionAttribute);
            RobotNode.AppendChild(PositonNode);
            //----------------------------- X Y Z ------------------------------------------
            XmlNode xNode = doc.CreateElement("X");
            xNode.AppendChild(doc.CreateTextNode(valeurX));
            PositonNode.AppendChild(xNode);
            XmlNode yNode = doc.CreateElement("Y");
            yNode.AppendChild(doc.CreateTextNode(valeurY));
            PositonNode.AppendChild(yNode);
            XmlNode zNode = doc.CreateElement("Z");
            zNode.AppendChild(doc.CreateTextNode(valeurZ));
            PositonNode.AppendChild(zNode);
            //----------------------------- A B C ------------------------------------------
            XmlNode aNode = doc.CreateElement("A");
            aNode.AppendChild(doc.CreateTextNode(valeurA));
            PositonNode.AppendChild(aNode);
            XmlNode bNode = doc.CreateElement("B");
            bNode.AppendChild(doc.CreateTextNode(valeurB));
            PositonNode.AppendChild(bNode);
            XmlNode cNode = doc.CreateElement("C");
            cNode.AppendChild(doc.CreateTextNode(valeurC));
            PositonNode.AppendChild(cNode);
            //----------------------------- Pince et Capteur ------------------------------------------
            XmlNode gripperNode = doc.CreateElement("Pince");
            gripperNode.AppendChild(doc.CreateTextNode(valeurPince));
            PositonNode.AppendChild(gripperNode);
            XmlNode detectionNode = doc.CreateElement("Detection");
            detectionNode.AppendChild(doc.CreateTextNode(valeurDetection));
            PositonNode.AppendChild(detectionNode);
            //-----------------------loop pour ajouter positions-------------------------

            for (int i = 1; i < 666; i++)
            {
                Console.WriteLine(i);
                string id = i.ToString(); //iString
                Console.WriteLine(id);
                Console.WriteLine("press 0 pour ajouter point; press 9 pour finaliser");
                int j = i;
                while (j==i) 
                { 
                    try
                    {
                        int press = int.Parse(Console.ReadLine());
                        switch (press)
                        {
                            case 0:
                            {
                                //Doner valeurs a X Y Z; apres on metra get.currentPosition...
/*                              System.Console.WriteLine("Ecrivez la valeur de X");
                                valeurX = (Console.ReadLine());
                                System.Console.WriteLine("Ecrivez la valeur de Y");
                                valeurY = (Console.ReadLine());
                                System.Console.WriteLine("Ecrivez la valeur de Z");
                                valeurZ = (Console.ReadLine());
*/
                                valeurX = Robot.GetCurrentPosition().X.ToString();
                                valeurY = Robot.GetCurrentPosition().Y.ToString();
                                valeurZ = Robot.GetCurrentPosition().Z.ToString();
                                valeurA = Robot.GetCurrentPosition().A.ToString();
                                valeurB = Robot.GetCurrentPosition().B.ToString();
                                valeurC = Robot.GetCurrentPosition().C.ToString();
                                valeurDetection = Robot.ReadSensor().ToString();
                                valeurPince = Robot.IsGripperOpen().ToString();
                                
                                // Create and add another product node---------------------------Creation nouveau position
                                PositonNode = doc.CreateElement("Position");
                                postitionAttribute = doc.CreateAttribute("id");
                                postitionAttribute.Value = id;
                                PositonNode.Attributes.Append(postitionAttribute);
                                RobotNode.AppendChild(PositonNode);
            
                                xNode = doc.CreateElement("X");
                                xNode.AppendChild(doc.CreateTextNode(valeurX));
                                PositonNode.AppendChild(xNode);
                                yNode = doc.CreateElement("Y");
                                yNode.AppendChild(doc.CreateTextNode(valeurY));
                                PositonNode.AppendChild(yNode);
                                zNode = doc.CreateElement("Z");
                                zNode.AppendChild(doc.CreateTextNode(valeurZ));
                                PositonNode.AppendChild(zNode);
                                aNode = doc.CreateElement("A");
                                aNode.AppendChild(doc.CreateTextNode(valeurA));
                                PositonNode.AppendChild(aNode);
                                bNode = doc.CreateElement("B");
                                bNode.AppendChild(doc.CreateTextNode(valeurB));
                                PositonNode.AppendChild(bNode);
                                cNode = doc.CreateElement("C");
                                cNode.AppendChild(doc.CreateTextNode(valeurC));
                                PositonNode.AppendChild(cNode);
                                //----------------------------- Pince et Capteur ------------------------------------------
                                gripperNode = doc.CreateElement("Pince");
                                gripperNode.AppendChild(doc.CreateTextNode(valeurPince));
                                PositonNode.AppendChild(gripperNode);
                                detectionNode = doc.CreateElement("Detection");
                                detectionNode.AppendChild(doc.CreateTextNode(valeurDetection));
                                PositonNode.AppendChild(detectionNode);

                                j = j+1;
                                break;
                            }
                            case 9:
                            {
                                i = 666;
                                break;
                            }
                            default:
                            {
                                System.Console.WriteLine("Pres 0 pour enregitrer un nouveau point");
                                break;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }


            //-----------------------End loop pour ajouter positions-------------------------

            //------------informationRobot
            //XmlNode informationNode = doc.CreateElement("Information_Robot");
            //doc.AppendChild(informationNode);

            //-------------------Pince
/*          XmlNode pinceNode = doc.CreateElement("Estatus_Pince");
            XmlAttribute pinceAttribute = doc.CreateAttribute("id");
            pinceAttribute.Value = "01";
            pinceNode.Attributes.Append(pinceAttribute);
            //informationNode.AppendChild(pinceNode);
            RobotNode.AppendChild(pinceNode);

            XmlNode ouvertNode = doc.CreateElement("ouvert");
            ouvertNode.AppendChild(doc.CreateTextNode("1/0"));
            pinceNode.AppendChild(ouvertNode);
            //-------------------Pince

            //-------------------Capteur
            XmlNode capteurNode = doc.CreateElement("Estauts_Capteur");
            XmlAttribute capteurAttribute = doc.CreateAttribute("id");
            capteurAttribute.Value = "01";
            capteurNode.Attributes.Append(capteurAttribute);
            //informationNode.AppendChild(capteurNode);
            RobotNode.AppendChild(capteurNode);

            XmlNode detectionNode = doc.CreateElement("detection");
            detectionNode.AppendChild(doc.CreateTextNode("1/0"));
            capteurNode.AppendChild(detectionNode);

*/            //-------------------Capteur

            doc.Save(Console.Out);
            doc.Save("GrosKukaAgilus.xml");
            System.Console.ReadLine();
        }
    }
}