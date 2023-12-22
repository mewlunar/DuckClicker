using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Invisible : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _endFadeValue;
    [SerializeField] private float _fadeDuration;

    public void Start()
    {
        StartCoroutine(StartFading());
    }

    private void FadeOut()
    {
        _animator.SetBool("faded", false);
    }
    
    private void FadeIn()
    {
        _animator.SetBool("faded", true);
    }

    private IEnumerator StartFading()
    {
        FadeOut();
        yield return new WaitForSecondsRealtime(_fadeDuration);
        FadeIn();
        yield return new WaitForSecondsRealtime(_fadeDuration);
        StartCoroutine(StartFading());
    }
}
