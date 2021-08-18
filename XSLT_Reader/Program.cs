using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XSLT_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load XML into XDoc
            XDocument doc = XDocument.Load("C:\\Users\\ravia\\source\\repos\\XSLT_Reader\\data.xml");

            // Check if the packages value match
            if(doc.Element("RootElement").Element("PrevPackages").Element("Package").Element("H_PackageType").Value == doc.Element("RootElement").Element("Packages").Element("H_PackageType").Value)
            {
                // Testing block to check the value of the package i.e silver
                var attr_val = doc.Element("RootElement").Element("PrevPackages").Element("Package").Element("H_PackageType").Value;
                Console.WriteLine(attr_val);

                // Extract the elements from the Previous Packages
                IEnumerable<XElement> elements = doc.Element("RootElement").Element("PrevPackages").Element("Package").Elements();

                // Iterate and add
                foreach (var element in elements) doc.Element("RootElement").Element("Packages").Add(element);

                // Remove nodes from previous package
                elements.Remove();

                // Code to print the resulting XML on console
                var wr = new StringWriter();
                doc.Save(wr);
                Console.WriteLine(wr);
                Console.ReadLine();
            }
        }
    }
}
