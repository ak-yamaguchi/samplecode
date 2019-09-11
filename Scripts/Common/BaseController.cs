using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected ManagementId managementId;

    protected FadeManager fadeManager;

    private void Awake()
    {
        if (GameObject.FindWithTag(Constant.Tag.ManagementIdController) == null)
        {
            managementId = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.CommonPrefabs + "ScriptableManager")).GetComponent<ManagementId>();
        }
        else
        {
            managementId = GameObject.FindWithTag(Constant.Tag.ManagementIdController).GetComponent<ManagementId>();
        }

        if (GameObject.FindWithTag(Constant.Tag.FadeCanvas) == null)
        {
            fadeManager = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.CommonPrefabs + "FadeCanvas")).GetComponent<FadeManager>();
        }
        else
        {
            fadeManager = GameObject.FindWithTag(Constant.Tag.FadeCanvas).GetComponent<FadeManager>();
        }
    }
}
