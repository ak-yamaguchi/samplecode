using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtil
{
    public static bool isVertically(float width, float height)
    {
        if ((float)(width / height) >= 2.0)
        {
            Debug.Log("iPhoneX系？");
            return true;
        }
        else
        {
            return false;
        }
    }
}
