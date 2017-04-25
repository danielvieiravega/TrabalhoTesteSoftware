using System;
using System.IO;
using System.Xml;
using Fclp;
using Fclp.Internals;

namespace Tester
{   
    public class ApplicationArguments
    {
        public int Probabilide1 { get; set; }
        public int Quantidade1 { get; set; }
        public int Probabilide2 { get; set; }
        public int Quantidade2 { get; set; }
        public int Probabilide3 { get; set; }
        public int Quantidade3 { get; set; }
    }

    class Program
    {
        const string ConfiabilidadeXml = "Confiabilidade.xml";

        static void Main(string[] args)
        {
            var p = new FluentCommandLineParser<ApplicationArguments>();

            p.Setup(arg => arg.Probabilide1)
             .As("p1")
             .Required(); 

            p.Setup(arg => arg.Quantidade1)
             .As("q1")
             .Required();

            p.Setup(arg => arg.Probabilide2)
             .As("p2") 
             .Required();

            p.Setup(arg => arg.Quantidade2)
             .As("q2")
             .Required();

            p.Setup(arg => arg.Probabilide3)
             .As("p3") 
             .Required(); 

            p.Setup(arg => arg.Quantidade3)
             .As("q3")
             .Required();

            const string helpText = "Exemplo: Tester.exe --p1 1 --q1 2 --p2 3 --q2 4 --p3 5 --q3 6";

            p.SetupHelp("?", "help")
                .Callback(text => Console.WriteLine(helpText));

            var result = p.Parse(args);

            if (result.HasErrors == false)
            {
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = ("\t")
                };
                try
                {
                    using (var writer = XmlWriter.Create(ConfiabilidadeXml, settings))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Rows");
                        for (var i = 0; i < p.Object.Quantidade1; i++)
                        {
                            writer.WriteStartElement("row");
                            writer.WriteElementString("data", p.Object.Probabilide1.ToString());
                            writer.WriteEndElement();
                        }

                        for (var i = 0; i < p.Object.Quantidade2; i++)
                        {
                            writer.WriteStartElement("row");
                            writer.WriteElementString("data", p.Object.Probabilide2.ToString());
                            writer.WriteEndElement();
                        }

                        for (var i = 0; i < p.Object.Quantidade3; i++)
                        {
                            writer.WriteStartElement("row");
                            writer.WriteElementString("data", p.Object.Probabilide3.ToString());
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"O arquivo {ConfiabilidadeXml} foi gerado com sucesso!!");
                        Console.ResetColor();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"linha de comando invalida!!!\n{helpText}");
                Console.ResetColor();
            }
        }
    }
}
