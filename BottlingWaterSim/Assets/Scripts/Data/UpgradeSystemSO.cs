using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSystem", menuName = "Game Data/Upgrade System")]
public class UpgradeSystemSO : ScriptableObject
{
    [SerializeField] private UpgradeableObject[] upgradeableObjects;

    public UpgradeableObject[] UpgradeableObjects { get => upgradeableObjects; }
}

[Serializable]
public class UpgradeableObject
{
    public string Id;
    public GameObject ObjectModel;
}
