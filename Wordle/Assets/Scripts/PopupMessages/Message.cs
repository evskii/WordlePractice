using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Message : MonoBehaviour
{
    public void InitMessage(string message, float time) {
        GetComponentInChildren<TMP_Text>().text = message;
        Invoke("DestroySelf", time);
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }
}
