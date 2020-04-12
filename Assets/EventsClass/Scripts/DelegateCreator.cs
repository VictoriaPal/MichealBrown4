using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateCreator : MonoBehaviour
{
    public delegate void OnComplete(float value);

    public TimerWithCallback Timer;
    public float TimerLength;

    //public OnComplete myOnCompleteMethod;

    //// Use this for initialization
    //void Start()
    //{
    //    myOnCompleteMethod = WhenTimerIsDone;
    //}

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Timer.StartTimer(TimerLength, WhenTimerIsDone);
        }
    }



    private void WhenTimerIsDone(float value)
    {
        Debug.Log("Do the thing. " + value);
    }
}
