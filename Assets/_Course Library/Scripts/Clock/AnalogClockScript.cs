using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClockScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject analogClockObject;
    private GameObject hoursObject;
    private GameObject minutesObject;
    private GameObject secondsObject;

    void Start()
    {
        analogClockObject = GameObject.Find("Clock_Analog_Red");
        hoursObject = analogClockObject.transform.GetChild(1).gameObject;
        minutesObject = analogClockObject.transform.GetChild(2).gameObject;
        secondsObject = analogClockObject.transform.GetChild(3).gameObject;

        Debug.Log("hours object name : " + hoursObject.name);
        Debug.Log("minutes object name : " + minutesObject.name);
        Debug.Log("seconds object name : " + secondsObject.name);

        DateTime time = DateTime.Now;
        Debug.Log("Time : " + time.Hour + ":" + time.Minute + ":" + time.Second);
    }

    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;


    void Update()
    {
        /*DateTime time = DateTime.Now;
        hoursObject.transform.rotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
        minutesObject.transform.rotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
        secondsObject.transform.rotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);*/

        TimeSpan timespan = DateTime.Now.TimeOfDay;
        hoursObject.transform.localRotation =
                Quaternion.Euler((float)timespan.TotalHours * hoursToDegrees, 0f, 0f);
        minutesObject.transform.localRotation =
            Quaternion.Euler((float)timespan.TotalMinutes * minutesToDegrees, 0f, 0f) ;
        secondsObject.transform.localRotation =
            Quaternion.Euler((float)timespan.TotalSeconds * secondsToDegrees, 0f, 0f);
    }
}
