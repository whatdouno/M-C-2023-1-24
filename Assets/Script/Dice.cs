using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int diceNumber;

    // Start is called before the first frame update
    void Start()
    {
        diceNumber = Random.Range(1, 7); // �ֻ��� ���� ���� 1~6
        DiceAnimation();
    }

    // Update is called once per frame
    void Update()
    {




    }

    void DiceAnimation()
    {
        switch (diceNumber) // �ִϸ��̼� ������ Ȱ���ϸ� ���� ������?
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
