using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    [SerializeField]
    private GameObject pageContent;

    [SerializeField]
    int pageCount;

    [SerializeField]
    private GameObject rightButton;

    [SerializeField]
    private GameObject leftButton;

    float scrollTime = 1.0f;

    [SerializeField]
    private Button rightButtonInterract;

    [SerializeField]
    private Button leftButtonInterract;

    // Start is called before the first frame update
    void Start()
    {
        pageCount = 0;
        ButtonActive();
    }

    public void OnRightButton()
    {
        pageCount++;

        pageContent.transform.DOLocalMove(new Vector3(pageContent.transform.localPosition.x - 1334, pageContent.transform.localPosition.y, pageContent.transform.localPosition.z), scrollTime);

        ButtonActive();

        StartCoroutine(ButtonEnable());
    }

    public void OnLeftButton()
    {
        pageCount--;

        pageContent.transform.DOLocalMove(new Vector3(pageContent.transform.localPosition.x + 1334, pageContent.transform.localPosition.y, pageContent.transform.localPosition.z), scrollTime);

        ButtonActive();

        StartCoroutine(ButtonEnable());
    }

    void ButtonActive()
    {
        switch(pageCount)
        {
            case 0:
                rightButton.SetActive(true);
                leftButton.SetActive(false);
                break;

            case 1:
                rightButton.SetActive(true);
                leftButton.SetActive(true);
                break;

            case 3:
                rightButton.SetActive(true);
                leftButton.SetActive(true);
                break;

            case 4:
                rightButton.SetActive(false);
                leftButton.SetActive(true);
                break;
        }
    }

    //スクロール中はボタンを押せないように
    IEnumerator ButtonEnable()
    {
        rightButtonInterract.interactable = false;
        leftButtonInterract.interactable = false;

        yield return new WaitForSeconds(scrollTime);

        rightButtonInterract.interactable = true;
        leftButtonInterract.interactable = true;
    }
}
