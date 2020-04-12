using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerWithCallback : MonoBehaviour
{

    public void StartTimer( float time, DelegateCreator.OnComplete onComplete )
    {
        StartCoroutine(RunTimer(time, onComplete));
    }

    private IEnumerator RunTimer( float time, DelegateCreator.OnComplete onComplete )
    {
        yield return new WaitForSeconds(time);

        onComplete.Invoke(4.5f);
    }
	
}
