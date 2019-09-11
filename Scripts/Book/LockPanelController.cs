using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogPanel;

    [SerializeField]
    private Text dialogText;

    [SerializeField]
    private GameObject[] lockPanel;

    int[] costCoin = {100, 300, 500, 1000 };

    [SerializeField]
    private CoinController coinController;

    // Start is called before the first frame update
    void Start()
    {
        var isClear = PlayerPrefs.GetInt(Key.Common.isClear);

        for(int i = 0; i < isClear; i++)
        {
            lockPanel[i].SetActive(false);
        }
    }

    public void OnLockPanel1()
    {
        if (PlayerPrefs.GetInt(Key.Common.TotalCoin) >= costCoin[0])
        {
            PlayerPrefs.SetInt(Key.Common.isClear, 1);
            PlayerPrefs.SetInt(Key.Common.TotalCoin, PlayerPrefs.GetInt(Key.Common.TotalCoin) - costCoin[0]);
            dialogText.text = "星2を解放しました！";
            lockPanel[0].SetActive(false);
        }
        else
        {
            dialogText.text = "※コインが足りません";
        }

        dialogPanel.SetActive(true);
        UpdateCoinText();
    }

    public void OnLockPanel2()
    {
        if (PlayerPrefs.GetInt(Key.Common.TotalCoin) >= costCoin[1])
        {
            if (PlayerPrefs.GetInt(Key.Common.isClear) == 1)
            {
                PlayerPrefs.SetInt(Key.Common.isClear, 2);
                PlayerPrefs.SetInt(Key.Common.TotalCoin, PlayerPrefs.GetInt(Key.Common.TotalCoin) - costCoin[1]);
                dialogText.text = "星3を解放しました！";
                lockPanel[1].SetActive(false);
            }
            else
            {
                dialogText.text = "※前の難易度を解放してください";
            }
        }
        else
        {
            dialogText.text = "※コインが足りません";
        }

        dialogPanel.SetActive(true);
        UpdateCoinText();
    }

    public void OnLockPanel3()
    {
        if (PlayerPrefs.GetInt(Key.Common.TotalCoin) >= costCoin[2])
        {
            if (PlayerPrefs.GetInt(Key.Common.isClear) == 2)
            {
                PlayerPrefs.SetInt(Key.Common.isClear, 3);
                PlayerPrefs.SetInt(Key.Common.TotalCoin, PlayerPrefs.GetInt(Key.Common.TotalCoin) - costCoin[2]);
                dialogText.text = "星4を解放しました！";
                lockPanel[2].SetActive(false);
            }
            else
            {
                dialogText.text = "※前の難易度を解放してください";
            }
        }
        else
        {
            dialogText.text = "※コインが足りません";
        }

        dialogPanel.SetActive(true);
        UpdateCoinText();
    }

    public void OnLockPanel4()
    {
        if (PlayerPrefs.GetInt(Key.Common.TotalCoin) >= costCoin[3])
        {
            if (PlayerPrefs.GetInt(Key.Common.isClear) == 3)
            {
                PlayerPrefs.SetInt(Key.Common.isClear, 4);
                PlayerPrefs.SetInt(Key.Common.TotalCoin, PlayerPrefs.GetInt(Key.Common.TotalCoin) - costCoin[3]);
                dialogText.text = "星5を解放しました！";
                lockPanel[3].SetActive(false);
            }
            else
            {
                dialogText.text = "※前の難易度を解放してください";
            }
        }
        else
        {
            dialogText.text = "※コインが足りません";
        }

        dialogPanel.SetActive(true);
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinController.SetCoinText(PlayerPrefs.GetInt(Key.Common.TotalCoin).ToString());
    }
}
