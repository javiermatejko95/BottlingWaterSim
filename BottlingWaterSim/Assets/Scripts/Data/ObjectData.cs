using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectData
{
    [SerializeField] private string id;

    [SerializeField] private int currentLevel;

    [SerializeField] private float currentValue;
    [SerializeField] private float valueScale;

    [SerializeField] private int upgradeCost;
    [SerializeField] private int upgradeCostScale;

    public string Id { get => id; set => id = value; }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }


    public float CurrentValue { get => currentValue; set => currentValue = value; }
    public float ValueScale { get => valueScale; set => valueScale = value; }

    public int UpgradeCost { get => upgradeCost; set => upgradeCost = value; }
    public int UpgradeCostScale { get => upgradeCostScale; set => upgradeCostScale = value; }

    public void LevelUp()
    {
        currentLevel++;
        currentValue += valueScale;
        upgradeCost += upgradeCostScale;
    }
}
