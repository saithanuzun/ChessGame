using ChessGame.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ChessGame.UI
{
    public class TextController : MonoBehaviour
    {
        [SerializeField] Text _text;
        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            if(GameManager.Instance.TurnMove)
            {
                _text.text = "Your Turn";
            }
            if(!GameManager.Instance.TurnMove)
            {
                _text.text = "I`m Thinking...";
            }
        }
    }
}

