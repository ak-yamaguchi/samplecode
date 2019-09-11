using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateCharacterImage : MonoBehaviour
{
    [SerializeField]
    private Image characterImage;

    private string foodpartsId;

    public void SetFoodPartsId(string id)
    {
        foodpartsId = id;
    }

    private void Start()
    {
        FoodPartsData data = FoodPartsData.GetData(foodpartsId);

        characterImage.sprite = data.idolSprite_1;
    }
}
