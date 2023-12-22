using TMPro;
using UnityEngine;

public class AutoClickTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    void Start()
    {
        UpdateText();
        BuyButton.OnClickRewardChangedEvent += UpdateText;
        MainMenu.OnResetEvent += UpdateText;
    }

    private void OnDisable()
    {
        BuyButton.OnClickRewardChangedEvent -= UpdateText;
        MainMenu.OnResetEvent -= UpdateText;
    }

    private void UpdateText()
    {
        _text.text = $"{FormatNums.FormatNum(PlayerPrefs.GetFloat("clickAutoReward"))}<sprite name=\"DuckAsset_0\"> в сек.";
    }
}
