using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorController : MonoBehaviour
{
    [SerializeField]
    private GameObject vectorImage;

    bool isUpMove;

    [SerializeField]
    private float vectorPower;

    // Start is called before the first frame update
    void Start()
    {
        isUpMove = true;
    }

    private void FixedUpdate()
    {
        if(isUpMove)
        {
            vectorImage.transform.Rotate(0, 0, 1f);

            if(vectorImage.transform.localEulerAngles.z >= 89)
            {
                isUpMove = false;
            }
        }
        else
        {
            vectorImage.transform.Rotate(0, 0, -1f);

            if (vectorImage.transform.localEulerAngles.z <= 1)
            {
                isUpMove = true;
            }
        }
    }

    void InitVector()
    {

    }

    public void OnDecideVector()
    {
        vectorPower = vectorImage.transform.localEulerAngles.z;
        this.gameObject.GetComponent<ForceController>().SetVectorPower = vectorImage.transform.localEulerAngles.z;
    }
}
