using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ProgressBarLvl : MonoBehaviour
    {
        void Start()
        {
            Level.OnChangedExpEvent += UpdateFillValue;
        }

        private void OnDisable()
        {
            Level.OnChangedExpEvent -= UpdateFillValue;
        }

        private void UpdateFillValue()
        {
            GetComponent<Image>().fillAmount = Level.currentExp / Level.experience;
        }
    }
}