using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] tiles; //Ÿ�� ��ü �޾ƿ���
    public GameObject[] arrows; // player�� �� �� �ִ� ���� ǥ��
    public int id; // �÷��̾� ���� �ޱ�
    public GameObject player; // Player ��ü �ޱ�
    public int index;
    
    
    
    public int moveCount = 0; // ������ Ƚ��

    public List<int> routine; // �÷��̾� ��� ����

    public bool unPaint;
    







    // Start is called before the first frame update
    void Start()
    {
        unPaint = false;

        if (player.tag == "Player1")
        {
            index = 4; // ���߾ӿ� ���� �Ϲ�ȭ �� �� ���߿� �־��
            player.transform.position = tiles[4].transform.position; // Player�� ��ġ�� �ش� Ÿ���� ��ġ�� �ű�
            tiles[index].GetComponent<Tile>().MakeRed(); // �ʱ� Player1��ġ ���� ���� ��ĥ
            tiles[index].GetComponent<Tile>().currentColorNumber = 1;
            Debug.Log(player.transform.position);
            SaveRoutine();
        }
        if (player.tag == "Player2")
        {
            index = 13; // ���߾ӿ� ���� �Ϲ�ȭ �� �� ���߿� �־��
            player.transform.position = tiles[13].transform.position; // Player�� ��ġ�� �ش� Ÿ���� ��ġ�� �ű�
            tiles[index].GetComponent<Tile>().MakeBlue(); // �ʱ� Player2 ��ġ ���� ���� ��ĥ
            tiles[index].GetComponent<Tile>().currentColorNumber = 2;
            SaveRoutine();

        }

        

    }

    

    // Update is called once per frame
    void Update()
    {    // Player1 ���ؿ��� �ε����� 0�� ����� ��ġ�� õ��(����)

        
        Move();
        VisualDirection();
        
          

        
        

    }


    void Move()
    {
       
        if (player.tag == "Player1")
        {


            if (Input.GetKeyDown(KeyCode.W))
            {

                if (index + 3 <= 17) // Player1 ���� �� �Ʒ�
                {
                    index += 3;
                    Paint();
                    moveCount++; // ���������� 1�߰�                   
                    SaveRoutine();
                }
                else
                {
                    Debug.Log("�Ʒ��� �� �� ����");
                }



            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (index % 3 == 2) // Player1 ���� �ǿ���
                {
                    Debug.Log("�������� �� �� ����");
                }
                else
                {
                    index += 1;
                    Paint();
                    moveCount++; // ���������� 1�߰�                  
                    SaveRoutine();

                }

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (index - 3 >= 0) // Player1 ���� �ö�
                {
                    index -= 3;
                    Paint();
                    moveCount++; // ���������� 1�߰�
                    SaveRoutine();


                }
                else
                {
                    Debug.Log("���� ���� ����");
                }
                

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (index % 3 == 0) // Player1 ���� �� ������
                {
                    Debug.Log("���������� �� �� ����");
                }
                else
                {
                    index -= 1;
                    Paint();
                    moveCount++; // ���������� 1�߰�                    
                    SaveRoutine();
                }

            }

            




        }
        if (player.tag == "Player2")
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (index - 3 >= 0) // Player2 ���� �ö�
                {
                    index -= 3;
                    Paint();
                    moveCount++; // ���������� 1�߰�                   
                    SaveRoutine();

                }
                else
                {
                    Debug.Log("���� ���� ����");

                }


            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (index % 3 == 0) // Player1 ���� �ǿ���
                {
                    Debug.Log("�������� �� �� ����");
                }
                else
                {
                    index -= 1;
                    Paint();
                    moveCount++; // ���������� 1�߰�
                    SaveRoutine();
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (index + 3 <= 17) // Player2 ���� �� �Ʒ�
                {
                    index += 3;
                    Paint();
                    moveCount++; // ���������� 1�߰�
                    SaveRoutine();
                }
                else
                {
                    Debug.Log("�Ʒ��� �� �� ����");
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (index % 3 == 2) // Player2 ���� �� ������
                {
                    Debug.Log("���������� �� �� ����");
                }
                else
                {
                    index += 1;
                    Paint();
                    moveCount++; // ���������� 1�߰�
                    SaveRoutine();
                }


            }

            

        }



    }

    
    void VisualDirection()
    {
        if (player.tag == "Player1")
        {
            
            if (index % 3 == 0) // ������ �� �ε��� �ް� Player1 ���� ���� ������
            {
                arrows[1].SetActive(false);
            }
            else
            {
                arrows[1].SetActive(true);
            }
            

            if (index % 3 == 2) // ������ �� �ε��� �ް� Player1 ���� ���� ����
            {
                arrows[0].SetActive(false);
            }
            else
            {
                arrows[0].SetActive(true);
            }


            if (index - 3 < 0) // ������ �� �ε��� �ް� Player1 ���� ����
            {
                arrows[3].SetActive(false);
            }
            else
            {
                arrows[3].SetActive(true);
            }

            if (index + 3 > 17) // ������ �� �ε��� �ް� Player1 �Ʒ��� ����
            {
                arrows[2].SetActive(false);
            }
            else
            {
                arrows[2].SetActive(true);
            }

        }

        if (player.tag == "Player2")
        {

            if (index % 3 == 0) // ������ �� �ε��� �ް� Player1 ���� ���� ������
            {
                arrows[1].SetActive(false);
            }
            else
            {
                arrows[1].SetActive(true);
            }


            if (index % 3 == 2) // ������ �� �ε��� �ް� Player1 ���� ���� ����
            {
                arrows[0].SetActive(false);
            }
            else
            {
                arrows[0].SetActive(true);
            }


            if (index - 3 < 0) // ������ �� �ε��� �ް� Player1 ���� ����
            {
                arrows[3].SetActive(false);
            }
            else
            {
                arrows[3].SetActive(true);
            }

            if (index + 3 > 17) // ������ �� �ε��� �ް� Player1 �Ʒ��� ����
            {
                arrows[2].SetActive(false);
            }
            else
            {
                arrows[2].SetActive(true);
            }




        }




    }


    void Paint()
    {

        if (!unPaint)
        { 
            if (player.tag == "Player1")
            {
                tiles[index].GetComponent<Tile>().MakeRed();// ������ ���� Player1�� ���� ĥ��
                if (index % 3 == 0) // ������ �� �ε��� �ް� Player1 ���� ���� ������
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index - 1].GetComponent<Tile>().MakeRed();
                }

                if (index % 3 == 2) // ������ �� �ε��� �ް� Player1 ���� ���� ����
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index + 1].GetComponent<Tile>().MakeRed();
                }

                if (index - 3 >= 0) // ������ �� �ε��� �ް� Player1 ���� ����
                {
                    tiles[index - 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("������ ĥ������ ����");
                }

                if (index + 3 <= 17) // ������ �� �ε��� �ް� Player1 �Ʒ��� ����
                {
                    tiles[index + 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("�Ʒ����� ĥ������ ����");
                }



                player.transform.position = tiles[index].transform.position;


            }

            if (player.tag == "Player2")
            {
                tiles[index].GetComponent<Tile>().MakeBlue(); // ������ ���� Player2�� ���� ĥ��
                if (index % 3 == 0) // ������ �� �ε��� �ް� Player2 ���� ���� ����
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index - 1].GetComponent<Tile>().MakeBlue();
                }

                if (index % 3 == 2) // ������ �� �ε��� �ް� Player2 ���� ���� ������
                {
                    Debug.Log("������ ĥ������ ����");
                }
                else
                {
                    tiles[index + 1].GetComponent<Tile>().MakeBlue();
                }

                if (index - 3 >= 0) // ������ �� �ε��� �ް� Player2 ���� ����
                {
                    tiles[index - 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("������ ĥ������ ����");
                }

                if (index + 3 <= 17) // ������ �� �ε��� �ް� Player2 �Ʒ��� ����
                {
                    tiles[index + 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("�Ʒ����� ĥ������ ����");
                }



                player.transform.position = tiles[index].transform.position;
            }


        }

    }


    void SaveRoutine() // �÷��̾� ��ü�� ��ġ�� ����Ʈ�� �ְ� ��ȯ
    {
        routine.Add(index); // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭      
        DebugRoutine();
    }


    /*
    void Reset() // �÷��̾� ��ü�� ��ġ�� ����Ʈ�� �ְ� ��ȯ
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            
                                 
            moveCount = 0;
            index = routine[0];           
            player.SetActive(true);
            player.transform.position = tiles[index].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
            routine = new List<int>();
            routine.Add(index);
            for (int i = 0; i < tiles.Length; i++)
            {
                int j = tiles[i].GetComponent<Tile>().currentColorNumber; // Ÿ���� �� ���� �� ����
                tiles[i].GetComponent<MeshRenderer>().material 
                = tiles[i].GetComponent<Tile>().tileColor[j]; // �� �ʱ�ȭ
            }
            Debug.Log("�ʱ�ȭ");
        }
    
    }
    */

    /*
    public void PlayerMove() // Player�� ���ϴ� ��� ���ÿ� ������
    {
        for (int i = 0; i <= routine.Count; i++)
        {

            StartCoroutine(TrunMove(i));
        }

    }

    IEnumerator TrunMove(int i)
    {
        yield return new WaitForSeconds(2.0f);
        int pos = routine[i];
        player.transform.position = tiles[pos].transform.position;
    }
    */
    
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player2" || other.tag == "Player1")
        {                      
            Debug.Log("�浹");
        }


    }
    */
   

    void DebugRoutine() // ��� ����(index) �� �Ǿ��ִ��� Ȯ�� �뵵
    {
        for (int i = 0; i < routine.Count; i++)
        {
            Debug.Log(routine[i]);
        }
    }

}
