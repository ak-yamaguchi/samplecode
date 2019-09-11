using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainManager : MonoBehaviour
{
    public static int achievementCount; //パーツの達成回数

    public static bool isCharacterCreate;

    public static bool isGameSet; //ライフが０

    float createCount;

    float createTime;

    [SerializeField]
    CreateCharacter createCharacter;

    private LifeController lifeController;

    [SerializeField]
    private GameObject curtainCanvas;

    float sceneChangeCount;

    float sceneChangeTime = 3.0f;

    bool isSuccess;

    bool isFailure;

    private void Awake()
    {
        achievementCount = 0;
        isCharacterCreate = false;
        createCount = 0;
        isGameSet = false;
        lifeController = GetComponent<LifeController>();
        createTime = Constant.GameMain.NextDelayTime;
        gameObject.GetComponent<ObjectActiveController>().OnGaugeActive();
        sceneChangeCount = 0;
        isSuccess = false;
        isFailure = false;
    }

    private void FixedUpdate()
    {
        if (!isGameSet) 
        {
            if (isCharacterCreate)
            {
                createCount += Time.fixedDeltaTime;

                if (createCount >= createTime)
                {
                    createCharacter.SetCharacter();
                    gameObject.GetComponent<ObjectActiveController>().OnGaugeActive();

                    createCount = 0;
                    isCharacterCreate = false;
                }
            }
        }
        else
        {
            if (isCharacterCreate)
            {
                if (lifeController.Life <= 0)
                {
                    createCount += Time.fixedDeltaTime;

                    if (createCount >= createTime)
                    {
                        Debug.Log("gameover");
                        isFailure = true;
                        createCount = 0;
                        isCharacterCreate = false;
                        curtainCanvas.SetActive(true);
                    }
                }
                else
                {
                    createCount += Time.fixedDeltaTime;

                    if (createCount >= createTime)
                    {
                        Debug.Log("gameclear");
                        isSuccess = true;
                        createCount = 0;
                        isCharacterCreate = false;
                        curtainCanvas.SetActive(true);
                    }
                }
            }
        }

        if(isSuccess || isFailure)
        {
            sceneChangeCount += Time.fixedDeltaTime;

            if(sceneChangeCount >= sceneChangeTime)
            {
                if(isSuccess)
                {
                    SceneManager.LoadScene(Constant.Scene.ResultSuccess);
                }
                if(isFailure)
                {
                    SceneManager.LoadScene(Constant.Scene.ResultFailure);
                }
            }
        }
    }
}
