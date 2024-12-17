using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Tap : MonoBehaviour, IInteractable, IUpgradeable
{
    [SerializeField] private WaterBottle bottleToInteract;
    [SerializeField] private ObjectSO objectSO;

    private float fillingRate;
    private ObjectData objectData;

    private void Awake()
    {
        objectData = new ObjectData()
        {
            Id = objectSO.Id,
            CurrentLevel = objectSO.StartingLevel,
            CurrentValue = objectSO.StartingValue,
            ValueScale = objectSO.ValueScale,
            CurrentCost = objectSO.StartingCost,
            CostScale = objectSO.CostScale,
        };

        fillingRate = objectData.CurrentValue;
    }

    public void ApplyUpgrade()
    {
        fillingRate = objectData.CurrentValue;
    }

    public void Interact()
    {
        if(Input.GetKey(KeyCode.E))
        {
            Use();
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            bottleToInteract.StopFilling();
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            ShopManager.Instance.Setup(objectData, ApplyUpgrade);
        }
    }

    private void Use()
    {
        bottleToInteract.Fill(fillingRate * Time.deltaTime);
    }
}
