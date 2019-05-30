using System;
using System.Threading.Tasks;
using Games.Ann.Models.Extensions;
using Games.Ann.Models.Interfaces;

namespace Games.Ann.Models
{
    public class Entity
    {
        private IDirective _directive;

        public void SetDirective(IDirective directive)
        {
            _directive = directive.Guard(nameof(directive));
        }

        public void ClearDirective()
        {
            _directive = null;
        }

        public async Task ActAsync(Game board)
        {
            await _directive.RunAsync(board).ConfigureAwait(false);
        }
    }
}