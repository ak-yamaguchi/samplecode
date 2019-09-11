using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField]
    LifeController lifeController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Constant.Tag.Character)
        {
            Debug.Log("attata");

            GameMainManager.isCharacterCreate = true;

            Destroy(collision.gameObject);

            lifeController.MinusLife();

            var obj = Instantiate(Resources.Load<GameObject>(Constant.Path.Resources.GameMainPrefabs + "FailureCanvas"));
            Destroy(obj.gameObject, Constant.GameMain.NextDelayTime);
        }
    }
}
