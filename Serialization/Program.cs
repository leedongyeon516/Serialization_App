using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Atom> element = Atom.GetAtoms();
            SerializeAllAtoms("allAtoms.json", element);
            DeserializeAllAtoms("allAtoms.json");
        }

        // Serialization Method
        static void SerializeAllAtoms(string filename, List<Atom> element)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (TextWriter writer = new StreamWriter(filename))
            {
                string output = serializer.Serialize(element);
                writer.Write(output);
            }
        }

        // Deserialization Method
        static void DeserializeAllAtoms(string filename)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (TextReader reader = new StreamReader(filename))
            {
                string input = reader.ReadToEnd();
                List<Atom> atoms = serializer.Deserialize<List<Atom>>(input);
                int count = 1;

                foreach (Atom element in atoms)
                {
                    Console.WriteLine($"{count++,-2} - {element}");
                }
            }
        }
    }
}
