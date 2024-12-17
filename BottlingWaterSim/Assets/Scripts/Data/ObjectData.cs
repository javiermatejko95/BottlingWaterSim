using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData
{
    [SerializeField] private string id;

    [SerializeField] private int currentLevel;

    [SerializeField] private float currentValue;
    [SerializeField] private float valueScale;

    [SerializeField] private int currentCost;
    [SerializeField] private int costScale;

    public string Id { get => id; set => id = value; }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }


    public float CurrentValue { get => currentValue; set => currentValue = value; }
    public float ValueScale { get => valueScale; set => valueScale = value; }

    public int CurrentCost { get => currentCost; set => currentCost = value; }
    public int CostScale { get => costScale; set => costScale = value; }

    public void LevelUp()
    {
        currentLevel++;
        currentValue += valueScale;
        currentCost += costScale;
    }
}
