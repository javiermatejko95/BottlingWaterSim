using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    [SerializeField] private GameObject bottleCapEmpty;
    //[SerializeField] private GameObject bottleCapFull;

    [SerializeField] private BOTTLE_STATUS status = default;

    [SerializeField] private Renderer renderer;

    [SerializeField] private Color emptyColor;
    [SerializeField] private Color fullColor;

    private float currentFullness = 0f;

    public void Grab()
    {
        if (status != BOTTLE_STATUS.NONE)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(true);

            //bottleCapEmpty.SetActive(true);
            //bottleCapFull.SetActive(false);

            status = BOTTLE_STATUS.EMPTY;

            Debug.Log("Grabbed a new bottle");
        }        
    }

    public void Fill(float add)
    {
        if(status == BOTTLE_STATUS.NONE || status == BOTTLE_STATUS.FULL)
        {
            return;
        }

        currentFullness += add;

        float t = Mathf.Clamp01(currentFullness / 1f);

        renderer.material.color = Color.Lerp(emptyColor, fullColor, t);

        if (currentFullness >= 1f)
        {
            //bottleCapEmpty.SetActive(false);
            //bottleCapFull.SetActive(true);

            status = BOTTLE_STATUS.FULL;

            Debug.Log("Filled the bottle");
        }        
    }    

    public void Drop()
    {
        if (status != BOTTLE_STATUS.FULL)
        {
            return;
        }

        gameObject.SetActive(false);
        //bottleCapEmpty.SetActive(true);
        //bottleCapFull.SetActive(false);

        status = BOTTLE_STATUS.NONE;
        currentFullness = 0f;
        renderer.material.color = emptyColor;
        Debug.Log("Dropped the bottle");
    }

    public bool IsActive()
    {
        return gameObject.activeSelf == this;
    }

    public BOTTLE_STATUS GetStatus()
    {
        return status;
    }
}

public enum BOTTLE_STATUS
{
    NONE,
    EMPTY,
    FULL
}