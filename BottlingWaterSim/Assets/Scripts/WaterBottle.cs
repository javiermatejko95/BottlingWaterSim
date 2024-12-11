using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    [SerializeField] private GameObject bottleCapEmpty;
    [SerializeField] private GameObject bottleCapFull;

    [SerializeField] private BOTTLE_STATUS status = default;

    public void Grab()
    {
        if (status != BOTTLE_STATUS.NONE)
        {
            return;
        }

        gameObject.SetActive(true);

        bottleCapEmpty.SetActive(true);
        bottleCapFull.SetActive(false);
        
        status = BOTTLE_STATUS.EMPTY;

        Debug.Log("Grabbed a new bottle");
    }

    public void Fill()
    {
        if(status == BOTTLE_STATUS.NONE || status == BOTTLE_STATUS.FULL)
        {
            return;
        }

        bottleCapEmpty.SetActive(false);
        bottleCapFull.SetActive(true);

        status = BOTTLE_STATUS.FULL;

        Debug.Log("Filled the bottle");
    }    

    public void Drop()
    {
        if (status != BOTTLE_STATUS.FULL)
        {
            return;
        }

        gameObject.SetActive(false);
        bottleCapEmpty.SetActive(true);
        bottleCapFull.SetActive(false);

        status = BOTTLE_STATUS.NONE;

        Debug.Log("Dropped the bottle");
    }

    public bool IsActive()
    {
        return gameObject.activeSelf == this;
    }
}

public enum BOTTLE_STATUS
{
    NONE,
    EMPTY,
    FULL
}