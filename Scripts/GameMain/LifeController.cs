using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private int life;

    [SerializeField]
    private Image[] lifeImage;

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    private void Start()
    {
        InitLife();
    }

    public void MinusLife()
    {
        lifeImage[life - 1].enabled = false;

        life--;

        if(life <= 0)
        {
            GameMainManager.isGameSet = true;
        }
    }

    public void InitLife()
    {
        life = 3;
        for (int i = 0; i < life; i++)
        {
            lifeImage[i].enabled = true;
        }
    }
}
