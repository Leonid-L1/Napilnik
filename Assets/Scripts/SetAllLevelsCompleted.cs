using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllLevelsCompleted : MonoBehaviour
{
    private int allLevelsCount = 31;

    private void Start()
    {
        for (int i = 0; i < allLevelsCount; i++)
        {
            PlayerPrefs.SetString(i.ToString() + StaticFields.IsCompleted, StaticFields.IsCompleted);
            PlayerPrefs.SetInt(i.ToString() + StaticFields.StarsCount, 3);
        }
    }
}
