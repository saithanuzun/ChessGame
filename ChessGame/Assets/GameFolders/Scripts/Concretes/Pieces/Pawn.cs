using ChessGame.Abstract.BasePiece;
using ChessGame.Enums;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame.Pieces
{
    public class Pawn : BasePiece
    {
        public override List<Coordinate> PossibleMoves()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();

            if(_pieceColor==PieceColorEnum.White)
            {
                if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + 1)) == CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y + 1));

                    if (FirstMove)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + 2)) == CellStateEnum.Free)
                        {
                            _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y + 2));
                        }
                    }
                }

            }
            if(_pieceColor==PieceColorEnum.Black)
            {
                if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - 1)) == CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y - 1));

                    if (FirstMove)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - 2)) == CellStateEnum.Free)
                        {
                            _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y - 2));
                        }

                    } 
                }
                
            }

            return _coordinate;
        }
        public override List<Coordinate> PossibleCaptures()
        {
            var _coordinate = new List<Coordinate>();
            if(_pieceColor==PieceColorEnum.White)
            {
                if ( CheckCoordinate(this._coordinate.x + 1, this._coordinate.y + 1) && CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1)) == CellStateEnum.Black )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1));
                }
                if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y + 1) && CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1)) == CellStateEnum.Black  )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1));
                }
            }
            else
            {
                if ( CheckCoordinate(this._coordinate.x + 1, this._coordinate.y - 1) && CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1)) == CellStateEnum.White )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1));
                }
                if ( CheckCoordinate(this._coordinate.x - 1, this._coordinate.y - 1) && CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1)) == CellStateEnum.White )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1));
                }
            }    


            return _coordinate;
        }       
        public List<Coordinate> AllCaptures()
        {
            var _coordinate = new List<Coordinate>();
            if (_pieceColor == PieceColorEnum.White)
            {
                if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y + 1) )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1));
                }
                if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y + 1) )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1));
                }
            }
            else
            {
                if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y - 1) )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1));
                }
                if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y - 1) )
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1));
                }
            }


            return _coordinate;
        }
    }
}

