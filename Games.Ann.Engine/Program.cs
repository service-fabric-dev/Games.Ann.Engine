using System;
using Games.Ann.Models;

namespace Games.Ann.Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(2, 10, 10);
            game.RunAsync().GetAwaiter().GetResult();
        }
    }
}
