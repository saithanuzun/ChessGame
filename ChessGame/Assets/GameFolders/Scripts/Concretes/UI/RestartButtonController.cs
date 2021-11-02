using ChessGame.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace ChessGame.UI
{
    public class RestartButtonController : MonoBehaviour
    {
        public void Restart()
        {
            GameManager.Instance.RestartGame();
            
        }
    }
}

