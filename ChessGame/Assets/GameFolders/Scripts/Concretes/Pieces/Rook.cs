using ChessGame.Abstract.BasePiece;
using ChessGame.Enums;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame.Pieces
{
    public class Rook : BasePiece
    {

        public override List<Coordinate> PossibleMoves()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();

            //top
            for (int i = 1; i < 8; i++)
            {
                if (this._coordinate.y + i < 8 && this._coordinate.y + i > -1)
                {
                    if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + i)) == CellStateEnum.Free)
                    {
                        _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y + i));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //
            for (int i = 1; i < 8; i++)
            {
                if (this._coordinate.y - i < 8 && this._coordinate.y - i > -1)
                {
                    if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - i)) == CellStateEnum.Free)
                    {
                        _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y - i));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //left
            for (int i = 1; i < 8; i++)
            {

                if (this._coordinate.x - i < 8 && this._coordinate.x - i > -1)
                {

                    if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y)) == CellStateEnum.Free)
                    {

                        _coordinate.Add(new Coordinate(this._coordinate.x - i, this._coordinate.y));
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //right
            for (int i = 1; i < 8; i++)
            {
                if (this._coordinate.x + i < 8 && this._coordinate.x + i > -1)
                {
                    if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y)) == CellStateEnum.Free)
                    {
                        _coordinate.Add(new Coordinate(this._coordinate.x + i, this._coordinate.y));
                    }
                    else
                    {
                        break;
                    }
                }
            }



            //Debug.Log(_coordinate[0].x);
            return _coordinate;
        }

        public override List<Coordinate> PossibleCaptures()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();

            //top
            for (int i = 1; i < 8; i++)
            {
                if (this._coordinate.y + i < 8 && this._coordinate.y + i > -1)
                {
                    if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + i)) != CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + i)).ToString() != _pieceColor.ToString())
                        {
                            _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y + i));
                        }
                        break;
                    }

                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (this._coordinate.y - i < 8 && this._coordinate.y - i > -1)
                {
                    if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - i)) != CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - i)).ToString() != _pieceColor.ToString())
                        {
                            _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y - i));
                        }
                        break;
                    }

                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (this._coordinate.x - i < 8 && this._coordinate.x - i > -1)
                {
                    if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y)) != CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x - i, this._coordinate.y)).ToString() != _pieceColor.ToString())
                        {
                            _coordinate.Add(new Coordinate(this._coordinate.x - i, this._coordinate.y));
                        }
                        break;
                    }

                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (this._coordinate.x + i < 8 && this._coordinate.x + i > -1)
                {
                    if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y)) != CellStateEnum.Free)
                    {
                        if (CheckCell(new Coordinate(this._coordinate.x + i, this._coordinate.y)).ToString() != _pieceColor.ToString())
                        {
                            _coordinate.Add(new Coordinate(this._coordinate.x + i, this._coordinate.y));
                        }
                        break;
                    }

                }
            }






            return _coordinate;
        }
    }
}

