using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public static event Action<bool> OnMusicStateChanged;
    
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _onMusicImage;
    [SerializeField] private Sprite _offMusicImage;
    [SerializeField] private float _scaleTime;
    [SerializeField] private float _scaleValue;
    private bool _stateButton = true;

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        SwitchState();
        SwitchImage();
        ScaleAnim();
    }

    private void ScaleAnim()
    {
        DOTween.Sequence()
            .Append(_button.transform.DOScale(_scaleValue, _scaleTime))
            .Append(_button.transform.DOScale(1, _scaleTime));
    }

    private void SwitchImage()
    {
        if (_stateButton)
        {
            _button.GetComponent<Image>().sprite = _onMusicImage;
        }
        else if(!_stateButton)
        {
            _button.GetComponent<Image>().sprite = _offMusicImage;
        }
    }

    private void SwitchState()
    {
        _stateButton = !_stateButton;
        OnMusicStateChanged?.Invoke(_stateButton);
    }
}
