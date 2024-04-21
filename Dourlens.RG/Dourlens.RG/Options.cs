using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Dourlens.RG.Cli
{
    public class Options
    {
        [Option('i', "import", Required = false, HelpText = "Importe des espions d'un fichier texte")]
        public bool Import { get; set; }

        [Value(0, MetaName = "ImportPath", HelpText = "Chemin du fichier à importer", Required = false)]
        public string ImportPath { get; set; }
    }
}
