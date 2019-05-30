using System.Collections.Generic;
using Games.Ann.Models.Interfaces;

namespace Games.Ann.Models
{
    public class NeuralDirectives
    {
        public List<IDirective> Directives;

        public NeuralDirectives()
        {
            Directives = new List<IDirective>();
        }
    }
}