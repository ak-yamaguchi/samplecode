using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalCollisionTrigger : MonoBehaviour
{
    [SerializeField]
    Transform[] goalPosition;

    string burgerId;

    int partsNum; //パーツの個数

    [SerializeField]
    GameObject uiWaitCharacter;

    float delayTime; //次のパーつが出るまでの時間

    [SerializeField]
    private LifeController lifeController;

    private void Start()
    {
        burgerId = ManagementId.GetburgerId; //マネージャーからID受け取り

        BurgerData data = BurgerData.GetData(burgerId);

        partsNum = data.foodPartsId.Count;

        delayTime = Constant.GameMain.NextDelayTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == Constant.Tag.Character)
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            Destroy(collision.gameObject.GetComponent<CircleCollider2D>());

            collision.gameObject.transform.DOMove(goalPosition[GameMainManager.achievementCount].position + new Vector3(0, 0, -GameMainManager.achievementCount), delayTime);
            collision.gameObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), delayTime);
            collision.gameObject.transform.DORotate(Vector3.zero, delayTime);

            lifeController.InitLife();

            GameMainManager.achievementCount++;

            var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.GameMainPrefabs + "SuccessCanvas"));
            Destroy(obj.gameObject, Constant.GameMain.NextDelayTime);

            if (GameMainManager.achievementCount < partsNum)
            {
                GameMainManager.isCharacterCreate = true;
                Destroy(uiWaitCharacter.transform.GetChild(0).gameObject, delayTime); //一番左の待機パーツを削除
            }
            if (GameMainManager.achievementCount == partsNum)
            {
                GameMainManager.isCharacterCreate = true;
                GameMainManager.isGameSet = true;
            }
        }
    }
}
