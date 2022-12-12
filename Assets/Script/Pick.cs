using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    GameObject Quiz;

    private void Start()
    {
        Quiz = GameObject.Find("Quiz");
    }

    private void OnMouseDown()
    {
        Quiz.GetComponent<Quiz>().pick = new List<string>(Quiz.GetComponent<Quiz>().pick) { gameObject.name }.ToArray();
    }
}
