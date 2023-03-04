using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestoryer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            // オブジェクトを削除
            Destroy(other.gameObject);
        }        
    }
}