using ChessGame.Cells;
using ChessGame.Enums;
using ChessGame.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ChessGame.Manager
{
    public class BoardManager : Singleton<BoardManager>
    {

        private GameObject SquareDark;
        private GameObject SquareLight;

        public GameObject[,] Board = new GameObject[8,8];

        private void Awake()
        {
            SquareDark = Resources.Load<GameObject>("Prefabs/Board/SquareDark");
            SquareLight = Resources.Load<GameObject>("Prefabs/Board/SquareLight");
        }

        public void CreateBoard(float StartPositionX, float StartPositionY,GameObject ParentBoard)
        {         
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (i % 2 == 0)
                    {
                        if (k % 2 == 0)
                        {
                            GameObject cell;                
                            cell = Instantiate(SquareLight, new Vector3(i + StartPositionX, k + StartPositionY), Quaternion.identity);
                            cell.GetComponent<BoardCells>()._coords = new Coordinate(i, k);
                            cell.GetComponent<BoardCells>()._cellStateEnum = CellStateEnum.Free;
                            cell.transform.parent = ParentBoard.transform;
                            Board[i, k] = cell;
                        }

                        else
                        {
                            GameObject cell;
                            cell = Instantiate(SquareDark, new Vector3(i + StartPositionX, k + StartPositionY), Quaternion.identity);
                            cell.GetComponent<BoardCells>()._coords = new Coordinate(i, k);
                            cell.GetComponent<BoardCells>()._cellStateEnum = CellStateEnum.Free;
                            cell.transform.parent = ParentBoard.transform;
                            Board[i, k] = cell;
                        }
                    }
                    else
                    {
                        if (k % 2 == 0)
                        {
                            GameObject cell;
                            cell = Instantiate(SquareDark, new Vector3(i + StartPositionX, k + StartPositionY), Quaternion.identity);
                            cell.GetComponent<BoardCells>()._coords = new Coordinate(i, k);
                            cell.GetComponent<BoardCells>()._cellStateEnum = CellStateEnum.Free;
                            cell.transform.parent = ParentBoard.transform;
                            Board[i, k] = cell;
                        }

                        else
                        {
                            GameObject cell;
                            cell =Instantiate(SquareLight, new Vector3(i + StartPositionX, k + StartPositionY), Quaternion.identity);
                            cell.GetComponent<BoardCells>()._coords = new Coordinate(i, k);
                            cell.GetComponent<BoardCells>()._cellStateEnum = CellStateEnum.Free;
                            cell.transform.parent = ParentBoard.transform;
                            Board[i, k] = cell;
                        }
                    }
                }
            }
        }
        public void ResetColors()
        {
            foreach (GameObject g in Board)
            {
                g.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        public void SetBoardColors(List<Coordinate> _possibleMovesCoordinates,List<Coordinate> _possibleCapturesCoordinates)
        {
            ResetColors();
            foreach (Coordinate c in _possibleMovesCoordinates)
            {
                Board[c.x, c.y].GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            foreach (Coordinate c in _possibleCapturesCoordinates)
            {
                Board[c.x, c.y].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        
        public void SetBoardColors(List<Coordinate> _possibleMovesCoordinates, List<Coordinate> _possibleCapturesCoordinates, List<Coordinate> _possibleCastleCoordinates)
        {
            ResetColors();
            foreach (Coordinate c in _possibleMovesCoordinates)
            {
                Board[c.x, c.y].GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            foreach (Coordinate c in _possibleCapturesCoordinates)
            {
                Board[c.x, c.y].GetComponent<SpriteRenderer>().color = Color.red;
            }
            foreach(Coordinate c in _possibleCastleCoordinates)
            {
                Board[c.x, c.y].GetComponent<SpriteRenderer>().color = new Color(1, 0.9215686f, 0.016f, 1f);     
            }
        }
        public bool CheckCoordinate(int x, int y)
        {
            if (x < 8 && x > -1 && y < 8 && y > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

