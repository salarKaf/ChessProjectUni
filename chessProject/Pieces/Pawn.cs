﻿using System;
using System.Collections.Generic;
using System.Drawing;using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ChessLogic
{


        public class Pawn : Piece
        {
            public override TypePieces Type => TypePieces.Pawn;
            public readonly Direction forward;

            public override Player Color { get; }

            public Pawn(Player color)
            {
                Color = color;
                if(color==Player.White)
                {
                    forward = Direction.North;
                }
                else if(color == Player.Black)
                {
                    forward = Direction.South;
                     
                }
            }

            public override Piece copy()
            {
                Pawn pawnCopy = new Pawn(Color);
                pawnCopy.IsPlaying = IsPlaying;
                return pawnCopy;

            }
            private static bool CanMoveTo(Position pos , Board board)
            {
                return Board.IsInSide(pos) && board.IsEmpty(pos);
            }

            private bool CanCaptureAt(Position pos , Board board) {

                if(!Board.IsInSide(pos) || board.IsEmpty(pos))
                {
                    return false;
                }

                return board[pos].Color != Color;
            }
            private IEnumerable<Move> ForwardMoves(Position from , Board board) {

                Position oneMovePos =  from + forward ;

                if(CanMoveTo(oneMovePos, board))
                {
                    yield return new NormalMoves(from , oneMovePos);

                    Position twoMovePos = oneMovePos+forward;

                    if( !IsPlaying && CanMoveTo(twoMovePos, board))
                    {
                        yield return new NormalMoves(from, twoMovePos);
                    }
                }

            }


            private IEnumerable<Move> DiagonalMoves(Position from , Board board)
            {

                foreach(Direction dir in new Direction[] {Direction.West , Direction.East} )
                {
                    Position to = from + dir + forward;

                    if (CanCaptureAt(to, board))
                    {
                        yield return new NormalMoves(from, to);
                    }
                   
                }
                
            }

            public override IEnumerable<Move> GetMoves(Position from , Board board )
            {
                return ForwardMoves(from , board).Concat(DiagonalMoves(from , board));
            }

        public override bool CanCapturOpponentKing(Position from, Board board)
        {
            return DiagonalMoves(from , board).Any(move=>
            {
                Piece piece = board[move.ToPosition];
                return piece != null && piece.Type == TypePieces.king;
            });
        }





    }
    }

