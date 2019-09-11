using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveController : MonoBehaviour
{
    [SerializeField]
    private GameObject gaugeObj;

    [SerializeField]
    private GameObject vectorObj;

    [SerializeField]
    private GameObject lifeObj;

    public void OnGaugeActive()
    {
        //Invoke("GaugeActive", 1.0f);
        gaugeObj.SetActive(true);
        vectorObj.SetActive(false);
        lifeObj.SetActive(true);
    }

    public void OnVectorActive()
    {
        gaugeObj.SetActive(false);
        vectorObj.SetActive(true);
        lifeObj.SetActive(true);
    }

    public void OnAllUnActive()
    {
        gaugeObj.SetActive(false);
        vectorObj.SetActive(false);
        lifeObj.SetActive(false);
    }

    void GaugeActive()
    {
        gaugeObj.SetActive(true);
        vectorObj.SetActive(false);
        lifeObj.SetActive(true);
    }
}
