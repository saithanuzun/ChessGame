using ChessGame.Abstract.BasePiece;
using ChessGame.Cells;
using ChessGame.Enums;
using ChessGame.Pieces;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ChessGame.Manager
{
    public class PieceManager : Singleton<PieceManager>
    {
        private BoardManager _boardManager;
        private GameManager _gameManager;

        public GameObject SelectedPiece;

        public List<GameObject> AllPieces = new List<GameObject>();
        public List<GameObject> BlackPieces = new List<GameObject>();
        public List<GameObject> WhitePieces = new List<GameObject>();



        private GameObject WhitePawn;
        private GameObject WhiteRook;
        private GameObject WhiteKnight;
        private GameObject WhiteBishop;
        private GameObject WhiteQueen;
        private GameObject WhiteKing;

        private GameObject BlackPawn;
        private GameObject BlackRook;
        private GameObject BlackKnight;
        private GameObject BlackBishop;
        private GameObject BlackQueen;
        private GameObject BlackKing;

        private void Awake()
        {
            _boardManager = BoardManager.Instance;
            _gameManager = GameManager.Instance;

            WhitePawn = Resources.Load<GameObject>("Prefabs/Pieces/WhitePawn");
            WhiteRook = Resources.Load<GameObject>("Prefabs/Pieces/WhiteRook");
            WhiteKnight = Resources.Load<GameObject>("Prefabs/Pieces/WhiteKnight");
            WhiteBishop = Resources.Load<GameObject>("Prefabs/Pieces/WhiteBishop");
            WhiteQueen = Resources.Load<GameObject>("Prefabs/Pieces/WhiteQueen");
            WhiteKing = Resources.Load<GameObject>("Prefabs/Pieces/WhiteKing");
            BlackPawn = Resources.Load<GameObject>("Prefabs/Pieces/BlackPawn");
            BlackRook = Resources.Load<GameObject>("Prefabs/Pieces/BlackRook");
            BlackKnight = Resources.Load<GameObject>("Prefabs/Pieces/BlackKnight");
            BlackBishop = Resources.Load<GameObject>("Prefabs/Pieces/BlackBishop");
            BlackQueen = Resources.Load<GameObject>("Prefabs/Pieces/BlackQueen");
            BlackKing = Resources.Load<GameObject>("Prefabs/Pieces/BlackKing");

        }
        public void SetBlackAndWhitePieces()
        {
            foreach (GameObject g in AllPieces)
            {
                if (g.GetComponent<BasePiece>()._pieceColor == PieceColorEnum.Black)
                {
                    BlackPieces.Add(g);
                }
                if (g.GetComponent<BasePiece>()._pieceColor == PieceColorEnum.White)
                {
                    WhitePieces.Add(g);
                }
            }
        }
        public void CreateChessman(GameObject ChessMan, int x, int y, CellStateEnum _cellStateEnum, GameObject Parent)
        {
            var pieces = Instantiate(ChessMan, _boardManager.Board[x, y].transform.position, Quaternion.identity);
            pieces.gameObject.GetComponent<BasePiece>()._coordinate = new Coordinate(x, y);
            _boardManager.Board[x, y].GetComponent<BoardCells>()._cellStateEnum = _cellStateEnum;
            pieces.transform.parent = Parent.transform;
            _boardManager.Board[x, y].GetComponent<BoardCells>().ChessMan = pieces;
            AllPieces.Add(pieces);
        }
        public void CreatePieces(GameObject Parent)
        {
            AllPieces.Clear();
            BlackPieces.Clear();
            WhitePieces.Clear();
            //WhitePawns and BlackPawns
            for (int i = 0; i < 8; i++)
            {

                CreateChessman(WhitePawn, i, 1, CellStateEnum.White, Parent);
                CreateChessman(BlackPawn, i, 6, CellStateEnum.Black, Parent);
            }
            //WhitePieces
            {
                CreateChessman(WhiteRook, 0, 0, CellStateEnum.White, Parent);
                CreateChessman(WhiteRook, 7, 0, CellStateEnum.White, Parent); ;
                CreateChessman(WhiteKnight, 1, 0, CellStateEnum.White, Parent);
                CreateChessman(WhiteKnight, 6, 0, CellStateEnum.White, Parent);
                CreateChessman(WhiteBishop, 2, 0, CellStateEnum.White, Parent);
                CreateChessman(WhiteBishop, 5, 0, CellStateEnum.White, Parent);
                CreateChessman(WhiteQueen, 3, 0, CellStateEnum.White, Parent);
                CreateChessman(WhiteKing, 4, 0, CellStateEnum.White, Parent);
            }
            //BlackPieces
            {
                CreateChessman(BlackRook, 0, 7, CellStateEnum.Black, Parent);
                CreateChessman(BlackRook, 7, 7, CellStateEnum.Black, Parent);
                CreateChessman(BlackKnight, 1, 7, CellStateEnum.Black, Parent);
                CreateChessman(BlackKnight, 6, 7, CellStateEnum.Black, Parent);
                CreateChessman(BlackBishop, 2, 7, CellStateEnum.Black, Parent);
                CreateChessman(BlackBishop, 5, 7, CellStateEnum.Black, Parent);
                CreateChessman(BlackQueen, 3, 7, CellStateEnum.Black, Parent);
                CreateChessman(BlackKing, 4, 7, CellStateEnum.Black, Parent);
            }

        }
        public void PieceMover(GameObject piece, GameObject TargetCell)
        {
            _boardManager.Board[piece.GetComponent<BasePiece>()._coordinate.x, piece.GetComponent<BasePiece>()._coordinate.y].GetComponent<BoardCells>()._cellStateEnum = CellStateEnum.Free;
            _boardManager.Board[piece.GetComponent<BasePiece>()._coordinate.x, piece.GetComponent<BasePiece>()._coordinate.y].GetComponent<BoardCells>().ChessMan = null;
            piece.GetComponent<BasePiece>()._coordinate = TargetCell.GetComponent<BoardCells>()._coords;

            if (piece.GetComponent<BasePiece>()._pieceColor == PieceColorEnum.White)
            {
                TargetCell.GetComponent<BoardCells>()._cellStateEnum = CellStateEnum.White;
            }
            else
            {
                TargetCell.GetComponent<BoardCells>()._cellStateEnum = CellStateEnum.Black;
            }
            piece.GetComponent<BasePiece>().FirstMove = false;
            TargetCell.GetComponent<BoardCells>().ChessMan = piece;
            piece.transform.position = TargetCell.transform.position;
            _gameManager.TurnMove = !_gameManager.TurnMove;
            _boardManager.ResetColors();

        }
        private void CaptureAction(GameObject selectedPiece, GameObject TargetCell)
        {
            AllPieces.Remove(TargetCell.GetComponent<BoardCells>().ChessMan);
            if (TargetCell.GetComponent<BoardCells>().ChessMan.GetComponent<BasePiece>()._pieceColor == PieceColorEnum.Black)
            {
                BlackPieces.Remove(TargetCell.GetComponent<BoardCells>().ChessMan);
                Destroy(TargetCell.GetComponent<BoardCells>().ChessMan);
            }
            else
            {
                WhitePieces.Remove(TargetCell.GetComponent<BoardCells>().ChessMan);
                Destroy(TargetCell.GetComponent<BoardCells>().ChessMan);
            }
            PieceMover(selectedPiece, TargetCell);
            _boardManager.ResetColors();
        }
        public void Capture(GameObject selectedPiece, GameObject TargetCell)
        {
            if (TargetCell.GetComponent<BoardCells>().ChessMan.GetComponent<King>())
            {
                if (TargetCell.GetComponent<BoardCells>().ChessMan.GetComponent<King>()._pieceColor == PieceColorEnum.Black)
                {
                    CaptureAction(selectedPiece, TargetCell);
                    _gameManager.FinishTheGame(true);
                }
                else
                {
                    CaptureAction(selectedPiece, TargetCell);
                    _gameManager.FinishTheGame(false);
                }
            }
            CaptureAction(selectedPiece, TargetCell);
            _boardManager.ResetColors();

        }
        public void CastlingAction(GameObject selectedPiece, GameObject TargetCell)
        {
            PieceMover(selectedPiece, TargetCell);
            if (TargetCell.GetComponent<BoardCells>()._coords.x == 2)
            {
                PieceMover(_boardManager.Board[0, 0].GetComponent<BoardCells>().ChessMan, _boardManager.Board[3, 0]);
            }
            else
            {
                PieceMover(_boardManager.Board[7, 0].GetComponent<BoardCells>().ChessMan, _boardManager.Board[5, 0]);
            }
            _gameManager.TurnMove = !_gameManager.TurnMove;

        }
    }


}
