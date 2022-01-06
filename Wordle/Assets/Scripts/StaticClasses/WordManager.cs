using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public static class WordManager
{
    public static List<string> allWords = new List<string>();
    
    [RuntimeInitializeOnLoadMethod]
    public static void InitFile() {
        var wordFile = Resources.Load<TextAsset>("Words"); //Get our Words.txt file
        var rawWords = wordFile.text.Split('\n').ToList(); //Split the file into new lines

        foreach (var word in rawWords) {
            allWords.Add(word.Trim().ToUpper());
        }
        
        Debug.Log("<color=green> All words have been initialized! </color>");
    }

    public static string GetRandomWord(int length) {
        var wordsOfLength = new List<string>();
        foreach (var word in allWords) {
            if (word.Length == length) {
                wordsOfLength.Add(word);
            }
        }
        return wordsOfLength[Random.Range(0, wordsOfLength.Count)];
    }

    public static bool IsAWord(string wordToCheck) {
        return allWords.Contains(wordToCheck);
    }
}
