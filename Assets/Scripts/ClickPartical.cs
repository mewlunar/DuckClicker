using System.Collections;
using TMPro;
using UnityEngine;

public class ClickPartical : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _time = 2f;
    [SerializeField] private float _moveMultiply = 1f;
    private Vector2 _randomVector;

    void Start()
    {
        _text.text = $"+{FormatNums.FormatNum(PlayerPrefs.GetFloat("clickReward"))}<sprite name=\"DuckAsset_0\">";
        StartCoroutine(TimerDestroy());
        SetRandomValueVector();
    }

    void FixedUpdate()
    {
        transform.Translate(_randomVector);
    }

    private void SetRandomValueVector()
    {
        _randomVector = new Vector2(Random.Range(_moveMultiply, -_moveMultiply),Random.Range(_moveMultiply, -_moveMultiply));
    }

    private IEnumerator TimerDestroy()
    {
        yield return new WaitForSeconds(_time);
        Destroy(this.gameObject);
    }

}
