using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private Button btnBuy;
    [SerializeField] private TextMeshProUGUI txtLevelCost;

    private ObjectData objectData;

    private Action onBuy;

    private void Awake()
    {
        btnBuy.onClick.AddListener(BuyUpgrade);
    }

    public void Setup(ObjectData objectData, Action onFinish)
    {
        this.objectData = objectData;

        onBuy = onFinish;

        UpdateTexts(objectData);
    }

    private void BuyUpgrade()
    {
        if(ShopManager.Instance.BuyUpgrade(objectData))
        {
            objectData.LevelUp();
            onBuy?.Invoke();
            UpdateTexts(objectData);
        }
    }

    private void UpdateTexts(ObjectData objectData)
    {
        txtName.text = objectData.Id;

        txtLevelCost.text = $"Level {objectData.CurrentLevel} - $ {objectData.CurrentCost}";
    }
}
