using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestoryer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;
    public GameObject effectPrefab; // エフェクトプレハブプロパティ
    public Vector3 effectRotation; // エフェクトローテーションプロパティ

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            // 指定数だけCandyのストックを増やす
            candyManager.AddCandy(reward);

            // オブジェクトを削除
            Destroy(other.gameObject);

            // エフェクトプレハブの設定チェック
            if (effectPrefab != null)
            {
                // Candyのポジションにエフェクト生成
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation));
            }
        }        
    }
}
