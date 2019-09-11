using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResuleSuccessController : BaseController
{
    string burgerId;

    [SerializeField]
    private GameObject newIcon;

    private void Start()
    {
        burgerId = ManagementId.GetburgerId; //マネージャーからID受け取り

        BurgerData data = BurgerData.GetData(burgerId);

        if(PlayerPrefs.GetInt("isGetBurger" + data.id) == 0)
        {
            newIcon.SetActive(true);
        }

        PlayerPrefs.SetInt("isGetBurger" + data.id, 1);

        var totalCoin = PlayerPrefs.GetInt(Key.Common.TotalCoin);

        PlayerPrefs.SetInt(Key.Common.TotalCoin, totalCoin + data.getCoinNum);
    }
}
