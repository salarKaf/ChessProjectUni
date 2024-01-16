﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }
                                                                                                     
        public Position(int Row , int Colmn)
        {
            this.Row = Row;
            this.Column = Colmn;
        }

        public Player SquareColor()
        {
            if ((Column + Row) % 2 == 0)  
            {
                return Player.White;
            }
                
            return Player.Black;

        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
