using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System;

public class BottleHolder : MonoBehaviour, IInteractable
{
    [SerializeField] private WaterBottle bottleToInteract;

    [SerializeField] private GameObject[] bottles;

    private int currentIndex;

    private Action onDropBottle;

    private void Awake()
    {
        currentIndex = 0;
    }

    public void Interact()
    {
        if(!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        if(currentIndex >= bottles.Length || !bottleToInteract.IsActive() || bottleToInteract.GetStatus() != BOTTLE_STATUS.FULL)
        {
            return;
        }

        bottleToInteract.Drop();

        bottles[currentIndex].gameObject.SetActive(true);

        currentIndex++;

        onDropBottle?.Invoke();
    }

    public bool HasActiveBottle()
    {
        return bottles.Any(b => b.activeSelf);
    }

    public void SuscribeToAction(Action onAction)
    {
        onDropBottle += onAction;
    }

    public void UnsuscribeToAction(Action onAction)
    {
        onDropBottle -= onAction;
    }

    public void GrabBottle()
    {
        currentIndex--;

        bottles[currentIndex].gameObject.SetActive(false);        
    }
}
