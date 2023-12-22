using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class MainMenu : MonoBehaviour
{

    public static event Action OnResetEvent;

    public float clickAutoReward = 1;
    public float clickReward = 1;
    public TMP_Text moneyText;
    public GameObject button;
    public float second;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BuyButton.OnClickRewardChangedEvent += UpdateClickReward;
        clickAutoReward = PlayerPrefs.GetFloat("clickAutoReward");
        clickReward = PlayerPrefs.GetFloat("clickReward");
        StartCoroutine(IdleFarm());
    }

    private void OnDisable()
    {
        StopCoroutine(IdleFarm());
        BuyButton.OnClickRewardChangedEvent -= UpdateClickReward;
    }

    public void ButtonClick()
    {
        Wallet.AddMoney(clickReward);
        button.GetComponent<RectTransform>().localScale = new Vector3(0.95f, 0.95f, 0f);
        clickReward = PlayerPrefs.GetFloat("clickReward");
        Level.AddExp(clickReward);
        audioSource.Play();
    }

    public void OnClickUp()
    {
        button.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSecondsRealtime(second);
        Wallet.AddMoney(clickAutoReward);
        Debug.Log("money");
        StartCoroutine(IdleFarm());
    }

    private void UpdateClickReward()
    {
        clickAutoReward = PlayerPrefs.GetFloat("clickAutoReward");
        clickReward = PlayerPrefs.GetFloat("clickReward");
    }

    private void Reset()
    {
        PlayerPrefs.SetFloat("clickReward", clickReward = 1);
        PlayerPrefs.SetFloat("clickAutoReward", clickReward = 1);
        UpdateClickReward();
        OnResetEvent?.Invoke();
    }
    
    private void Update()
    {
        moneyText.text = $"{FormatNums.FormatNum(Wallet.money)}<sprite name=\"DuckAsset_0\">";
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
}
