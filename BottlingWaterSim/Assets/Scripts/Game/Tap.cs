using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour, IInteractable
{
    [SerializeField] private WaterBottle bottleToInteract;
    [SerializeField] private float speedToFill = 0.1f;

    public void Interact()
    {
        if (!Input.GetKey(KeyCode.E))
        {
            return;
        }

        bottleToInteract.Fill(speedToFill * Time.deltaTime);                    
    }
}
