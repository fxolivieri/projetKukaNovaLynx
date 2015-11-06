using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace readXmlPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Jordi\Desktop\novaLynx\jordi\readXmlPosition\kukaAgilus.xml"); 

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Coordonees_Robot/Position");

            List<coordoneesRobot> listeCoordonees = new List<coordoneesRobot>(); //books

            foreach (XmlNode node in nodes)
            {
                coordoneesRobot coordonees = new coordoneesRobot();

                coordonees.id = node.Attributes["id"].Value;
                System.Console.WriteLine("id: " + coordonees.id);

                coordonees.X = node.SelectSingleNode("X").InnerText;
                System.Console.WriteLine("X: " + coordonees.X);
                coordonees.Y = node.SelectSingleNode("Y").InnerText;
                System.Console.WriteLine("Y: " + coordonees.Y);
                coordonees.Z = node.SelectSingleNode("Z").InnerText;
                System.Console.WriteLine("Z: " + coordonees.Z);
                
                coordonees.A = node.SelectSingleNode("A").InnerText;
                System.Console.WriteLine("A: " + coordonees.A);
                coordonees.B = node.SelectSingleNode("B").InnerText;
                System.Console.WriteLine("B: " + coordonees.B);
                coordonees.C = node.SelectSingleNode("C").InnerText;
                System.Console.WriteLine("C: " + coordonees.C);

                coordonees.Pince = node.SelectSingleNode("Pince").InnerText;
                System.Console.WriteLine("Pince: " + coordonees.Pince);
                coordonees.Detection = node.SelectSingleNode("Detection").InnerText;
                System.Console.WriteLine("Detection: " + coordonees.Detection);
                
                listeCoordonees.Add(coordonees);
            }

            System.Console.WriteLine(listeCoordonees[2].id);
            System.Console.WriteLine(listeCoordonees[2].X);
            System.Console.WriteLine(listeCoordonees[2].Y);
            System.Console.WriteLine(listeCoordonees[2].Z);
            System.Console.WriteLine(listeCoordonees[2].A);
            System.Console.WriteLine(listeCoordonees[2].B);
            System.Console.WriteLine(listeCoordonees[2].C);
            System.Console.WriteLine(listeCoordonees[2].Pince);
            System.Console.WriteLine(listeCoordonees[2].Detection);

            System.Console.WriteLine("Total positions enregistrees: " + listeCoordonees.Count);
            System.Console.WriteLine("Total nodes: " + nodes.Count);
                                    
            System.Console.ReadLine();
        }
    }
    
    class coordoneesRobot//Book
    {
        public string id;
        public string X;
        public string Y;
        public string Z;
        public string A;
        public string B;
        public string C;
        public string Pince;
        public string Detection;


    }
}