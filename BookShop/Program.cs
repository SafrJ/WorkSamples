using System;

namespace BookShop
{
    class Program
    {
        static ModelStore modelStore;
        static Controller controller;
        static PagePrinter pagePrinter;

        static void Main(string[] args)
        {
            InitModelStore();
            if (modelStore == null)
            {
                Console.WriteLine("Data error.");
                return;
            }

            InitPagePrinter();
            InitController();

            ProcessCommands();
        }

        static void ProcessCommands ()
        {
            string newLine;
            while ((newLine = Console.ReadLine()) != null)
            {
                controller.ProcessCommand(newLine);
                Console.WriteLine("====");
                
            }
        }

        private static void InitModelStore()
        {
            modelStore = ModelStore.LoadFrom(Console.In);
        }

        private static void InitController()
        {
            controller = new Controller(modelStore, pagePrinter);
        }

        private static void InitPagePrinter()
        {
            pagePrinter = new PagePrinter(modelStore);
        }
    }
}
