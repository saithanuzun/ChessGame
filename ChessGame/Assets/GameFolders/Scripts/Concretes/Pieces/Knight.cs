using ChessGame.Abstract.BasePiece;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame.Pieces
{
    public class Knight : BasePiece
    {


        public override List<Coordinate> PossibleMoves()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();

            // x+2 y+1
            if (CheckCoordinate(this._coordinate.x + 2, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 2, this._coordinate.y + 1)) == Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 2, this._coordinate.y + 1));
                }
            }
            //x+1 y+2
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y + 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 2)) ==Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 2));
                }
            }
            //x-1 y+2
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y + 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 2)) == Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 2));
                }
            }
            // x-2 y+1
            if (CheckCoordinate(this._coordinate.x - 2, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 2, this._coordinate.y + 1)) == Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 2, this._coordinate.y + 1));
                }
            }
            // x+1 y-2
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y - 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 2)) == Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 2));
                }
            }
            //x-2 y-1
            if (CheckCoordinate(this._coordinate.x - 2, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 2, this._coordinate.y - 1)) == Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 2, this._coordinate.y - 1));
                }
            }
            //x-1 y-2
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y - 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 2)) == Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 2));
                }
            }
            //x+2 y-1
            if (CheckCoordinate(this._coordinate.x + 2, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 2, this._coordinate.y - 1)) == Enums.CellStateEnum.Free)
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 2, this._coordinate.y - 1));
                }
            }




            return _coordinate;
        }

        public override List<Coordinate> PossibleCaptures()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();

            // x+2 y+1
            if (CheckCoordinate(this._coordinate.x + 2, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 2, this._coordinate.y + 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x + 2, this._coordinate.y + 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 2, this._coordinate.y + 1));
                }
            }
            //x+1 y+2
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y + 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 2)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 2)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 2));
                }
            }
            //x-1 y+2
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y + 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 2)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 2)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 2));
                }
            }
            // x-2 y+1
            if (CheckCoordinate(this._coordinate.x - 2, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 2, this._coordinate.y + 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x - 2, this._coordinate.y + 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 2, this._coordinate.y + 1));
                }
            }
            // x+1 y-2
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y - 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 2)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 2)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 2));
                }
            }
            //x-2 y-1
            if (CheckCoordinate(this._coordinate.x - 2, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 2, this._coordinate.y - 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x - 2, this._coordinate.y - 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 2, this._coordinate.y - 1));
                }
            }
            //x-1 y-2
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y - 2))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 2)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 2)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 2));
                }
            }
            //x+2 y-1
            if (CheckCoordinate(this._coordinate.x + 2, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 2, this._coordinate.y - 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x + 2, this._coordinate.y + -1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 2, this._coordinate.y - 1));
                }
            }




            return _coordinate;
        }

       
    }
}

