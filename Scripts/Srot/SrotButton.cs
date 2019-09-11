using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrotButton : MonoBehaviour
{
    [SerializeField]
    private Animator buttonAnim;

    [SerializeField]
    private Animator srotbar;

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    string Direction;

    public void OnActiveStopButton()
    {
        buttonAnim.SetBool(Constant.Animation.Srot.SrotButton, true);
    }

    public void OnUnActiveStopButton()
    {
        buttonAnim.SetBool(Constant.Animation.Srot.SrotButton, false);
    }

    public void OnStopSrot()
    {
        var srotScroll = this.gameObject.GetComponent<SrotScroll>();
        if(srotScroll.SrotStatus == 1)
        {
            srotScroll.SrotStatus = 2;
        }
    }

    public void OnSrotBarMove()
    {
        srotbar.SetTrigger(Constant.Animation.Srot.SrotBar);
    }

    private void FixedUpdate()
    {
        Flick();
    }

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            GetDirection();
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                Direction = "down";
            }
        }
        else
        {
            //タッチを検出
            Direction = "touch";
        }

        switch (Direction)
        {
            case "down":
                OnSrotBarMove();
                Invoke("StartSrot", 0.5f);
                break;
        }
    }

    void StartSrot()
    {
        var srotScroll = this.gameObject.GetComponent<SrotScroll>();
        srotScroll.SrotStatus = 1;
        OnActiveStopButton();
    }
}
