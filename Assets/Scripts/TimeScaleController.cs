using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    public void StopTime() =>  Time.timeScale = 0f;

    public void StartTime() => Time.timeScale = 1f;
}
