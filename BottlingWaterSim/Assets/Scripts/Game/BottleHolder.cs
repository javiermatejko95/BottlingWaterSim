using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System;

public class BottleHolder : MonoBehaviour, IInteractable, IUpgradeable
{
    [SerializeField] private WaterBottle bottleToInteract;
    [SerializeField] private ObjectSO objectSO;

    [SerializeField] private GameObject[] bottles;

    private int currentIndex;

    private ObjectData objectData;

    private Action onDropBottle;

    private void Awake()
    {
        currentIndex = 0;

        objectData = new ObjectData()
        {
            Id = objectSO.Id,
            CurrentLevel = objectSO.StartingLevel,
            CurrentValue = objectSO.StartingValue,
            ValueScale = objectSO.ValueScale,
            UpgradeCost = objectSO.StartingUpgradeCost,
            UpgradeCostScale = objectSO.UpgradeCostScale,
        };
    }

    public void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ShopManager.Instance.Setup(objectData);
        }
    }

    public bool HasActiveBottle()
    {
        return bottles.Any(b => b.activeSelf);
    }

    public void SuscribeToAction(Action onAction)
    {
        onDropBottle += onAction;
    }

    public void UnsuscribeToAction(Action onAction)
    {
        onDropBottle -= onAction;
    }

    public void SellBottle()
    {
        currentIndex--;

        bottles[currentIndex].gameObject.SetActive(false);

        MoneyManager.Instance.UpdateMoney((int)objectData.CurrentValue);
        CustomersManager.Instance.AddCustomers(1);
    }

    public void ApplyUpgrade()
    {
        objectData.LevelUp();
    }

    public ObjectData GetObjectData()
    {
        return objectData;
    }

    private void Use()
    {
        if (currentIndex >= bottles.Length || !bottleToInteract.IsActive() || bottleToInteract.GetStatus() != BOTTLE_STATUS.FULL)
        {
            return;
        }

        bottleToInteract.Drop();

        bottles[currentIndex].gameObject.SetActive(true);

        currentIndex++;

        onDropBottle?.Invoke();
    }
}
