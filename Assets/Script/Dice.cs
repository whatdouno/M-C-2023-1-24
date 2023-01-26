using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int diceNumber;

    // Start is called before the first frame update
    void Start()
    {
        diceNumber = Random.Range(1, 7); // 주사위 숫자 저장 1~6
        DiceAnimation();
    }

    // Update is called once per frame
    void Update()
    {




    }

    void DiceAnimation()
    {
        switch (diceNumber) // 애니메이션 넣을때 활용하면 좋지 않을까?
        {
            case 1:
                Debug.Log(diceNumber);
                break;

            case 2:
                Debug.Log(diceNumber);
                break;

            case 3:
                Debug.Log(diceNumber);
                break;

            case 4:
                Debug.Log(diceNumber);
                break;

            case 5:
                Debug.Log(diceNumber);
                break;

            case 6:
                Debug.Log(diceNumber);
                break;
        }
    }
}
