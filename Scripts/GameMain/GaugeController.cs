using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField]
    private Image gaugeImage;

    bool isPower;

    float delayCount; //ゲージがたまりきってからのカウント

    [SerializeField]
    float delayTime = 0.5f; //ディレイをかける秒数

    [SerializeField]
    private float gaugePower;

    // Start is called before the first frame update
    void Start()
    {
        InitGauge();
    }

    private void FixedUpdate()
    {
        if(isPower)
        {
            gaugeImage.fillAmount += Time.fixedDeltaTime;

            if (gaugeImage.fillAmount >= 1f)
            {
                delayCount += Time.fixedDeltaTime;
            }
            if (delayCount >= delayTime)
            {
                gaugeImage.fillAmount = 0f;
                delayCount = 0f;
            }
        }
    }

    public void InitGauge()
    {
        isPower = false;
        delayCount = 0;
        gaugeImage.fillAmount = 0;
    }

    public void OnPushPowerButton()
    {
        isPower = true;
    }

    public void OnUpPowerButton()
    {
        isPower = false;
        gaugePower = gaugeImage.fillAmount;
        this.gameObject.GetComponent<ForceController>().SetGaugePower = gaugeImage.fillAmount;
    }
}
