using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class WordController : MonoBehaviour
{
    public static WordController instance;

    private void Awake() {
        instance = this;
    }

    public int wordLength = 5;
    public string currentWord;

    public int currentLineIndex = 0;
    public List<Line> lines = new List<Line>();

    public void Start() {
        StartGameplay();
    }

    public void StartGameplay() {
        currentWord = WordManager.GetRandomWord(wordLength);
        Debug.Log("Current Word: " + currentWord);
    }

    //Return an array that shows the comparrison between the two words
    //0 = Letter not in word
    //1 = Letter in word, but wrong spot
    //2 = Letter in the correct spot
    //E.G Freak & Folks == [2, 0, 0, 0, 2]
    //E.G Break & Freak == [0, 2, 2, 2, 2]
    public int[] CompareWord(string wordToCompare) {
        int[] wordComparrison = new int[currentWord.Length]; //Create an array of ints the length of our current word
        for (int i = 0; i < currentWord.Length; i++) {
            if (!currentWord.Contains(wordToCompare[i])) {
                wordComparrison[i] = 0;
            } else {
                if (wordToCompare[i] == currentWord[i]) {
                    wordComparrison[i] = 2;
                } else {
                    wordComparrison[i] = 1;
                }
            }
        }
        // Debug.Log("ToCompare: " + wordToCompare + " CurrentWord: " + currentWord + " = [" + wordComparrison[0] + "," + wordComparrison[1] + "," +wordComparrison[2] + "," +wordComparrison[3] + "," +wordComparrison[4] + "]");
        if (CorrectAnswer(wordToCompare)) {
            Debug.Log("<color=green>WINNER!</color>");
        }
        return wordComparrison;
    }

    public bool CorrectAnswer(string wordToCompare) {
        if (wordToCompare.ToUpper() == currentWord.ToUpper()) {
            return true;
        } else {
            return false;
        }
    }

    public void NextLine() {
        if (currentLineIndex < lines.Count) {
            lines[currentLineIndex].enabled = false;
            currentLineIndex++;
            lines[currentLineIndex].enabled = true;
        }
    }
}
