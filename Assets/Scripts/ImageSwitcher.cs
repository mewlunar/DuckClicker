using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image; 
    
    void Start()
    {
        Level.OnChangedLevelEvent += OnLevelChanged;
        TrySetImageByLevel();
    }

    void OnDisable()
    {
        Level.OnChangedLevelEvent -= OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        TrySetImageByLevel();
    }

    private bool TrySetImageByLevel()
    {
        bool isSetted = false;
        if (_sprites.Length > Level.level - 1)
        {
            Debug.Log($"{Level.level}");
            _image.sprite = _sprites[Level.level - 1];
            return !isSetted;
        }

        else
        {
            _image.sprite = _sprites[_sprites.Length - 1];
            return !isSetted;
        }

        return isSetted;
    }
}
