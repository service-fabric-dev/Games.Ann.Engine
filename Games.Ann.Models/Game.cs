using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Ann.Models.Extensions;
using Games.Ann.Models.Interfaces;

namespace Games.Ann.Models
{
    /// <summary>
    /// Orchestrates core game functions
    /// </summary>
    public class Game
    {
        // Members
        private DirectiveQueue _directiveQueue;
        private Field _field;
        private List<Player> _players;
        private bool _complete;

        // Services
        private IBoardStateFactory _boardStateFactory;

        public Game(
            int players,
            int width,
            int height,
            IBoardStateFactory boardStateFactory)
        {
            _directiveQueue = new DirectiveQueue();
            _field = new Field(width, height);
            _players = new List<Player>();
            _complete = false;

            for (int i=0; i<players; ++i)
            {
                _players.Add(new Player());
            }

            _boardStateFactory = boardStateFactory.Guard(nameof(boardStateFactory));
        }

        public async Task RunAsync()
        {
            while(!GameComplete())
            {
                await RunTurnAsync().ConfigureAwait(false);
            }
        }
        
        public async Task RunTurnAsync()
        {
            var boardStates = _players
                .ToDictionary(
                    player => player,
                    player => _boardStateFactory.Create(this, player));

            foreach (var player in _players)
            {
                var playerBoard = boardStates[player];
                var actions = await player.RunTurnAsync(playerBoard).ConfigureAwait(false);
                _directiveQueue.Enqueue(player, actions.Directives);
            }

            foreach(var player in _players)
            {
                var directive = _directiveQueue.Dequeue(player);

                if (directive != default(IDirective))
                {
                    var playerBoard = boardStates[player];
                    await directive.RunAsync(playerBoard).ConfigureAwait(false);
                }
            }
        }

        private bool GameComplete()
        {
            // Check win conditions
            return _complete;
        }
    }
}
