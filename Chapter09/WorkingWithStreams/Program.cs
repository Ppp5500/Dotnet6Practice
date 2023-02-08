using System.Security.Cryptography.X509Certificates;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

static void WorkWithText()
{
    // define a file to Write to
    string textFile = Combine(CurrentDirectory, "streams.txt");
    // create a text file and return a helper writer
    StreamWriter text = File.CreateText(textFile);
    WriteLine($"File Path: {GetDirectoryName(textFile)}");
    // enumerate the strings, writing  each one
    // to the stream on a separate line
    foreach(string item in Viper.Callsigns)
    {
        text.WriteLine(item);
    }
    text.Close(); // release resources
    // output the contents of the file
    WriteLine("{0} contains {1:N0} bytes.",
        arg0: textFile,
        arg1: new FileInfo(textFile).Length);
    WriteLine(File.ReadAllText(textFile));
}

WorkWithText();

static void WorkWithXml()
{
    // define a file to write to
    string xmlFile = Combine(CurrentDirectory, "streams.xml");
    // use using block for automatically dispose
    using (FileStream xmlFileStream = File.Create(xmlFile))
    {
        using(XmlWriter xml = XmlWriter.Create(xmlFile, new XmlWriterSettings { Indent = true }))
        {
            // write the XML declaration
            xml.WriteStartDocument();
            // write a root element
            xml.WriteStartElement("callsigns");
            // enumerate the strings writing each one to the stream
            foreach (string item in Viper.Callsigns)
            {
                xml.WriteElementString("callsign", item);
            }
            // write the close root element
            xml.WriteEndElement();
            // close helper and stream
            xml.Close();
            xmlFileStream.Close();
            // output all the contents of the file
            WriteLine("{0} contains [1:N0] bytes.",
                arg0: xmlFile,
                arg1: new FileInfo(xmlFile).Length);
            WriteLine(File.ReadAllText(xmlFile));
        } // automatically calls Dispose if the object is not null
    } // automatically calls Dispose if the object is not null

    // use try catch block for dispose
    /*
    FileStream? xmlFileStream = null;
    XmlWriter? xml = null;
    try
    {
        // define a file to write to
        string xmlFile = Combine(CurrentDirectory, "streams.xml");
        // create a file stream
        xmlFileStream = File.Create(xmlFile);
        // wrap the file stream in an XML writer helper
        // and automatically indent nested elements
        xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
        // write the XML declaration
        xml.WriteStartDocument();
        // write a root element
        xml.WriteStartElement("callsigns");
        // enumerate the strings writing each one to the stream
        foreach (string item in Viper.Callsigns)
        {
            xml.WriteElementString("callsign", item);
        }
        // write the close root element
        xml.WriteEndElement();
        // close helper and stream
        xml.Close();
        xmlFileStream.Close();
        // output all the contents of the file
        WriteLine("{0} contains [1:N0] bytes.",
            arg0: xmlFile,
            arg1: new FileInfo(xmlFile).Length);
        WriteLine(File.ReadAllText(xmlFile));
    }
    catch(Exception ex)
    {
        // if the path doesn't exist the exciprion woll be caught
        WriteLine($"{ex.GetType()} says {ex.Message}");
    }
    finally
    {
        if(xml != null)
        {
            xml.Dispose();
            WriteLine("The XML writer's unmanaged resources have been disposed.");
            if(xmlFileStream != null)
            {
                xmlFileStream.Dispose();
                WriteLine("The file stream's unmanaged resources have been disposed.");
            }
        }
    }
    */
}

WorkWithXml();

static class Viper{
    public static string[] Callsigns = new[]
    {
       "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack"
   };
} 