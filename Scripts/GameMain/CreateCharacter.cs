using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour
{
    string burgerId;

    BurgerData burgerData;

    List<int> foodId;

    [SerializeField]
    Transform setPosition;

    [SerializeField]
    ForceController forceController;

    [SerializeField]
    Text weightText;

    [SerializeField]
    Text windText;

    int weight;

    int wind;

    [SerializeField]
    private Transform moveEndPosition;

    void Start()
    {
        burgerId = ManagementId.GetburgerId; //マネージャーからID受け取り

        //burgerId = "burger0";

        burgerData = BurgerData.GetData(burgerId);

        foodId = burgerData.foodPartsId;

        SetCharacter();
    }

    public void SetCharacter()
    {
        var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.GameMainPrefabs + "Character"));
        obj.GetComponent<CharacterAnim>().SetPartsId("parts" + foodId[GameMainManager.achievementCount]); //ゲームの進行度でパーツを変える
        obj.transform.position = setPosition.position;
        obj.GetComponent<CharacterAnim>().SetMoveEndPosition(moveEndPosition);

        //重さ
        FoodPartsData foodData = FoodPartsData.GetData("parts" + foodId[GameMainManager.achievementCount]);
        weightText.text = foodData.weight.ToString();

        //風
        wind = Random.Range(0, burgerData.windLevel + 1);
        forceController.SetWindPower = wind;
        windText.text = wind.ToString();

        forceController.Setcharacter(obj);
    }
}
