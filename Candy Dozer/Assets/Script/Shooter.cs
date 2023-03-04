using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs; // Chandyプレファブプロパティの配列化
    public Transform candyParentTransform;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot(); // 入力の検知
    }

    // キャンディのプレハブからランダムに1つ選ぶ
    GameObject SampleCandy()
    {
        int index = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        // 画面のサイズとInputの割合から、キャンディ生成のポジションを計算
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    public void Shot()
    {
        // キャンディを生成できる条件外ならば、Shotしない
        if (candyManager.GetCandyAmount() <= 0) return;

        // プレファブからCandyオブジェクトを生成
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            Quaternion.identity
            );

        // 生成したCandyオブジェクトの親をcandyParentTransformに設定する
        candy.transform.parent = candyParentTransform;

        // CandyオブジェクトのRigidbodyを取得し、力と回転を加える
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce); // フォースの加算
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0)); // トルクの加算

        // Candyのストックを消費
        candyManager.ConsumeCandy();
    }
}
