using System;
using System.Linq;
using UnityEngine;

public class BottleHolder : UpgradeableItem
{
    [SerializeField] private WaterBottle bottleToInteract;

    [SerializeField] private GameObject[] bottles;

    private int currentIndex;

    private Action onDropBottle;

    public override void Interact()
    {
        base.Interact();

        if(Input.GetKeyDown(KeyCode.E))
        {
            Use();
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

    protected override void Use()
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
