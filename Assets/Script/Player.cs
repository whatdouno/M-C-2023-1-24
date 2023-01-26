using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] tiles; //타일 객체 받아오기
    public GameObject[] arrows; // player가 갈 수 있는 방향 표시
    public int id; // 플레이어 정보 받기
    public GameObject player; // Player 객체 받기
    public int index;
    
    
    
    public int moveCount = 0; // 움직인 횟수

    public List<int> routine; // 플레이어 경로 저장

    public bool unPaint;
    







    // Start is called before the first frame update
    void Start()
    {
        unPaint = false;

        if (player.tag == "Player1")
        {
            index = 4; // 정중앙에 대한 일반화 한 식 나중에 넣어보기
            player.transform.position = tiles[4].transform.position; // Player의 위치를 해당 타일의 위치로 옮김
            tiles[index].GetComponent<Tile>().MakeRed(); // 초기 Player1위치 영역 색깔 색칠
            tiles[index].GetComponent<Tile>().currentColorNumber = 1;
            Debug.Log(player.transform.position);
            SaveRoutine();
        }
        if (player.tag == "Player2")
        {
            index = 13; // 정중앙에 대한 일반화 한 식 나중에 넣어보기
            player.transform.position = tiles[13].transform.position; // Player의 위치를 해당 타일의 위치로 옮김
            tiles[index].GetComponent<Tile>().MakeBlue(); // 초기 Player2 위치 영역 색깔 색칠
            tiles[index].GetComponent<Tile>().currentColorNumber = 2;
            SaveRoutine();

        }

        

    }

    

    // Update is called once per frame
    void Update()
    {    // Player1 기준에서 인덱스가 0에 가까운 위치가 천장(위쪽)

        
        Move();
        VisualDirection();
        
          

        
        

    }


    void Move()
    {
       
        if (player.tag == "Player1")
        {


            if (Input.GetKeyDown(KeyCode.W))
            {

                if (index + 3 <= 17) // Player1 기준 맨 아래
                {
                    index += 3;
                    Paint();
                    moveCount++; // 움직였으면 1추가                   
                    SaveRoutine();
                }
                else
                {
                    Debug.Log("아래로 갈 수 없음");
                }



            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (index % 3 == 2) // Player1 기준 맨왼쪽
                {
                    Debug.Log("왼쪽으로 갈 수 없음");
                }
                else
                {
                    index += 1;
                    Paint();
                    moveCount++; // 움직였으면 1추가                  
                    SaveRoutine();

                }

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (index - 3 >= 0) // Player1 기준 올라감
                {
                    index -= 3;
                    Paint();
                    moveCount++; // 움직였으면 1추가
                    SaveRoutine();


                }
                else
                {
                    Debug.Log("위로 갈수 없음");
                }
                

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (index % 3 == 0) // Player1 기준 맨 오른쪽
                {
                    Debug.Log("오른쪽으로 갈 수 없음");
                }
                else
                {
                    index -= 1;
                    Paint();
                    moveCount++; // 움직였으면 1추가                    
                    SaveRoutine();
                }

            }

            




        }
        if (player.tag == "Player2")
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (index - 3 >= 0) // Player2 기준 올라감
                {
                    index -= 3;
                    Paint();
                    moveCount++; // 움직였으면 1추가                   
                    SaveRoutine();

                }
                else
                {
                    Debug.Log("위로 갈수 없음");

                }


            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (index % 3 == 0) // Player1 기준 맨왼쪽
                {
                    Debug.Log("왼쪽으로 갈 수 없음");
                }
                else
                {
                    index -= 1;
                    Paint();
                    moveCount++; // 움직였으면 1추가
                    SaveRoutine();
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (index + 3 <= 17) // Player2 기준 맨 아래
                {
                    index += 3;
                    Paint();
                    moveCount++; // 움직였으면 1추가
                    SaveRoutine();
                }
                else
                {
                    Debug.Log("아래로 갈 수 없음");
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (index % 3 == 2) // Player2 기준 맨 오른쪽
                {
                    Debug.Log("오른쪽으로 갈 수 없음");
                }
                else
                {
                    index += 1;
                    Paint();
                    moveCount++; // 움직였으면 1추가
                    SaveRoutine();
                }


            }

            

        }



    }

    
    void VisualDirection()
    {
        if (player.tag == "Player1")
        {
            
            if (index % 3 == 0) // 움직인 후 인덱스 받고 Player1 기준 가장 오른쪽
            {
                arrows[1].SetActive(false);
            }
            else
            {
                arrows[1].SetActive(true);
            }
            

            if (index % 3 == 2) // 움직인 후 인덱스 받고 Player1 기준 가장 왼쪽
            {
                arrows[0].SetActive(false);
            }
            else
            {
                arrows[0].SetActive(true);
            }


            if (index - 3 < 0) // 움직인 후 인덱스 받고 Player1 위쪽 판정
            {
                arrows[3].SetActive(false);
            }
            else
            {
                arrows[3].SetActive(true);
            }

            if (index + 3 > 17) // 움직인 후 인덱스 받고 Player1 아래쪽 판정
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

            if (index % 3 == 0) // 움직인 후 인덱스 받고 Player1 기준 가장 오른쪽
            {
                arrows[1].SetActive(false);
            }
            else
            {
                arrows[1].SetActive(true);
            }


            if (index % 3 == 2) // 움직인 후 인덱스 받고 Player1 기준 가장 왼쪽
            {
                arrows[0].SetActive(false);
            }
            else
            {
                arrows[0].SetActive(true);
            }


            if (index - 3 < 0) // 움직인 후 인덱스 받고 Player1 위쪽 판정
            {
                arrows[3].SetActive(false);
            }
            else
            {
                arrows[3].SetActive(true);
            }

            if (index + 3 > 17) // 움직인 후 인덱스 받고 Player1 아래쪽 판정
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
                tiles[index].GetComponent<Tile>().MakeRed();// 도착한 영역 Player1의 색깔 칠함
                if (index % 3 == 0) // 움직인 후 인덱스 받고 Player1 기준 가장 오른쪽
                {
                    Debug.Log("우측은 칠해지지 않음");
                }
                else
                {
                    tiles[index - 1].GetComponent<Tile>().MakeRed();
                }

                if (index % 3 == 2) // 움직인 후 인덱스 받고 Player1 기준 가장 왼쪽
                {
                    Debug.Log("좌측은 칠해지지 않음");
                }
                else
                {
                    tiles[index + 1].GetComponent<Tile>().MakeRed();
                }

                if (index - 3 >= 0) // 움직인 후 인덱스 받고 Player1 위쪽 판정
                {
                    tiles[index - 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("위쪽은 칠해지지 않음");
                }

                if (index + 3 <= 17) // 움직인 후 인덱스 받고 Player1 아래쪽 판정
                {
                    tiles[index + 3].GetComponent<Tile>().MakeRed();
                }
                else
                {
                    Debug.Log("아래쪽은 칠해지지 않음");
                }



                player.transform.position = tiles[index].transform.position;


            }

            if (player.tag == "Player2")
            {
                tiles[index].GetComponent<Tile>().MakeBlue(); // 도착한 영역 Player2의 색깔 칠함
                if (index % 3 == 0) // 움직인 후 인덱스 받고 Player2 기준 가장 왼쪽
                {
                    Debug.Log("왼측은 칠해지지 않음");
                }
                else
                {
                    tiles[index - 1].GetComponent<Tile>().MakeBlue();
                }

                if (index % 3 == 2) // 움직인 후 인덱스 받고 Player2 기준 가장 오른쪽
                {
                    Debug.Log("우측은 칠해지지 않음");
                }
                else
                {
                    tiles[index + 1].GetComponent<Tile>().MakeBlue();
                }

                if (index - 3 >= 0) // 움직인 후 인덱스 받고 Player2 위쪽 판정
                {
                    tiles[index - 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("위쪽은 칠해지지 않음");
                }

                if (index + 3 <= 17) // 움직인 후 인덱스 받고 Player2 아래쪽 판정
                {
                    tiles[index + 3].GetComponent<Tile>().MakeBlue();
                }
                else
                {
                    Debug.Log("아래쪽은 칠해지지 않음");
                }



                player.transform.position = tiles[index].transform.position;
            }


        }

    }


    void SaveRoutine() // 플레이어 객체의 위치를 리스트에 넣고 반환
    {
        routine.Add(index); // player가 위치한 타일 인덱스를 저장하는 일차원 배열      
        DebugRoutine();
    }


    /*
    void Reset() // 플레이어 객체의 위치를 리스트에 넣고 반환
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            
                                 
            moveCount = 0;
            index = routine[0];           
            player.SetActive(true);
            player.transform.position = tiles[index].transform.position; // player가 위치한 타일 인덱스를 저장하는 일차원 배열
            routine = new List<int>();
            routine.Add(index);
            for (int i = 0; i < tiles.Length; i++)
            {
                int j = tiles[i].GetComponent<Tile>().currentColorNumber; // 타일의 턴 변경 전 색상
                tiles[i].GetComponent<MeshRenderer>().material 
                = tiles[i].GetComponent<Tile>().tileColor[j]; // 색 초기화
            }
            Debug.Log("초기화");
        }
    
    }
    */

    /*
    public void PlayerMove() // Player가 원하는 대로 동시에 움직임
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
            Debug.Log("충돌");
        }


    }
    */
   

    void DebugRoutine() // 경로 저장(index) 잘 되어있는지 확인 용도
    {
        for (int i = 0; i < routine.Count; i++)
        {
            Debug.Log(routine[i]);
        }
    }

}
