using UnityEngine;

public class Tap : UpgradeableItem
{
    [SerializeField] private WaterBottle bottleToInteract;

    public override void Interact()
    {
        base.Interact();

        if (Input.GetKey(KeyCode.E))
        {
            Use();
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            bottleToInteract.StopFilling();
        }
    }

    protected override void Use()
    {
        bottleToInteract.Fill(objectData.CurrentValue * Time.deltaTime);
    }    

}
