using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    public string currentLineWord;
    
   [HideInInspector] public List<TMP_Text> letterSpots = new List<TMP_Text>();
   [HideInInspector] public List<Image> letterSquares = new List<Image>();

    public Sprite blankLetterSprite;
    public Sprite[] letterSquareSprites;

    public void Start() {
        //Get our letter and image spots
        letterSpots = GetComponentsInChildren<TMP_Text>().ToList();
        letterSquares = GetComponentsInChildren<Image>().ToList();
        
        //Make all squares blank
        for (int i = 0; i < letterSpots.Count; i++) {
            letterSpots[i].text = "";
            letterSquares[i].sprite = blankLetterSprite;
        }
    }

    private void Update() {
        UpdateWord();
    }

    public void UpdateWord() {
        for (int i = 0; i < letterSpots.Count; i++) {
            if (i < currentLineWord.Length) {
                letterSpots[i].text = currentLineWord[i].ToString();
            } else {
                letterSpots[i].text = "";
            }
        }
    }

    public void CheckWord() {
        var comparedValues = WordController.instance.CompareWord(currentLineWord);
        for (int i = 0; i < letterSquares.Count; i++) {
            letterSquares[i].sprite = letterSquareSprites[comparedValues[i]];
        }
        WordController.instance.NextLine();
    }
}
