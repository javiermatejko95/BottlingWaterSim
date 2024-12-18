using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeSystemManager : Singleton<UpgradeSystemManager>
{
    [SerializeField] private UpgradeableObject[] upgradeableObjects;

    private List<IUpgradeable> upgradeableObjectsList;

    public UpgradeableObject[] UpgradeableObjects { get => upgradeableObjects; }

    public void ApplyUpgrade(string id)
    {
        upgradeableObjects.FirstOrDefault(s => s.Id == id).ObjectModel.GetComponent<IUpgradeable>().ApplyUpgrade();
    }

    public ObjectData GetObjectData(string id)
    {
        return upgradeableObjects.FirstOrDefault(s => s.Id == id).ObjectModel.GetComponent<IUpgradeable>().GetObjectData();
    }
}
