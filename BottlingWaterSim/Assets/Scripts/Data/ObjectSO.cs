using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Game Data/Object")]
public class ObjectSO : ScriptableObject
{
    [SerializeField] private string id;

    [SerializeField] private int startingLevel;

    [SerializeField] private float startingValue;
    [SerializeField] private float valueScale;

    [SerializeField] private int startingUpgradeCost;
    [SerializeField] private int upgradeCostScale;

    [SerializeField] private GameObject[] objectPrefabs;

    public string Id { get => id; }

    public int StartingLevel { get => startingLevel; }

    public float StartingValue { get => startingValue; }
    public float ValueScale { get => valueScale; }

    public int StartingUpgradeCost { get => startingUpgradeCost; }
    public int UpgradeCostScale { get => upgradeCostScale; }
    
    public GameObject[] ObjectPrefabs { get => objectPrefabs; }
}