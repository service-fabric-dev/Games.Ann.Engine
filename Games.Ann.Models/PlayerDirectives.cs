using System.Collections.Generic;
using Games.Ann.Models.Interfaces;

namespace Games.Ann.Models
{
    public class PlayerDirectives
    {
        public List<IDirective> Directives;

        public PlayerDirectives()
        {
            Directives = new List<IDirective>();
        }
    }
}