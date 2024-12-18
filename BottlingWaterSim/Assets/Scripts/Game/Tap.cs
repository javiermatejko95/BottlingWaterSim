using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Tap : MonoBehaviour, IInteractable, IUpgradeable
{
    [SerializeField] private WaterBottle bottleToInteract;
    [SerializeField] private ObjectSO objectSO;

    private ObjectData objectData;

    private void Awake()
    {
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

    public void ApplyUpgrade()
    {
        objectData.LevelUp();
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
            ShopManager.Instance.Setup(objectData);
        }
    }

    public ObjectData GetObjectData()
    {
        return objectData;
    }

    private void Use()
    {
        bottleToInteract.Fill(objectData.CurrentValue * Time.deltaTime);
    }    
}
