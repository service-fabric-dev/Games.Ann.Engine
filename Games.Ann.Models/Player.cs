using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Games.Ann.Models.Interfaces;

namespace Games.Ann.Models
{
    public class Player : IEquatable<Player>
    {
        public readonly string Id;

        public Player()
        {
            Id = Guid.NewGuid().ToString();
        }

        public async Task<PlayerDirectives> RunTurnAsync(BoardState boardState)
        {
            // Render board to player
            await boardState.RenderAsync().ConfigureAwait(false);

            // Get directives from neural network
            var neuralDirectives = await RunNeuralNetworkAsync().ConfigureAwait(false);

            // Allow players to adjust neural directives and add new directives
            var playerDirectives = await AcceptPlayerInput(neuralDirectives).ConfigureAwait(false);

            // back-propogate the adjustments
            await BackpropogateAsync(playerDirectives).ConfigureAwait(false);

            return playerDirectives;
        }

        public async Task<NeuralDirectives> RunNeuralNetworkAsync()
        {
            return new NeuralDirectives();
        }

        public async Task<PlayerDirectives> AcceptPlayerInput(NeuralDirectives neuralDirectives)
        {
            var actions = new PlayerDirectives
            {
                Directives = neuralDirectives?.Directives ?? new List<IDirective>()
            };
            
            return actions;
        }

        public bool Equals(Player other)
        {
            return Id?.Equals(other?.Id) == true;
        }

        private async Task BackpropogateAsync(PlayerDirectives playerDirectives)
        {
        }
    }
}