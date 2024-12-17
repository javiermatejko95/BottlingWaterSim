using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    public event Action<bool> OnChangeCursorState;

    private void Awake()
    {
        //TODO: remove when settings are implemented
        Application.targetFrameRate = 144;
    }

    public void SetCursorStatus(CursorLockMode status)
    {
        Cursor.lockState = status;

        if(status == CursorLockMode.Locked)
        {
            OnChangeCursorState?.Invoke(true);
        }

        if(status == CursorLockMode.None)
        {
            OnChangeCursorState?.Invoke(false);
        }
    }
}
