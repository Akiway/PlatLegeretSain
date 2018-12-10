using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    sealed class Parameters
    {
        // Singleton
        private static Parameters Param = null;
        public static Parameters Instance()
        {
            if (Param == null)
                Param = new Parameters();
            return Param;
        }

        public int InitialHour { get; set; }
        public int Serveur { get; set; }
        public int CommisSalle { get; set; }
        public int Cuisinier { get; set; }
        public int CommisCuisine { get; set; }

        private Parameters()
        {
            using(StreamReader sr = new StreamReader("../../../../Param.txt"))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                CSharpCodeProvider myCodeCompiler = new CSharpCodeProvider();
                ICodeCompiler icc = myCodeCompiler.CreateCompiler();
                String[] referenceAssemblies = { "System.dll" };
                string myAssemblyName = "myAssembly.dll";
                CompilerParameters myCompilerParameters =
                new CompilerParameters(referenceAssemblies, myAssemblyName);
                myCompilerParameters.GenerateExecutable = false;
                myCompilerParameters.GenerateInMemory = false;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Model." + line.Split(' ')[0] + " = " + line.Split(' ')[1] + ";");

                    String CsharpSourceCode = "Model." + line.Split(' ')[0] + " = " + line.Split(' ')[1] + ";";
                    CompilerResults myCompilerResults = myCodeCompiler.CompileAssemblyFromSource(myCompilerParameters, CsharpSourceCode);
                }
                Console.WriteLine(InitialHour);
                Console.WriteLine(Serveur);
            }
        }
    }
}
