using ChessGame.Abstract.BasePiece;
using ChessGame.Cells;
using ChessGame.Enums;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame.Pieces
{
    public class King : BasePiece
    {

        private List<Coordinate> NotPossibleMoves = new List<Coordinate>();
        private bool CheckNotPossibleMoves(Coordinate _coordinate)
        {
            foreach (Coordinate c in NotPossibleMoves)
            {
                if (Equals(c,_coordinate))
                {
                    return false;
                }
            }
            
            return true;
        }
        private void SetNotPossibleMoves()
        {
            NotPossibleMoves.Clear();          
            if (_pieceColor == PieceColorEnum.Black)
            {
                foreach (GameObject g in _pieceManager.WhitePieces)
                {
                    if(g.GetComponent<Pawn>())
                    {
                        NotPossibleMoves.AddRange(g.GetComponent<Pawn>().AllCaptures());
                    }
                    else
                    {
                        NotPossibleMoves.AddRange(g.GetComponent<BasePiece>().PossibleMoves());
                        NotPossibleMoves.AddRange(g.GetComponent<BasePiece>().PossibleCaptures());
                    }                   
                }
            }
            

        }
        public override List<Coordinate> PossibleMoves()
        {
            SetNotPossibleMoves();

            List<Coordinate> _coordinate = new List<Coordinate>();

            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x + 1, this._coordinate.y)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y));
                }
            }
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + 1)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x, this._coordinate.y + 1)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y + 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x - 1, this._coordinate.y)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y));
                }
            }
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - 1)) == CellStateEnum.Free && CheckNotPossibleMoves(new Coordinate(this._coordinate.x, this._coordinate.y - 1)))
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y - 1));
                }
            }



            return _coordinate;
        }
        public List<Coordinate> CastleMoves()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();
            if (FirstMove)
            {
                if (_pieceColor == PieceColorEnum.White)
                {
                    if (_boardManager.Board[0, 0].GetComponent<BoardCells>().ChessMan.GetComponent<Rook>())
                    {
                        if (_boardManager.Board[0, 0].GetComponent<BoardCells>().ChessMan.GetComponent<Rook>().FirstMove)
                        {
                            if (_boardManager.Board[1, 0].GetComponent<BoardCells>()._cellStateEnum == CellStateEnum.Free && _boardManager.Board[2, 0].GetComponent<BoardCells>()._cellStateEnum == CellStateEnum.Free && _boardManager.Board[3, 0].GetComponent<BoardCells>()._cellStateEnum == CellStateEnum.Free)
                            {
                                _coordinate.Add(new Coordinate(2, 0));
                            }

                        }
                    }
                    if (_boardManager.Board[7, 0].GetComponent<BoardCells>().ChessMan.GetComponent<Rook>())
                    {
                        if (_boardManager.Board[7, 0].GetComponent<BoardCells>().ChessMan.GetComponent<Rook>().FirstMove)
                        {
                            if (_boardManager.Board[6, 0].GetComponent<BoardCells>()._cellStateEnum == CellStateEnum.Free && _boardManager.Board[5, 0].GetComponent<BoardCells>()._cellStateEnum == CellStateEnum.Free )
                            {
                                _coordinate.Add(new Coordinate(6, 0));
                            }
                        }
                    }
                }
                if(_pieceColor==PieceColorEnum.Black)
                {
                    //castle move for black king
                }
            }
            return _coordinate;
        }

        public override List<Coordinate> PossibleCaptures()
        {
            List<Coordinate> _coordinate = new List<Coordinate>();

            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y));
                }
            }
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y + 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x + 1, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x + 1, this._coordinate.y - 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y + 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y + 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y + 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y + 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y));
                }
            }
            if (CheckCoordinate(this._coordinate.x - 1, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x - 1, this._coordinate.y - 1));
                }
            }
            if (CheckCoordinate(this._coordinate.x, this._coordinate.y - 1))
            {
                if (CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - 1)) != ChessGame.Enums.CellStateEnum.Free && CheckCell(new Coordinate(this._coordinate.x, this._coordinate.y - 1)).ToString() != _pieceColor.ToString())
                {
                    _coordinate.Add(new Coordinate(this._coordinate.x, this._coordinate.y - 1));
                }
            }




            return _coordinate;
        }
    }
}


