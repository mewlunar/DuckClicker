using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public static event Action OnClickRewardChangedEvent;

    [SerializeField] private float _clickReward;
    [SerializeField] private string _id;
    [SerializeField] private Button _button;
    [SerializeField] private float _priceUpgrade;
    [SerializeField] private bool _isActive = true;
    [SerializeField] private bool _autoClickButton;

    private void Start()
    {
        Active();
        MainMenu.OnResetEvent += Reset;
        Wallet.OnChangedMoneyEvent += Active;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        MainMenu.OnResetEvent -= Reset;
        Wallet.OnChangedMoneyEvent -= Active;
        _button.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        TrySpendMoney();
    }

    private void Active()
    {
        if (Wallet.money < _priceUpgrade) _button.interactable = false;
        else _button.interactable = true;
    }

    private void TrySpendMoney()
    {
        if (Wallet.money >= _priceUpgrade)
        {
            Wallet.SpendMoney(_priceUpgrade);
            SetClickReward();
        }
    }

    private void SetNotActive()
    {
        _button.interactable = false;
        _isActive = false;
        Save();
    }

    private void SetClickReward()
    {
        if (_autoClickButton) PlayerPrefs.SetFloat("clickAutoReward", CalculateReward());
        else PlayerPrefs.SetFloat("clickReward", CalculateReward());
        OnClickRewardChangedEvent?.Invoke();
    }

    private float CalculateReward()
    {
        float currentReward;
        
        if (_autoClickButton) currentReward = PlayerPrefs.GetFloat("clickAutoReward", 1);
        else currentReward = PlayerPrefs.GetFloat("clickReward", 1);

        return (currentReward + _clickReward);
    }

    private void Reset()
    {
        PlayerPrefs.SetInt(_id + "MenuTab", 1);
        _button.interactable = true;
    }

    private void Save()
    {
        PlayerPrefs.SetInt(_id + "MenuTab",_isActive ? 1 : 0);
    }

    private void Load()
    {
        _isActive = PlayerPrefs.GetInt(_id + "MenuTab", 1) == 1 ? true : false;
        
    }
}
