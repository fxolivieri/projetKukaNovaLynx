using NLX.Robot.Kuka.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KukkaMove
{
    class ProgramXML
    {
        XmlDocument doc = new XmlDocument();
        public List<CartesianPosition> readXml(String fieldXml)
        {
            List<CartesianPosition> listOfPositions = new List<CartesianPosition>();
           
            doc.Load(@""+fieldXml+"");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Coordonees_Robot/Position");

            foreach (XmlNode node in nodes)
            {
                CartesianPosition currentPoint = new CartesianPosition();
                
                currentPoint.X = Convert.ToDouble(node.SelectSingleNode("X").InnerText);
                currentPoint.Y = Convert.ToDouble(node.SelectSingleNode("Y").InnerText);
                currentPoint.Z = Convert.ToDouble(node.SelectSingleNode("Z").InnerText);
                
                currentPoint.A = Convert.ToDouble(node.SelectSingleNode("A").InnerText);
                currentPoint.B = Convert.ToDouble(node.SelectSingleNode("B").InnerText);
                currentPoint.C = Convert.ToDouble(node.SelectSingleNode("C").InnerText);

                listOfPositions.Add(currentPoint);
            }
            return listOfPositions;
        }
        public bool createXml(List<CartesianPosition> listOfPoints, String fieldXml)
        {
            string valeurX = "0", valeurY = "0", valeurZ = "0", valeurA = "0", valeurB = "0", valeurC = "0", valeurPince = "0", valeurDetection = "0";

            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode RobotNode = doc.CreateElement("Coordonees_Robot");

            doc.AppendChild(docNode);
            doc.AppendChild(RobotNode);
            try
            {
                for (int i = 0; i < listOfPoints.Count(); i++)
                {
                    string id = i.ToString(); //iString

                    int j = i;
                    while (j == i)
                    {

                        /*                          //Doner valeurs a X Y Z; apres on metra get.currentPosition...
                                                        System.Console.WriteLine("Ecrivez la valeur de X");
                                                        valeurX = (Console.ReadLine());
                                                        System.Console.WriteLine("Ecrivez la valeur de Y");
                                                        valeurY = (Console.ReadLine());
                                                        System.Console.WriteLine("Ecrivez la valeur de Z");
                                                        valeurZ = (Console.ReadLine());
                        */
                        //
                        valeurX = listOfPoints[i].X.ToString();
                        valeurY = listOfPoints[i].Y.ToString();
                        valeurZ = listOfPoints[i].Z.ToString();
                        valeurA = listOfPoints[i].A.ToString();
                        valeurB = listOfPoints[i].B.ToString();
                        valeurC = listOfPoints[i].C.ToString();
                        //valeurDetection = Robot.ReadSensor().ToString();
                        //valeurPince = Robot.IsGripperOpen().ToString();
                        //*/                 
                        // Create and add another product node---------------------------Creation nouveau position
                        XmlNode PositonNode = doc.CreateElement("Position");
                        XmlAttribute postitionAttribute = doc.CreateAttribute("id");
                        postitionAttribute.Value = id;
                        PositonNode.Attributes.Append(postitionAttribute);
                        RobotNode.AppendChild(PositonNode);

                        XmlNode xNode = doc.CreateElement("X");
                        xNode.AppendChild(doc.CreateTextNode(valeurX));
                        PositonNode.AppendChild(xNode);
                        XmlNode yNode = doc.CreateElement("Y");
                        yNode.AppendChild(doc.CreateTextNode(valeurY));
                        PositonNode.AppendChild(yNode);
                        XmlNode zNode = doc.CreateElement("Z");
                        zNode.AppendChild(doc.CreateTextNode(valeurZ));
                        PositonNode.AppendChild(zNode);
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

                        j = j + 1;

                    }
                }

                doc.Save(Console.Out);
                doc.Save(@"" + fieldXml + "");
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
