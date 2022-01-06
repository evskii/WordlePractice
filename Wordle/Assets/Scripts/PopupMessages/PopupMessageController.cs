using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

public class PopupMessageController : MonoBehaviour
{
    public static PopupMessageController instance;

    private void Awake() {
        instance = this;
    }

    public GameObject messagePrefab;

    public void NewMessage(string message, float time) {
        var newMes = Instantiate(messagePrefab, transform);
        newMes.GetComponent<Message>().InitMessage(message, time);
    }

    public void ClearMessages() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

}
