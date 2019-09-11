using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : BaseController
{
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt(Key.Common.TotalCoin));
        Debug.Log(PlayerPrefs.GetInt(Key.Common.isClear));
    }
}
