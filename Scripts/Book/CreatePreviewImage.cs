using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePreviewImage : MonoBehaviour
{
    [SerializeField]
    private Image[] prevImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetImage());
    }

    IEnumerator SetImage()
    {
        for(int i = 0; i < prevImage.Length; i++)
        {
            if(PlayerPrefs.GetInt("isGetBurger" + i) != 0)
            {
                prevImage[i].sprite = Resources.Load<Sprite>(Constant.Path.Resources.BurgerImage + i);
            }
            else
            {
                prevImage[i].sprite = Resources.Load<Sprite>(Constant.Path.Resources.Silhouette + i);
            }
        }

        yield return 0;
    }
}
