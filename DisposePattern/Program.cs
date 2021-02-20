using System;

namespace DisposePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("'1' to Get Date; '2' to Garbage Collect; 'x' to Exit");
            var command = "";
            while (command != "x")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        GetDate();
                        break;

                    case "2":
                        GC.Collect();
                        break;
                }
            }
        }
        //Run Diagnostic Tool and check for Memory Usage
        private static void GetDate()
        {
            //using (var databaseState = new UnManagedSQLDatabase()) //Calls Dispose Internally
            var databaseState = new UnManagedSQLDatabase(); //Calls do not dispose , here finilize will be invoked
            {
                Console.WriteLine(databaseState.GetDate());
            }
        }
    }
}
