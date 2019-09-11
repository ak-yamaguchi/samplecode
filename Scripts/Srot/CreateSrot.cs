using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSrot : MonoBehaviour
{
    [SerializeField]
    private GameObject itemContent;

    int[] clearBurgerNum = {1, 10, 16, 20, 23};

    void Start()
    {
        StartCoroutine(CreateSrotItem(PlayerPrefs.GetInt(Key.Common.isClear)));
    }

    private IEnumerator CreateSrotItem(int isClear)
    {
        switch(isClear)
        {
            case 0:
                for(int i = 0; i < clearBurgerNum[isClear] * 3; i++) //見た目ように３つ生成
                {
                    var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                    obj.transform.SetParent(itemContent.transform);
                    obj.transform.localScale = Vector3.one;
                    obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + "0");
                }

                itemContent.transform.localPosition = new Vector3(0, Constant.Srot.SpriteHeight * 2, 0);

                break;

            case 1:
                for (int i = 0; i < clearBurgerNum[isClear] + 1; i++) //見た目ように３つ生成
                {
                    if(i == clearBurgerNum[isClear]) //最後にも最初の画像を配置しループを違和感なく
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + 0);
                    }
                    else
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + i);
                    }
                }

                itemContent.transform.localPosition = new Vector3(0, Constant.Srot.SpriteHeight * clearBurgerNum[isClear], 0);

                break;

            case 2:
                for (int i = 0; i < clearBurgerNum[isClear] + 1; i++) //見た目ように３つ生成
                {
                    if (i == clearBurgerNum[isClear]) //最後にも最初の画像を配置しループを違和感なく
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + 0);
                    }
                    else
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + i);
                    }
                }

                itemContent.transform.localPosition = new Vector3(0, Constant.Srot.SpriteHeight * clearBurgerNum[isClear], 0);

                break;

            case 3:
                for (int i = 0; i < clearBurgerNum[isClear] + 1; i++) //見た目ように３つ生成
                {
                    if (i == clearBurgerNum[isClear]) //最後にも最初の画像を配置しループを違和感なく
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + 0);
                    }
                    else
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + i);
                    }
                }

                itemContent.transform.localPosition = new Vector3(0, Constant.Srot.SpriteHeight * clearBurgerNum[isClear], 0);
                break;

            case 4:
                for (int i = 0; i < clearBurgerNum[isClear] + 1; i++) //見た目ように３つ生成
                {
                    if (i == clearBurgerNum[isClear]) //最後にも最初の画像を配置しループを違和感なく
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + 0);
                    }
                    else
                    {
                        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.SrotPrefabs + "SrotItem"));
                        obj.transform.SetParent(itemContent.transform);
                        obj.transform.localScale = Vector3.one;
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + i);
                    }
                }

                itemContent.transform.localPosition = new Vector3(0, Constant.Srot.SpriteHeight * clearBurgerNum[isClear], 0);
                break;
        }

        yield return 0;
    }
}
