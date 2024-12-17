using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] private TextMeshProUGUI txtMoney;

    [SerializeField] private int moMani = 100;

    private int currentMoney;

    public event Action<int> OnUpdateMoney;

    public int CurrentMoney { get => currentMoney; }

    protected override void Awake()
    {
        base.Awake();

        currentMoney = 0;

        UpdateMoneyText();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            UpdateMoney(moMani);
        }
    }

    public void UpdateMoney(int amount)
    {
        currentMoney += amount;

        UpdateMoneyText();
    }

    public void RemoveMoney(int amount)
    {
        currentMoney -= amount;

        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        txtMoney.text = $"$ {currentMoney}";

        OnUpdateMoney?.Invoke(currentMoney);
    }
}
