﻿using System.Threading.Tasks;
using Games.Ann.Models.Extensions;

namespace Games.Ann.Models
{
    public class BoardState
    {
        private Player _player;
        private Field _field;

        public BoardState(Player player)
        {
            _player = player.Guard(nameof(player));
        }

        public async Task RenderAsync()
        {

        }
    }
}
