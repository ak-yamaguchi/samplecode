using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu]
public class FoodPartsData : ScriptableObject
{
    [Tooltip("食材の名前" )]
    public string partsName;
    [Tooltip("食材のID")]
    public string id;
    [Tooltip("食材の重さ" )]
    public int weight;
    [Tooltip("食材の画像")]
    public Sprite idolSprite_1;
    [Tooltip("アイドリング画像")]
    public Sprite idolSprite_2;
    [Tooltip("溜める画像")]
    public Sprite chargeSprite;
    [Tooltip("飛ぶ画像")]
    public Sprite flySprite;
   

    public static FoodPartsData GetData(string id)
    {
        FoodPartsData ret = Resources.Load<FoodPartsData>("FoodPartsData/" + id);
        if( ret == null )
        {
            Debug.LogError( "データのロードに失敗 id:" + id );
        }
        return ret;
    }
}
