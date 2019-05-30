using Games.Ann.Models;
using Games.Ann.Models.Interfaces;

namespace Games.Ann.Services
{
    public class BoardStateFactory : IBoardStateFactory
    {
        public BoardState Create(Game board, Player player)
        {
            // Create BoardState consisting of only known pieces/tiles
            return new BoardState(player)
            {
                
            }
        }
    }
}
