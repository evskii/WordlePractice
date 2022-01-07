using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using Random = UnityEngine.Random;

public static class WordManager
{
    public static List<string> allWords = new List<string>();
    public static List<string> commonWords = new List<string>();
    
    [RuntimeInitializeOnLoadMethod]
    public static void InitFile() {
        //Init the list of all words
        var wordFile = Resources.Load<TextAsset>("Words"); //Get our Words.txt file
        var rawWords = wordFile.text.Split('\n').ToList(); //Split the file into new lines

        foreach (var word in rawWords) {

            if (!word.Contains("-") && !word.Contains(" ") && !word.Contains(",") && !word.Contains(".") && !word.Contains("&")) {
                allWords.Add(word.Trim().ToUpper());
            }
        }
        
        Debug.Log("<color=green> All words have been initialized with: " + allWords.Count + " words! </color>");
        
        //Init the common words list
        var commonWordFile = Resources.Load<TextAsset>("CommonWords");
        var rawCommonWords = commonWordFile.text.Split('\n').ToList();

        foreach (var word in rawCommonWords) {
            if (!word.Contains("-") && !word.Contains(" ") && !word.Contains(",") && !word.Contains(".") && !word.Contains("&")) {
                commonWords.Add(word.Trim().ToUpper());
            }
        }
        
        Debug.Log("<color=blue> Common words have been initialized with: " + commonWords.Count + " words! </color>");
    }
    

    public static string GetRandomWord(int length) {
        var wordsOfLength = new List<string>();
        foreach (var word in commonWords) {
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
