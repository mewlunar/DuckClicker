using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Wallet : MonoBehaviour
    {
        public static event Action OnChangedMoneyEvent; 
        
        private static double _money = 0;

        public static double money
        {
            get { return _money; }
        }
        public static Wallet instance { get; private set; }
        

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
                return;
            }
            Destroy(this);
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDisable()
        {
            MainMenu.OnResetEvent -= Reset;
        }

        private void Initialize()
        {
            Load();
            MainMenu.OnResetEvent += Reset;
        }

        public static void AddMoney(double money)
        {
            CheckValid(money);
            _money += money;
            OnChangedMoneyEvent?.Invoke();
            Save();
        }

        public static void SpendMoney(double money)
        {
            if (money <= _money && CheckValid(money)) _money -= money;
            OnChangedMoneyEvent?.Invoke();
            Save();
        }

        public static void Reset()
        {
            _money = 0;
            Save();
        }

        private static bool CheckValid(double money)
        {
            if (money >= 0) return true;

            else return false;
            
        }

        private static void Save() 
        {
            PlayerPrefs.SetFloat("WALLET_money", (float)_money);
        }
        
        private static void Load()
        {
            _money = PlayerPrefs.GetFloat("WALLET_money");
        }
    }
}