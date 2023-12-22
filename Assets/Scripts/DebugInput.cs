using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts
{
    public class DebugInput : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Level.AddExp(20);
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                Level.AddLevel(1);
                Debug.Log($"+1 level");
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                Level.Reset();
            }
            
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log($"Level: {Level.level}, FullExp: {Level.experience}, currentExp: {Level.currentExp}");
            }
        }
        
    }
}