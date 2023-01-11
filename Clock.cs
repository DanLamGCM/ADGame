using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Clock : MonoBehaviour
{

    public TMP_Text clockText;
    public DateTime startTime;
    public TimeSpan curTime;

    void Start()
    {
        startTime = DateTime.Now;
        curTime = new TimeSpan(0);
    }

    // Update is called once per frame
    void Update()
    {
        curTime = (DateTime.Now - startTime).Multiply(2);

        clockText.text = curTime.ToString(@"hh\:mm\:ss");
    }
}
