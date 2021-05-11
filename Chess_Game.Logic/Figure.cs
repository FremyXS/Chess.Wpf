using System;

namespace Chess_Game.Logic
{
    
    public class Figure
    {
        public Roles Role { get; }       
        public Colors Color { get; }
        public Figure(Roles role, Colors color)
        {
            Role = role;
            Color = color;
        }
    }
}
