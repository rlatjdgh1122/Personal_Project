using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1f;
    }
    public void StopTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 0f;
    }
    public void OnDestroy()
    {
        ResetTimeScale();
    }
    public void ModifyTimeScale(float endTimeValue, float timeToWait, Action OnComplete = null)
    {
        StartCoroutine(TimeScaleCoroutine(endTimeValue, timeToWait, OnComplete));
    }
    IEnumerator TimeScaleCoroutine(float endTimeValue, float timeToWait, Action OnComplete)
    {
        Time.timeScale = endTimeValue;
        yield return new WaitForSecondsRealtime(timeToWait);
        OnComplete?.Invoke();
    }
}
