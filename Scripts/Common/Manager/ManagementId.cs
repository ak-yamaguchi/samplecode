using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementId : SingletonMonoBehaviour<ManagementId>
{
    [SerializeField]
    private static string burgerId;

    [SerializeField]
    string id;

    private void Awake()
    {
        //burgerId = "burger12";
        DontDestroyOnLoad(gameObject);
        Debug.Log(burgerId);
    }

    public static void SetBurgerId(string receiveId)
    {
        burgerId = receiveId;
    }

    public static string GetburgerId
    {
        get { return burgerId; }
    }
}
