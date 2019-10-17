using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Text timeText;
    private float timeCount;

   
    void Start()
    {
        timeText = GameObject.Find("Distance").GetComponent<Text>();   
    }

    private void Update()
    {
        timeCount = Time.deltaTime + timeCount + 2;
        SetCountText();
    }

    void SetCountText()
    {
        timeText.text = timeCount.ToString() + "[m]";
    }

}
