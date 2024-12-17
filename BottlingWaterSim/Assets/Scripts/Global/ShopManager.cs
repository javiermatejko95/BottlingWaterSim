using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private ShopItem itemPrefab;

    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private GameObject itemsContainer;

    [SerializeField] private TextMeshProUGUI txtMoney;

    [SerializeField] private Button btnClose;

    private List<ShopItem> currentItems;

    private void Awake()
    {
        currentItems = new List<ShopItem>();
        btnClose.onClick.AddListener(Close);

        MoneyManager.Instance.OnUpdateMoney += UpdateMoney;
    }

    public void Setup(ObjectData objectData, Action onFinish)
    {
        txtName.text = objectData.Id;

        ShopItem shopItem = Instantiate(itemPrefab, itemsContainer.transform);
        shopItem.Setup(objectData, onFinish);
        currentItems.Add(shopItem);

        //for (int i = 0; i < objectData.Length; i++)
        //{
        //    ShopItem shopItem = Instantiate(itemPrefab, itemsContainer.transform);
        //    shopItem.Setup(objectData[i]);
        //    currentItems.Add(shopItem);
        //}

        Open();
    }

    public bool BuyUpgrade(ObjectData objectData)
    {
        if(objectData.CurrentCost <= MoneyManager.Instance.CurrentMoney)
        {
            MoneyManager.Instance.RemoveMoney(objectData.CurrentCost);

            return true;
        }

        return false;
    }

    public void Open()
    {
        CursorManager.Instance.SetCursorStatus(CursorLockMode.None);
        shopUI.SetActive(true);
    }

    public void Close()
    {
        CursorManager.Instance.SetCursorStatus(CursorLockMode.Locked);

        shopUI.SetActive(false);

        for(int i = 0; i < currentItems.Count; i++)
        {
            Destroy(currentItems[i].gameObject);
        }

        txtName.text = string.Empty;

        currentItems.Clear();
    }

    private void UpdateMoney(int amount)
    {
        txtMoney.text = $"$ {MoneyManager.Instance.CurrentMoney}";
    }
}
