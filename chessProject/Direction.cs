﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Direction
    {

        public readonly static Direction North=new Direction(-1, 0);
        public readonly static Direction South=new Direction(1, 0);
        public readonly static Direction East=new Direction(0, 1);
        public readonly static Direction West=new Direction(0, -1);
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction SouthEeast = South + East;
        public readonly static Direction NorthWest= North + West;
        public readonly static Direction SouthWest= South + West;



        public int RowDelta { get; }
        public int ColumnDelta { get; }
        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }


        //overload operator +

        public static Direction operator + (Direction dir1, Direction dir2)
        {
            return new Direction(dir1.RowDelta+dir2.RowDelta , dir1.ColumnDelta+dir2.ColumnDelta);
            
        }

        //overload operator *

        public static Direction operator *(Direction dir,int scalar) {

            return new Direction(dir.RowDelta * scalar, dir.ColumnDelta * scalar);
        }

        public static Position operator + (Position pos ,Direction dir )
        {
            return new Position(pos.Row + dir.RowDelta, pos.Column + dir.ColumnDelta);

        }
     
    

    }
}
