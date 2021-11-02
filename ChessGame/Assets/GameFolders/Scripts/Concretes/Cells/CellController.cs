using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChessGame.Structs;
using ChessGame.Enums;
using ChessGame.Manager;
using ChessGame.Abstract.BasePiece;

namespace ChessGame.Cells
{
    public class CellController : MonoBehaviour
    {
        PieceManager _pieceManager;

        private void Awake()
        {
            _pieceManager = PieceManager.Instance;

        }
        private void OnMouseDown()
        {

            if (gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
            {
                _pieceManager.PieceMover(_pieceManager.SelectedPiece, gameObject);
               
            }
            else if (gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                _pieceManager.Capture(_pieceManager.SelectedPiece, gameObject);

            }
            else if (gameObject.GetComponent<SpriteRenderer>().color == new Color(1, 0.9215686f, 0.016f, 1f))
            {
                _pieceManager.CastlingAction(_pieceManager.SelectedPiece, gameObject);               

            }
            else if (gameObject.GetComponent<BoardCells>()._cellStateEnum != CellStateEnum.Free)
            {
                gameObject.GetComponent<BoardCells>().ChessMan.GetComponent<BasePiece>().SetSelectedPiece();

            }
        }
    }
}

