using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidePuzzle
{
    public class Position
    {
        public int Row { get; private set; } = -1;
        public int Column { get; private set; } = -1;
        public Position Clone()
        {
            return new Position(this.Row, this.Column);
        }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public static Position Empty => new Position(-1, -1);
        public String key => $"{Row}_{Column}";
        public bool isEqual(Position anotherPosition) =>
                this.Row == anotherPosition.Row
                && this.Column == anotherPosition.Column;

        public static bool operator ==(Position obj1, Position obj2)
        {
            // Custom comparison logic here
            if (obj1 is null)
            {
                return obj2 is null;
            }
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Position obj1, Position obj2)
        {
            return !(obj1 == obj2);  // Typically defer to `==`
        }


        public static Position operator +(Position obj1, Position obj2)
        {
            return new Position(obj1.Row + obj2.Row, obj1.Column + obj2.Column);
        }
          
        
    }
}
