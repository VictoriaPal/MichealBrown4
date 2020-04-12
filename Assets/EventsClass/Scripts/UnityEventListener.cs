using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventListener : MonoBehaviour
{

    public UnityEventExample EventExample;

    private void OnEnable()
    {
        EventExample.OnJump.AddListener(OnJump);
    }

    private void OnDisable()
    {
        EventExample.OnJump.RemoveListener(OnJump);
    }

    public void OnJump()
    {
        Debug.Log("I heard I should jump?");
    }

    public void OnJump( string jumpString )
    {
        Debug.Log("Jump string is: " + jumpString);
    }

    public void PrintInput( float x, float y )
    {
        Debug.Log(string.Format("x: {0}, y: {1}", x, y));
    }
    
}
