using System;

namespace Chess_Game.Logic
{
    
    public class Role
    {
        public Figures NameFigure { get; }
        public bool IsActive { get; } = true;
        public Colors Color { get; }

        public Role(Figures name, Colors color)
        {
            NameFigure = name;
            Color = color;
        }
    }
}
