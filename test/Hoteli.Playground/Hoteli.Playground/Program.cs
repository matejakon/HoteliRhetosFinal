using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDump;
using Rhetos.Configuration.Autofac;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Logging;
using Rhetos.Utilities;

namespace Hoteli.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger.MinLevel = EventType.Info; // Use "Trace" for more details log.
            var rhetosServerPath = @"C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer";
            Directory.SetCurrentDirectory(rhetosServerPath);
            using (var container = new RhetosTestContainer(commitChanges: false)) // Use this parameter to COMMIT or ROLLBACK the data changes.
            {
                var context = container.Resolve<Common.ExecutionContext>();
                var repository = context.Repository;

                repository.Hoteli.Hotel.Load().Dump();
                repository.Hoteli.Hotel.Query().ToList().Dump();

                repository.Hoteli.Rooms.Load().Dump();
                repository.Hoteli.Rooms.Query().ToString().Dump();



            }

        }
    }
}
