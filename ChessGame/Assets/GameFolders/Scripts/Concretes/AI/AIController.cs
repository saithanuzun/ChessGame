using ChessGame.Abstract.BasePiece;
using ChessGame.Cells;
using ChessGame.Manager;
using ChessGame.Pieces;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessGame.AI
{
    public class AIController : Singleton<AIController>
    {
        private PieceManager _pieceManager;
        private BoardManager _boardManager;
        private GameManager _gameManager;

        List<Coordinate> _PossibleCapturesBlack = new List<Coordinate>();
        List<Coordinate> _PossibleCapturesWhite = new List<Coordinate>();


        private void Awake()
        {
            _pieceManager = PieceManager.Instance;
            _boardManager = BoardManager.Instance;
            _gameManager = GameManager.Instance;
        }

        private void SetPossibleCapturesBlack()
        {
            _PossibleCapturesBlack.Clear();
            foreach (GameObject g in _pieceManager.BlackPieces)
            {
                if (g != null)
                {
                    List<Coordinate> coords = g.GetComponent<BasePiece>().PossibleCaptures();
                    if (coords.Count != 0 && coords != null)
                    {
                        _PossibleCapturesBlack.AddRange(coords);
                    }
                }
            }
        }
        private void SetPossibleCapturesWhite()
        {
            _PossibleCapturesWhite.Clear();
            foreach (GameObject g in _pieceManager.WhitePieces)
            {
                if (g != null)
                {
                    List<Coordinate> coords = g.GetComponent<BasePiece>().PossibleCaptures();
                    if (coords.Count != 0 && coords != null)
                    {
                        _PossibleCapturesWhite.AddRange(coords);
                    }
                }
            }
        }
        private bool CheckKing()
        {
            GameObject King = null;
            foreach (GameObject g in _pieceManager.BlackPieces)
            {
                if (g.GetComponent<King>())
                {
                    King = g;
                }
            }
            foreach (Coordinate c in _PossibleCapturesWhite)
            {
                if (Equals(King.GetComponent<BasePiece>()._coordinate, c))
                {
                    return true;
                }
            }
            return false;
        }
        private Coordinate BestCapture()
        {
            Coordinate _coordinate = new Coordinate();
            int _value = 0;
            foreach (Coordinate c in _PossibleCapturesBlack)
            {
                if (_boardManager.Board[c.x, c.y].GetComponent<BoardCells>().ChessMan.GetComponent<BasePiece>().value > _value)
                {
                    _value = _boardManager.Board[c.x, c.y].GetComponent<BoardCells>().ChessMan.GetComponent<BasePiece>().value;
                    _coordinate = c;
                }
            }
            return _coordinate;
        }
        private GameObject GameObjectFromBestCapture(Coordinate _coordinate)
        {
            foreach (GameObject g in _pieceManager.BlackPieces)
            {
                var _coordinates = g.GetComponent<BasePiece>().PossibleCaptures();
                foreach (Coordinate c in _coordinates)
                {
                    if (Equals(c, _coordinate))
                    {
                        return g;
                    }
                }
            }
            return null;
        }

        public void SetMove()
        {
            SetPossibleCapturesBlack();
            SetPossibleCapturesWhite();

            if (CheckKing())
            {
                GameObject King = null;
                foreach (GameObject g in _pieceManager.BlackPieces)
                {
                    if (g.GetComponent<King>())
                    {
                        King = g;
                    }
                }
                if (King.GetComponent<BasePiece>().PossibleMoves().Count!=0)
                {
                    List<Coordinate> _coordinateList = King.GetComponent<BasePiece>().PossibleMoves();
                    int Rnd1 = Random.Range(0, _coordinateList.Count);
                    _pieceManager.PieceMover(King, _boardManager.Board[_coordinateList[Rnd1].x, _coordinateList[Rnd1].y]);
                }
                else if(King.GetComponent<BasePiece>().PossibleCaptures().Count!=0)
                {
                    List<Coordinate> _coordinateList = King.GetComponent<BasePiece>().PossibleCaptures();
                    int Rnd1 = Random.Range(0, _coordinateList.Count);
                    _pieceManager.Capture(King, _boardManager.Board[_coordinateList[Rnd1].x, _coordinateList[Rnd1].y]);

                }
                else if(_PossibleCapturesBlack.Count == 0)
                {
                    _gameManager.FinishTheGame();
                }
                else
                {
                    _pieceManager.Capture(GameObjectFromBestCapture(BestCapture()), _boardManager.Board[BestCapture().x, BestCapture().y]);
                }
            }
            else if (_PossibleCapturesBlack.Count != 0)
            {
                
                _pieceManager.Capture(GameObjectFromBestCapture(BestCapture()), _boardManager.Board[BestCapture().x, BestCapture().y]);
            }
            else
            {
                int Rnd1 = Random.Range(0, _pieceManager.BlackPieces.Count - 1);             
                List<Coordinate> _coordinateList = _pieceManager.BlackPieces[Rnd1].GetComponent<BasePiece>().PossibleMoves();
                int Rnd2 = Random.Range(0, _coordinateList.Count-1);              
                _pieceManager.PieceMover(_pieceManager.BlackPieces[Rnd1], _boardManager.Board[_coordinateList[Rnd2].x, _coordinateList[Rnd2].y]);
            }
        }
    }
}


