using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainController : BaseController
{
    [SerializeField]
    private Camera mainCamera;

    private void Start()
    {
        SetScreen();
    }

    void SetScreen()
    {
#if UNITY_EDITOR
        Debug.Log("Unity Editor");

        if (ScreenUtil.isVertically(Screen.width, Screen.height))
        {
            mainCamera.orthographicSize = 4.3f;
        }

        if (SystemInfo.deviceModel.Contains("iPad"))
        {
            mainCamera.orthographicSize = 6.4f;
        }

#elif UNITY_IOS
    Debug.Log("Unity iPhone");

        if (ScreenUtil.isVertically(Screen.width, Screen.height))
        {
            mainCamera.orthographicSize = 4.3f;
        }

        if(SystemInfo.deviceModel.Contains("iPad"))
        {
            mainCamera.orthographicSize = 6.4f;
        }
#else
    Debug.Log("Any other platform");
#endif
    }
}
