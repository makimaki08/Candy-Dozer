using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30;

    // 現在のキャンディのストック数
    public int candy = DefaultCandyAmount;

    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }

    public int GetCandyAmount()
    {
        return candy;
    }

    public void AddCandy(int amount)
    {
        candy += amount;
    }

    void OnGUI()
    {
        GUI.color = Color.black;

        // キャンディのストック数を表示
        string label = "Candy : " + candy;
        GUI.Label(new Rect(50, 50, 100, 30), label);
    }
}
