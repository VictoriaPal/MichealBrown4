using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnJumpEvent : UnityEvent { }

[System.Serializable]
public class OnDirectionEvent : UnityEvent<float, float> { }

public class UnityEventExample : MonoBehaviour
{
    public OnJumpEvent OnJump = new OnJumpEvent();

    public OnDirectionEvent OnDirection = new OnDirectionEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnJump.Invoke();
        }

        OnDirection.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
