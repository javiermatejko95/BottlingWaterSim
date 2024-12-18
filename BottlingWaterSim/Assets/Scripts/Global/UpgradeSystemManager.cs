using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeSystemManager : Singleton<UpgradeSystemManager>
{
    [SerializeField] private UpgradeableObject[] upgradeableObjects;

    private List<IUpgradeable> upgradeableObjectsList;

    public void ApplyUpgrade(string id)
    {
        upgradeableObjects.FirstOrDefault(s => s.Id == id).ObjectModel.GetComponent<IUpgradeable>().ApplyUpgrade();
    }

    public ObjectData GetObjectData(string id)
    {
        return upgradeableObjects.FirstOrDefault(s => s.Id == id).ObjectModel.GetComponent<IUpgradeable>().GetObjectData();
    }
}
