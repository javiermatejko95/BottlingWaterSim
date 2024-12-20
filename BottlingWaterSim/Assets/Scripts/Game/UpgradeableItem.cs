using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeableItem : MonoBehaviour, IInteractable, IUpgradeable
{
    [SerializeField] private ObjectSO objectSO;
    [SerializeField] private GameObject container;

    protected ObjectData objectData;

    protected virtual void Awake()
    {
        objectData = new ObjectData()
        {
            Id = objectSO.Id,
            CurrentLevel = objectSO.StartingLevel,
            CurrentValue = objectSO.StartingValue,
            ValueScale = objectSO.ValueScale,
            UpgradeCost = objectSO.StartingUpgradeCost,
            UpgradeCostScale = objectSO.UpgradeCostScale,
            ObjectPrefabs = objectSO.ObjectPrefabs,
        };
    }

    public virtual void ApplyUpgrade()
    {
        objectData.LevelUp();
        SpawnNewLevel();
    }

    public virtual ObjectData GetObjectData()
    {
        return objectData;
    }

    public virtual void Interact()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenUpgradesShop();
        }
    }

    protected virtual void Use()
    {

    }

    protected virtual void OpenUpgradesShop()
    {
        ShopManager.Instance.Setup(objectData);
    }

    protected virtual void SpawnNewLevel()
    {
        Destroy(container.transform.GetChild(0).gameObject);

        GameObject go = Instantiate(objectData.ObjectPrefabs[objectData.CurrentLevel - 1], container.transform);
    }
}
