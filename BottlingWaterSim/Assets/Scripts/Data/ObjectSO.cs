using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Game Data/Object")]
public class ObjectSO : ScriptableObject
{
    [SerializeField] private OBJECT_DATATYPE type;

    [SerializeField] private string id;

    [SerializeField] private int startingLevel;

    [SerializeField] private float startingValue;
    [SerializeField] private float valueScale;

    [SerializeField] private int startingUpgradeCost;
    [SerializeField] private int upgradeCostScale;

    public OBJECT_DATATYPE Type { get => type; }

    public string Id { get => id; }

    public int StartingLevel { get => startingLevel; }

    public float StartingValue { get => startingValue; }
    public float ValueScale { get => valueScale; }

    public int StartingUpgradeCost { get => startingUpgradeCost; }
    public int UpgradeCostScale { get => upgradeCostScale; }
}

public enum OBJECT_DATATYPE
{
    RATE,
    COST,
}
