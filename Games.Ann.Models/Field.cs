using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Ann.Models
{
    public class Field
    {
        private Entity[][] _tiles;

        public Field(int width, int height)
        {
            _tiles = new Entity[width][];
            for(int i = 0; i < width; ++i)
            {
                _tiles[i] = new Entity[height];
            }
        }
    }
}
