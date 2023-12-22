using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
  
    void Start()
    {
        OnChangedLevel();
        Level.OnChangedLevelEvent += OnChangedLevel;
    }

    private void OnDisable()
    {
        Level.OnChangedLevelEvent -= OnChangedLevel;
    }
    private void OnChangedLevel()
    {
        levelText.text = Level.level.ToString();
    }
}
