using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Ann.Models.Interfaces
{
    public interface IBoardStateFactory
    {
        BoardState Create(Game board, Player player);
    }
}
