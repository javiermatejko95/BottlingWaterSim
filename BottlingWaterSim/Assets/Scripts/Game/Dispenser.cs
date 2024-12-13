using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour, IInteractable
{
    [SerializeField] private WaterBottle bottleToInteract;

    public void Interact()
    {
        bottleToInteract.Grab();
    }
}
