using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveCharacter : MonoBehaviour
{
    string burgerId;

    [SerializeField]
    private GameObject waitCharacterContent;

    // Start is called before the first frame update
    void Start()
    {
        burgerId = ManagementId.GetburgerId; //マネージャーからID受け取り

        //burgerId = "burger0";

        StartCoroutine(CreateCharacter());
    }


    IEnumerator CreateCharacter()
    {
        BurgerData data = BurgerData.GetData(burgerId);

        List<int> foods = data.foodPartsId;

        for(int i = 1; i < foods.Count; i++)
        {
            var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.GameMainPrefabs + "WaitCharacterFrame"));
            obj.GetComponent<GenerateCharacterImage>().SetFoodPartsId(Constant.ScriptableName.FoodPartsData + foods[i]);
            obj.transform.SetParent(waitCharacterContent.transform);
            obj.transform.localPosition = Vector3.one; //背面にいかないように
            obj.transform.localScale = Vector3.one;
        }

        yield return 0;
    }
}
