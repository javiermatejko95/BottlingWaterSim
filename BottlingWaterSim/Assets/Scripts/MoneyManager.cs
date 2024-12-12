using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] private TextMeshProUGUI txtMoney;

    private int currentMoney;

    protected override void Awake()
    {
        base.Awake();

        currentMoney = 0;

        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;

        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        txtMoney.text = $"$ {currentMoney}";
    }
}
