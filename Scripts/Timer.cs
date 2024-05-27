using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
public class Timer : MonoBehaviour
{
 
    [SerializeField] TMP_Text timerText;
    [SerializeField] float time;
    TimeSpan timespan;
 
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
 
        timespan = TimeSpan.FromSeconds(time);
 
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}",timespan.Hours,timespan.Minutes,timespan.Seconds);
    }
}
