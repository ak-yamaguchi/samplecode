using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialContents;

    [SerializeField]
    private Transform[] tutorialImage;

    [SerializeField]
    private GameObject[] moveButton;

    float scrollTime = 1.0f;

    [SerializeField]
    private GameObject closeButton;

    public void OnRight()
    {
        OnMove();
        StartCoroutine(ActiveLeftButton());
    }

    public void OnLeft()
    {
        OnMove();
        StartCoroutine(ActiveRightButton());
    }


    void OnMove()
    {
        tutorialContents.transform.DOMoveX(-tutorialImage[1].position.x, scrollTime);
    }

    IEnumerator ActiveRightButton()
    {
        yield return new WaitForSeconds(scrollTime);
        moveButton[0].SetActive(true);
    }

    IEnumerator ActiveLeftButton()
    {
        yield return new WaitForSeconds(scrollTime);
        moveButton[1].SetActive(true);
        closeButton.SetActive(true);
    }
}
