using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBurgerId : MonoBehaviour
{
    [SerializeField]
    private string burgerId;

    public string GetBurgerId()
    {
        return burgerId;
    }
}
