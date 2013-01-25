using System;

namespace RedMeansGo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (RedMeansGoGame game = new RedMeansGoGame())
            {
                game.Run();
            }
        }
    }
}

