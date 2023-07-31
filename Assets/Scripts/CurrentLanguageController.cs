using UnityEngine;

public static class CurrentLanguageController 
{
    private static int _currentLanguageIndex = 0;
    public static int CurrentLanguageIndex => _currentLanguageIndex;
    public static void SetNewIndex(int index) => _currentLanguageIndex = index;   
}
