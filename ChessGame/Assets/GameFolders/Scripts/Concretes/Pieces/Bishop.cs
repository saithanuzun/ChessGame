using ChessGame.Abstract.BasePiece;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame.Pieces
{
    public class Bishop : BasePiece
    {


        public override List<Coordinate> PossibleMoves()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();

            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x + i, this._coordinate.y + i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y + i)) == Enums.CellStateEnum.Free)
                    {
                        _coordinate.Add(new Coordinate(this._coordinate.x + i, this._coordinate.y + i));
                    }
                    else
                        break;
                }

            }


            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x - i, this._coordinate.y - i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y - i)) == Enums.CellStateEnum.Free)
                    {
                        _coordinate.Add(new Coordinate(this._coordinate.x - i, this._coordinate.y - i));
                    }
                    else
                        break;
                }

            }

            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x - i, this._coordinate.y + i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y + i)) ==Enums.CellStateEnum.Free)
                    {
                        _coordinate.Add(new Coordinate(this._coordinate.x - i, this._coordinate.y + i));
                    }
                    else
                        break;
                }

            }

            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x + i, this._coordinate.y - i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y - i)) == Enums.CellStateEnum.Free)
                    {
                        _coordinate.Add(new Coordinate(this._coordinate.x + i, this._coordinate.y - i));
                    }
                    else
                        break;
                }

            }







            return _coordinate;
        }

        public override List<Coordinate> PossibleCaptures()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();
            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x + i, this._coordinate.y + i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y + i)) != ChessGame.Enums.CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y + i)).ToString() != _pieceColor.ToString())
                            _coordinate.Add(new Coordinate(this._coordinate.x + i, this._coordinate.y + i));

                        break;
                    }

                }

            }
            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x - i, this._coordinate.y + i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y + i)) != ChessGame.Enums.CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y + i)).ToString() != _pieceColor.ToString())
                            _coordinate.Add(new Coordinate(this._coordinate.x - i, this._coordinate.y + i));

                        break;
                    }

                }

            }
            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x - i, this._coordinate.y - i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y - i)) != ChessGame.Enums.CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y - i)).ToString() != _pieceColor.ToString())
                            _coordinate.Add(new Coordinate(this._coordinate.x - i, this._coordinate.y - i));

                        break;
                    }

                }

            }
            for (int i = 1; i < 8; i++)
            {
                if (CheckCoordinate(this._coordinate.x + i, this._coordinate.y - i))
                {
                    if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y - i)) != ChessGame.Enums.CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y - i)).ToString() != _pieceColor.ToString())
                            _coordinate.Add(new Coordinate(this._coordinate.x + i, this._coordinate.y - i));

                        break;
                    }

                }

            }

            return _coordinate;
        }
    }
}

