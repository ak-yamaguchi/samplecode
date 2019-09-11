using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterAnim : MonoBehaviour
{
    [SerializeField]
    private string foodPartsId;

    public string GetPartsId()
    {
        return foodPartsId;
    }

    public void SetPartsId(string id)
    {
        foodPartsId = id;
    }

    SpriteRenderer character;

    [SerializeField]
    Sprite idol_1;

    [SerializeField]
    Sprite idol_2;

    [SerializeField]
    Sprite charge;

    [SerializeField]
    Sprite fly;

    private int charaStatus;

    [SerializeField]
    private Transform moveEndPosition;

    public void SetMoveEndPosition(Transform pos)
    {
        moveEndPosition = pos;
    }

    public int CharaStatus
    {
        get { return charaStatus; }
        set { charaStatus = value; }
    }

    float idolCount;

    private void Start()
    {
        //foodPartsId = "parts8"; //仮設定

        FoodPartsData data = FoodPartsData.GetData(foodPartsId);

        idol_1 = data.idolSprite_1;
        idol_2 = data.idolSprite_2;
        charge = data.chargeSprite;
        fly = data.flySprite;

        character = GetComponent<SpriteRenderer>();

        character.sprite = idol_1;

        charaStatus = 2;
        idolCount = 0;

        transform.DOMove(moveEndPosition.position, 1.0f);
        Invoke("ChangeIdolStand", 1.0f);
    }

    private void FixedUpdate()
    {
        switch(charaStatus)
        {
            case 0:
                if(idolCount <= 1f)
                {
                    idolCount += Time.fixedDeltaTime;
                }
                else
                {
                    idolCount = 0;
                }

                if(idolCount <= 0.5f)
                {
                    character.sprite = idol_1;
                }
                else
                {
                    character.sprite = idol_2;
                }
                break;

            case 1:
                character.sprite = charge;
                break;

            case 2:
                character.sprite = fly;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        charaStatus = 0;
    }

    void ChangeIdolStand()
    {
        charaStatus = 0;
    }
}
