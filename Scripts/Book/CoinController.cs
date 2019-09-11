using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    private Text coinText;

    public void SetCoinText(string coin)
    {
        coinText.text = coin;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = PlayerPrefs.GetInt(Key.Common.TotalCoin).ToString();
    }
}
