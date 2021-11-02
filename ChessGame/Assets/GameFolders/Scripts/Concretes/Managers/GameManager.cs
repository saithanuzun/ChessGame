using ChessGame.Abstract.BasePiece;
using ChessGame.AI;
using ChessGame.Structs;
using ChessGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private BoardManager _boardManager;
        private PieceManager _pieceManager;
        private AIController _AIController;

        public bool TurnMove=true;

        [SerializeField]
        private float ImThinking = 0.0f;

        [SerializeField]
        GameOverPanelController _gameOverPanelController;

        private void Awake()
        {
            _boardManager = BoardManager.Instance;
            _pieceManager = PieceManager.Instance;
            _AIController = AIController.Instance;

            _gameOverPanelController = FindInActiveObjectByName("GameOverPanel").GetComponent<GameOverPanelController>();

        }      
        private void Update()
        {
            if (!TurnMove)
            {
                ImThinking -= Time.deltaTime;
                if (ImThinking <= 0)
                {
                    ImThinking = Random.Range(0.0f, 2.5f);
                    _AIController.SetMove();
                }    
            }
        }
        private GameObject FindInActiveObjectByName(string name)
        {
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].hideFlags == HideFlags.None)
                {
                    if (objs[i].name == name)
                    {
                        return objs[i].gameObject;
                    }
                }
            }
            return null;
        }
        public void DestroyScene()
        {
            Destroy(GameObject.Find("Board"));
            Destroy(GameObject.Find("Pieces"));

        }
        public void FinishTheGame(bool WhiteWon)
        {
            _gameOverPanelController.SetActivePanel(WhiteWon);
            Time.timeScale = 0f;
        }
        public void FinishTheGame()
        {
            _gameOverPanelController.SetActivePanel();
            Time.timeScale = 0f;
        }
        public void RestartGame()
        {
            Time.timeScale = 1f;
            _gameOverPanelController.ClosePanel();
            DestroyScene();
            StartGame();            
            TurnMove = true;
        }
        public void StartGame()
        {
            _boardManager.CreateBoard(-3.5f, -3.5f, new GameObject("Board"));
            _pieceManager.CreatePieces(new GameObject("Pieces"));
            _pieceManager.SetBlackAndWhitePieces();
        }
    }
}

