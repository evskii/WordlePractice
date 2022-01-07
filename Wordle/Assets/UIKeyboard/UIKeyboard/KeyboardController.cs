using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public string typedString = "";
    
    public void GetKey(char key) {
        if (WordController.instance.typing && typedString.Length < WordController.instance.wordLength) {
            typedString += key;
            WordController.instance.lines[WordController.instance.currentLineIndex].currentLineWord = typedString;
        }
    }

    public void Backspace() {
        if (typedString.Length > 0) {
            typedString = typedString.Remove(typedString.Length - 1, 1);
            WordController.instance.lines[WordController.instance.currentLineIndex].currentLineWord = typedString;
        }
    }

    public void Enter() {
        if (typedString.Length == WordController.instance.wordLength) {
            WordController.instance.lines[WordController.instance.currentLineIndex].CheckWord();
        } else {
            PopupMessageController.instance.NewMessage("Little too short there bud...", 3f);
        }
    }
}
