using ChessGame.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ChessGame.UI
{
    public class GameOverPanelController : MonoBehaviour
    {      
        public Text _text;      
        public void SetActivePanel(bool WhiteWon)
        {
            GameObject.Find("Text").SetActive(false);

            if (WhiteWon)
            {
               _text.text = "White Won";
                gameObject.SetActive(true);
            }
            else
            {
                _text.text = "Black Won";
                gameObject.SetActive(true);
            }
            
        }
        public void SetActivePanel()
        {
            GameObject.Find("Text").SetActive(false);
            gameObject.SetActive(true);
           _text.text = "Black Resigned";
            
        }
        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
      
    }
}

