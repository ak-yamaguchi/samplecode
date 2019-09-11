using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeButtons : MonoBehaviour
{
   public void OnToTitle()
    {
        FadeManager.Fade(Constant.Scene.Title);
    }

    public void OnToGameMain()
    {
        FadeManager.Fade(Constant.Scene.GameMain);
    }

    public void OnToBook()
    {
        FadeManager.Fade(Constant.Scene.Book);
    }

    public void OnToSrot()
    {
        FadeManager.Fade(Constant.Scene.Srot);
    }
}
