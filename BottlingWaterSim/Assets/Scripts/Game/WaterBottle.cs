using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBottle : MonoBehaviour
{
    [SerializeField] private GameObject bottleCap;

    [SerializeField] private BOTTLE_STATUS status = default;

    [SerializeField] private Renderer renderer;

    [SerializeField] private Color emptyColor;
    [SerializeField] private Color fullColor;

    [SerializeField] private Image imgLoadingWheel;

    private float currentFullness = 0f;

    private void Awake()
    {
        imgLoadingWheel.fillAmount = 0f;
    }

    public void Grab()
    {
        if (status != BOTTLE_STATUS.NONE)
        {
            return;
        }

        gameObject.SetActive(true);

        status = BOTTLE_STATUS.EMPTY;

        Debug.Log("Grabbed a new bottle");
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

        imgLoadingWheel.fillAmount = t;

        if (currentFullness >= 1f)
        {
            status = BOTTLE_STATUS.FULL;

            imgLoadingWheel.fillAmount = 0;

            Debug.Log("Filled the bottle");
        }        
    }

    public void StopFilling()
    {
        imgLoadingWheel.fillAmount = 0;
    }

    public void Drop()
    {
        if (status != BOTTLE_STATUS.FULL)
        {
            return;
        }

        gameObject.SetActive(false);

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