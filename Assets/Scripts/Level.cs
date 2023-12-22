using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static event Action OnChangedLevelEvent;
    public static event Action OnChangedExpEvent;
    
    private static int _level = 1;
    private static float _experience;
    private static float _currentExp = 0f;

    public static int level
    {
        get { return _level; }
    }
    
    public static float experience
    {
        get { return _experience; }
    }
    
    public static float currentExp
    {
        get { return _currentExp; }
    }
    
    public static Level instance { get; private set; }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this);
    }

    void Start()
    {
        Load();
    }

    public static void AddExp(float experience)
    {
        OnChangedExpEvent?.Invoke();
        _currentExp += experience;
        CheckFullExp();
        Save();
    }

    public static void AddLevel(int level)
    {
        if (level >= 0)
        {
            _level += level;
            UpdateExperienceValue();
            Save();
            OnChangedLevelEvent?.Invoke();
        }
        
    }

    public static void Reset()
    {
        _level = 1;
        _experience = 100f;
        _currentExp = 0;
        OnChangedLevelEvent?.Invoke();
        OnChangedExpEvent?.Invoke();
        Save();
    }

    private static void CheckFullExp()
    {
        if (_currentExp >= _experience)
        {
            _currentExp -= _experience;
            AddLevel(1);
        }
    }

    private static void UpdateExperienceValue()
    {
        _experience = _experience * _level;
    }
    
    private static void Save() 
    {
        PlayerPrefs.SetInt("LEVEL_level", _level);
        PlayerPrefs.SetFloat("LEVEL_currentExp", _currentExp);
        PlayerPrefs.SetFloat("LEVEL_experience", _experience);
    }
    
    private static void Load()
    {
        _level = PlayerPrefs.GetInt("LEVEL_level", 1);
        _currentExp = PlayerPrefs.GetFloat("LEVEL_currentExp", 0);
        _experience = PlayerPrefs.GetFloat("LEVEL_experience", 100);
        OnChangedLevelEvent?.Invoke();
    }
}
