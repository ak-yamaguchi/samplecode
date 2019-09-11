using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCreateManager : MonoBehaviour
{
    string burgerId;

    [SerializeField]
    private Image resultBurgerImage;

    [SerializeField]
    private Image resultLevelImage;

    [SerializeField]
    private Image menuBurgerImage;

    [SerializeField]
    private Image menuNameImage;

    [SerializeField]
    private Text menuGetCoin;

    [SerializeField]
    private Text menuTotalCoin;

    // Start is called before the first frame update
    void Start()
    {
        burgerId = ManagementId.GetburgerId; //マネージャーからID受け取り

        CreateMenu(burgerId);
    }

    void CreateMenu(string id)
    {
        BurgerData data = BurgerData.GetData(id);

        var num = data.id;

        resultBurgerImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.BurgerImage + num);

        var level = data.difficulty;

        resultLevelImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.LevelImage + level);

        menuBurgerImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.BurgerImage + num);

        menuNameImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.ResuleBurgerName + num);

        var getCoin = data.getCoinNum;

        menuGetCoin.text = getCoin.ToString();

        menuTotalCoin.text = PlayerPrefs.GetInt(Key.Common.TotalCoin).ToString();
    }
}
