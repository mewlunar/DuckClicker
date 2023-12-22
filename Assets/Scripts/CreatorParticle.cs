using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorParticle : MonoBehaviour
{
    [SerializeField] private ClickPartical _partical;
    [SerializeField] private Button _button;
    
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
        CreatePartical();
    }

    private void CreatePartical()
    {
        var transform = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var createdPartical = Object.Instantiate(_partical, _button.transform);
        createdPartical.transform.position = transform;
    }
}
