using ErrorHandling;
using IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHKTempleteProject {
    class Program {
        static void Main(string[] args) {
            if (args.Length != 2)
                throw new IHKException("Start the program with 2 parameters [in-file] [out-file]");
            if (args.Any(path => path.IndexOfAny(Path.GetInvalidPathChars()) != -1))
                throw new IHKException("One of the file paths is invalid !");

            var reader = new FileInputReader(args[0]);
            var inData = reader.Read();
            
            // do calculations (generate output)
            var outData = new OutputData(inData);

            var writer = new FileOutputWriter(args[1]);
            writer.Write(outData);
            Console.ReadKey();
        }
    }
}
