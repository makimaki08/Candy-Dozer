using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestoryer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            // 指定数だけCandyのストックを増やす
            candyManager.AddCandy(reward);

            // オブジェクトを削除
            Destroy(other.gameObject);
        }        
    }
}
