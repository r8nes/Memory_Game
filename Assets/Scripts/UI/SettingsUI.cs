using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{

    [SerializeField] private LevelData _levelData = null;
    [SerializeField] private Button _easyButton = null;
    [SerializeField] private Button _themeButton = null;
    public void SetDifficult(int value)
    {
        _levelData.MaxPlayCard = value;

    }

    public void SetTheme(string name)
    { 
        _levelData.ThemeName = name;
    }

    private void OnEnable()
    {
        _easyButton.onClick.Invoke();
        _themeButton.onClick.Invoke();
    }
}
