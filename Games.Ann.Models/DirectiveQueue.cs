using System.Collections.Generic;
using System.Linq;
using Games.Ann.Models.Interfaces;

namespace Games.Ann.Models
{
    public class DirectiveQueue
    {
        private readonly Dictionary<Player, Queue<IDirective>> _playerQueues;

        public DirectiveQueue()
        {
            _playerQueues = new Dictionary<Player, Queue<IDirective>>();
        }

        public void Enqueue(Player player, IDirective directive)
        {
            if (!_playerQueues.ContainsKey(player))
            {
                _playerQueues.Add(player, new Queue<IDirective>());
            }

            _playerQueues[player].Enqueue(directive);
        }

        public void Enqueue(Player player, IEnumerable<IDirective> directives)
        {
            if (directives?.Any() != true)
            {
                return;
            }

            foreach (var directive in directives)
            {
                Enqueue(player, directive);
            }
        }

        public IDirective Dequeue(Player player)
        {
            if (!_playerQueues.ContainsKey(player))
            {
                return default(IDirective);
            }

            return _playerQueues[player].Dequeue();
        }
    }
}