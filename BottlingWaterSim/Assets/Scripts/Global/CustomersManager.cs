using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomersManager : Singleton<CustomersManager>
{
    [SerializeField] private TextMeshProUGUI txtCustomers;

    private int currentCustomers;

    protected override void Awake()
    {
        base.Awake();
        currentCustomers = 0;
        UpdateCustomersText();
    }

    public void AddCustomers(int amount)
    {
        currentCustomers += amount;

        UpdateCustomersText();
    }

    private void UpdateCustomersText()
    {
        txtCustomers.text = $"Customers: {currentCustomers}";
    }
}
