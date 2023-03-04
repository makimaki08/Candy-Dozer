using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject candyPrefab; // Chandyプレファブ宣言
    public float shotForce;
    public float shotTorque;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot(); // 入力の検知
    }

    void Shot()
    {
        // プレファブからCandyオブジェクトを生成
        GameObject candy = Instantiate(
            candyPrefab,
            transform.position,
            Quaternion.identity
            );
        // CandyオブジェクトのRigidbodyを取得し、力と回転を加える
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce); // フォースの加算
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0)); // トルクの加算
    }
}
