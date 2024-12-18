using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private Button btnBuy;
    [SerializeField] private TextMeshProUGUI txtLevelCost;

    private string id;
    private int cost;

    private void Awake()
    {
        btnBuy.onClick.AddListener(BuyUpgrade);
    }

    public void Setup(ObjectData objectData)
    {
        id = objectData.Id;
        cost = objectData.UpgradeCost;

        UpdateTexts(objectData);
    }

    private void BuyUpgrade()
    {
        ShopManager.Instance.BuyUpgrade(UpgradeSystemManager.Instance.GetObjectData(id), UpdateTexts);
    }

    private void UpdateTexts(ObjectData objectData)
    {
        txtName.text = objectData.Id;

        txtLevelCost.text = $"Level {objectData.CurrentLevel} - $ {objectData.UpgradeCost}";
    }
}
