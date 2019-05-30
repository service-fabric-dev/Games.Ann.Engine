using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Games.Ann.Models.Interfaces
{
    public interface IDirective
    {
        Task RunAsync(BoardState boardState);
    }
}
