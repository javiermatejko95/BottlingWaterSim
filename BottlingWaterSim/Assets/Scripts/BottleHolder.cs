using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleHolder : MonoBehaviour, IInteractable
{
    [SerializeField] private WaterBottle bottleToInteract;

    [SerializeField] private GameObject[] bottles;

    private int currentIndex;

    private void Awake()
    {
        currentIndex = 0;
    }

    public void Interact()
    {
        if(currentIndex >= bottles.Length)
        {
            return;
        }

        bottleToInteract.Drop();

        bottles[currentIndex].gameObject.SetActive(true);

        currentIndex++;
    }
}
