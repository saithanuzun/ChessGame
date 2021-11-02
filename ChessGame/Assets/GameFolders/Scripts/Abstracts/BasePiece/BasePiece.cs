using ChessGame.Cells;
using ChessGame.Enums;
using ChessGame.Manager;
using ChessGame.Pieces;
using ChessGame.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame.Abstract.BasePiece
{
    public abstract class BasePiece : MonoBehaviour
    {
        public int value;
        public bool FirstMove=true;
        public PieceColorEnum _pieceColor;
        public PieceNameEnum _pieceName;

        protected PieceManager _pieceManager;
        protected BoardManager _boardManager;
        protected GameManager _gameManager;

        public Coordinate _coordinate;

        private void Awake()
        {
            _pieceManager = PieceManager.Instance;
            _boardManager = BoardManager.Instance;
            _gameManager = GameManager.Instance;
        }
        private void Start()
        {
            setValue();
            
        }
        private void setValue()
        {
            switch (_pieceName)
            {
                case PieceNameEnum.King:
                    value = 100;
                    break;

                case PieceNameEnum.Queen:
                    value = 9;
                    break;

                case PieceNameEnum.Bishop:
                    value = 3;
                    break;

                case PieceNameEnum.Knight:
                    value = 3;
                    break;
                case PieceNameEnum.Rook:
                    value = 5;
                    break;
                case PieceNameEnum.Pawn:
                    value = 1;
                    break;              
            }
        }

        public void SetSelectedPiece()
        {
            if (_gameManager.TurnMove)
            {
                if (_pieceColor == PieceColorEnum.White)
                {              
                    _pieceManager.SelectedPiece = this.gameObject;
                    if(_pieceName==PieceNameEnum.King)
                    {
                        _boardManager.SetBoardColors(PossibleMoves(), PossibleCaptures(),GetComponent<King>().CastleMoves());
                    }
                    else
                    {
                        _boardManager.SetBoardColors(PossibleMoves(), PossibleCaptures());
                    }
                    
                }
            }
            else
            {
                if (_pieceColor == PieceColorEnum.Black)
                {
                    _pieceManager.SelectedPiece = this.gameObject;
                    if (_pieceName == PieceNameEnum.King)
                    {
                        _boardManager.SetBoardColors(PossibleMoves(), PossibleCaptures(), GetComponent<King>().CastleMoves());
                    }
                    else
                    {
                        _boardManager.SetBoardColors(PossibleMoves(), PossibleCaptures());
                    }
                }
            }

        }
      
        protected CellStateEnum CheckCell(Coordinate _coordinate)
        {
            return _boardManager.Board[_coordinate.x, _coordinate.y].GetComponent<BoardCells>()._cellStateEnum;

        }
        protected bool CheckCoordinate(int x, int y)
        {
            return _boardManager.CheckCoordinate(x, y);
        }

        public abstract List<Coordinate> PossibleMoves();
        public abstract List<Coordinate> PossibleCaptures();
        
    }
}

