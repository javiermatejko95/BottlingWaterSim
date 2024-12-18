using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : UpgradeableItem
{
    [SerializeField] private WaterBottle bottleToInteract;

    [SerializeField] private Renderer renderer;

    [SerializeField] private Color unavailableColor;
    [SerializeField] private Color availableColor;

    private bool isRecharging;
    private float currentRechargeTime = 1f;

    protected override void Awake()
    {
        base.Awake();

        isRecharging = false;
    }

    private void Update()
    {
        if(isRecharging)
        {
            Recharge();
        }
    }

    public override void Interact()
    {
        base.Interact();

        if(isRecharging)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }        
    }

    private void Recharge()
    {
        currentRechargeTime += objectData.CurrentValue * Time.deltaTime;

        float t = Mathf.Clamp01(currentRechargeTime / 1f);

        Color newColor = Color.Lerp(unavailableColor, availableColor, t);
        newColor.a = t;

        renderer.material.color = newColor;

        if (currentRechargeTime >= 1f)
        {
            isRecharging = false;

            Debug.Log("Water bottle available");
        }
    }

    protected override void Use()
    {
        if(bottleToInteract.GetStatus() != BOTTLE_STATUS.NONE)
        {
            return;
        }

        currentRechargeTime = 0f;
        isRecharging = true;

        bottleToInteract.Grab();
    }
}
