using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : SingletonMonoBehaviour<FadeManager>
{
    [SerializeField]
    Image fadeImage;

    private static bool isFade;

    private static string sceneName;

    float fadeCount;

    bool isReturn;

    float fadeTime = 1.0f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        fadeImage.enabled = false;
        isFade = false;
        fadeCount = 0;
        isReturn = false;
        fadeImage.fillClockwise = false;
    }

    private void FixedUpdate()
    {
        if(isFade)
        {
            fadeImage.enabled = true;

            if(!isReturn)
            {
                fadeCount += Time.fixedDeltaTime;

                fadeImage.fillAmount = fadeCount;

                if(fadeCount >= fadeTime)
                {
                    isReturn = true;
                    fadeImage.fillClockwise = true;
                    SceneManager.LoadScene(sceneName);
                }
            }
            else
            {
                fadeCount -= Time.fixedDeltaTime;

                fadeImage.fillAmount = fadeCount;

                if(fadeCount <= 0)
                {
                    fadeImage.enabled = false;
                    isFade = false;
                    fadeCount = 0;
                    isReturn = false;
                    fadeImage.fillClockwise = false;
                }
            }
        }
    }

    public static void Fade(string name)
    {
        isFade = true;
        sceneName = name;
    }
}
