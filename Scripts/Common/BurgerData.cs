using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class BurgerData : ScriptableObject
{
    [Tooltip("ハンバーガーの名前")]
    public string burgerName;
    [Tooltip("ID")]
    public string id;
    [Tooltip("難易度")]
    public int difficulty;
    [Tooltip("風の強さ")]
    public int windLevel;
    [Tooltip("獲得コイン数")]
    public int getCoinNum;
    [Tooltip("食材のIDリスト")]
    public List<int> foodPartsId;
   [Tooltip("バーガーの説明")]
   public string burgerExplanaiton;


   /// <summary>
   /// IDからハンバーガーデータをロード.
   /// </summary>
   public static BurgerData GetData( string id )
    {
        BurgerData ret = Resources.Load<BurgerData>("BurgerData/" + id);
        if(ret == null)
        {
            Debug.LogError("データのロードに失敗 id:"+ id);
        }
        return ret;
    }
}

//public class FoodPartsData
//{
//    public int id;
//    public int name;
//    public int weight;
//}
