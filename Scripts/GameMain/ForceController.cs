using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceController : MonoBehaviour
{
    [SerializeField]
    private float gaugePower;

    public float SetGaugePower
    {
        get { return gaugePower; }
        set { gaugePower = value; }
    }

    [SerializeField]
    private float vectorPower;

    public float SetVectorPower
    {
        get { return vectorPower; }
        set { vectorPower = value; }
    }

    [SerializeField]
    private GameObject character;

    public void Setcharacter(GameObject chara)
    {
        character = chara;
    }

    Rigidbody2D rb2;

    string burgerId;

    private int windPower;

    public int SetWindPower
    {
        set { windPower = value; }
    }

    private void Start()
    {
        burgerId = ManagementId.GetburgerId; //マネージャーからID受け取り

        //burgerId = "burger0"; // かり

        BurgerData burgerdata = BurgerData.GetData(burgerId);
    }

    public void OnAddForceCharacter()
    {
        FoodPartsData partsdata = FoodPartsData.GetData(character.GetComponent<CharacterAnim>().GetPartsId());

        rb2 = character.GetComponent<Rigidbody2D>();
        rb2.gravityScale = 0.7f;
        var vector = new Vector2(90 - vectorPower, vectorPower);
        var gauge = gaugePower * 8;
        var weight = -3 + partsdata.weight;
        var wind = windPower * 0.5f;
        var force = vector * (Constant.GameMain.DefaultPower + gauge - weight + wind);　//合計hが6が中央値
        rb2.AddForce(force);

        Debug.Log("weight = " + weight);
        Debug.Log("windpower = " + windPower);
    }

    public void OnCharacterChargeAnim()
    {
        character.GetComponent<CharacterAnim>().CharaStatus = 1;
    }

    public void OnCharacterFlyAnim()
    {
        character.GetComponent<CharacterAnim>().CharaStatus = 2;
    }

    public void OnInitGauge()
    {
        gaugePower = 0;
        gameObject.GetComponent<GaugeController>().InitGauge();
    }
}
