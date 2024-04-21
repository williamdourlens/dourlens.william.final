using CommandLine;
using Dourlens.RG.Cli;
using Dourlens.RG.DAL.DAL;
using Dourlens.RG.DAL.Model;
using Dourlens.RG.DAL.Service;


namespace Dourlens.RG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new DourlensDbContext();
            var service = new RenseignementsGenerauxService(db);

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    if (options.Import)
                    {
                        if (!string.IsNullOrEmpty(options.ImportPath))
                        {
                            if (File.Exists(options.ImportPath))
                            {
                                Console.WriteLine($"Import des espions du fichier : {options.ImportPath}");

                                string[] lines = File.ReadAllLines(options.ImportPath);

                                foreach (string line in lines)
                                {
                                    string[] parts = line.Split("; ");

                                    if (parts.Length == 2)
                                    {
                                        string nom = parts[0];
                                        string code = parts[1];

                                        Espion newEspion = new Espion(nom, code);
                                        service.AddEspion(newEspion);

                                        Console.WriteLine($"Import de {newEspion}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"La ligne suivante n'est pas au bon format : {line}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Le fichier spécifié n'existe pas : {options.ImportPath}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez spécifier un chemin de fichier à importer");
                        }
                    }
                    else
                    {
                        Console.WriteLine("L'exécution doit se faire soit avec --import {fichier} soit avec --mission");
                    }
                });
        }
    }
}
