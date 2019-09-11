using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SrotScroll : MonoBehaviour
{
	[SerializeField]
	private GameObject srotImages;

	Vector3 inisialPosition;

    [SerializeField]
    int frameCount;  //１枚の画像がどのくらい動いているかのh管理

    bool isStop; //停止ボタンが押されたら

    private int srotStatus;

    [SerializeField]
    int scrollCount;  //case2でのカウント

    int scrollEndCount; //case3でmのカウント

    [SerializeField]
    private int id;

    public int SrotStatus
    {
        get { return srotStatus; }
        set { srotStatus = value; }
    }

    [SerializeField]
    private GameObject goalPanel;

    [SerializeField]
    private Image goalBurgerImage;

    [SerializeField]
    private Text goalBurgerText;

    // Start is called before the first frame update
    void Start()
	{
		//srotImages.transform.localPosition = new Vector3(0, 210 * 2, 0);
		inisialPosition = srotImages.transform.localPosition;
        frameCount = 0;
        isStop = false;
        srotStatus = 0;
        scrollCount = 0;
        scrollEndCount = 0;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        switch(srotStatus)
        {
            case 1:
                srotImages.transform.localPosition -= new Vector3(0, Constant.Srot.ScrollSpeed_1, 0);

                frameCount++;

                if (srotImages.transform.localPosition.y < 0)
                {
                    srotImages.transform.localPosition = inisialPosition - new Vector3(0, Constant.Srot.ScrollSpeed_1, 0);
                }

                if (frameCount == Constant.Srot.SpriteHeight / Constant.Srot.ScrollSpeed_1) //画像縦幅 / 画像の１Frameの移動距離
                {
                    frameCount = 0;
                }
                break;

            case 2:
                scrollCount++;

                if (scrollCount >= (21 * 3) + (21 - frameCount * Constant.Srot.ScrollSpeed_1 / 10)) //10の移動を画像３つ文とその手前でずれている文足してスクロール
                {
                    srotStatus = 3;
                }
                
                srotImages.transform.localPosition -= new Vector3(0, Constant.Srot.ScrollSpeed_2, 0);

                if (srotImages.transform.localPosition.y < 0)
                {
                    srotImages.transform.localPosition = inisialPosition - new Vector3(0, Constant.Srot.ScrollSpeed_2, 0);
                }
                break;

            case 3:
                scrollEndCount++;

                if (scrollEndCount <= 21 * 2 * 3) //5の移動を画像３つ分スクロール
                {
                    srotImages.transform.localPosition -= new Vector3(0, Constant.Srot.ScrollSpeed_3, 0);

                    if (srotImages.transform.localPosition.y < 0)
                    {
                        srotImages.transform.localPosition = inisialPosition - new Vector3(0, Constant.Srot.ScrollSpeed_3, 0);
                    }
                }
                else
                {
                    srotStatus = 4;
                }
                break;

            case 4:
                id = (int)srotImages.transform.localPosition.y / Constant.Srot.SpriteHeight;

                if(PlayerPrefs.GetInt(Key.Common.isClear) == 0)
                {
                    ManagementId.SetBurgerId(Constant.ScriptableName.BurgerData + 0); //必ずハンバーガー
                }
                else
                {
                    ManagementId.SetBurgerId(Constant.ScriptableName.BurgerData + id);
                }
               
                StartCoroutine(CreateWindow());
                srotStatus = 5;
                break;
        }
	}

    IEnumerator CreateWindow()
    {
        yield return new WaitForSeconds(1.0f);

        goalPanel.SetActive(true);

        BurgerData data = BurgerData.GetData(ManagementId.GetburgerId);

        goalBurgerImage.sprite = Resources.Load<Sprite>(Constant.Path.Resources.BurgerImage + data.id);

        goalBurgerText.text = data.burgerName;

        //Debug.Log(ManagementId.GetburgerId);
    }
}
