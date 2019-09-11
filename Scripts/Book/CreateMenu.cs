using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMenu : MonoBehaviour
{
    [SerializeField]
    private string burgerId;

    [SerializeField]
    private GameObject menuWindow;

    [SerializeField]
    private Image burgerImage;

    [SerializeField]
    private Image levelImage;

    [SerializeField]
    private Image nameImage;

    [SerializeField]
    private Image bookImage;

    [SerializeField]
    private Image memoImage;

    [SerializeField]
    private Text coinText;

    public void OnReceiveBurgerId(Button button)
    {
        burgerId = button.GetComponent<SetBurgerId>().GetBurgerId();

        CreateMenuWindow(burgerId);
    }

    void CreateMenuWindow(string id)
    {
        BurgerData data = BurgerData.GetData(id);

        var num = data.id;

        if (PlayerPrefs.GetInt("isGetBurger" + num) != 0)
        {
            burgerImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.BurgerImage + num);

            levelImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.LevelImage + data.difficulty);

            nameImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.BookBurgerName + num);

            bookImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.BookImage + num);

            memoImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.ExplanationImage + num);

            coinText.text = data.getCoinNum.ToString();

            menuWindow.SetActive(true);
        }
    }
}
