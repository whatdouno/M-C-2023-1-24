using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Dice; // �ֻ��� ��ü
    public GameObject restart;
    public GameObject gameOver;
    public GameObject Player1; // �÷��̾�1
    public GameObject Player2; // �÷��̾�2
    public GameObject[] tile; // Ÿ�� list �ޱ�
    public static bool isGameOver; // ���� ���� ����
    // public int diceNumber;
    int diceNumber; // ���� �ֻ��� ����
    int maxTurn; // �ִ� �ϼ� ����
    int moveTime;//



    bool flag; // ���� ���ϱ�
    bool turnEnd; // �� �� ����
   


    //�Ʒ��� ���ǵ� ������ �ؽ�Ʈ�� ǥ���� ����
    public static float time;// �ð�

    public static int turn; // ���� ����

    public static int redScore; // player1 ����
    public static int blueScore; // player2 ����

    public static string winner; // ����











    // Start is called before the first frame update
    void Start()
    {
        time = 30.0f;
        restart.SetActive(false);
        gameOver.SetActive(false);
        turn = 1;
        turnEnd = false;
        
        maxTurn = 6;
        diceNumber = Dice.GetComponent<Dice>().diceNumber;
        Debug.Log("�ֻ��� ���ڴ�" + diceNumber);
        isGameOver = false;

        redScore = 0;
        blueScore = 0;

        
        moveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

           
        TurnChange();
        Counter();
        TurnTime();
        Win();
        //Reset();
        PlayerMove();
        if (isGameOver)
        {
            Debug.Log("���������: " + isGameOver);
            gameOver.GetComponent<Text>().text = "<Winner>: " + winner;
            restart.SetActive(true);
            gameOver.SetActive(true);
        }


    }

    void TurnTime()
    {
        time -= Time.deltaTime;
        if (turnEnd == true)
        {
            time = 30.0f;
            turnEnd = false;
        }

        if (time < 0)
        {
            //Player1.SetActive(false);
            //Player2.SetActive(false);
            time = 0;
        }


    }

    void Counter() // Ÿ�� ���� ���� �Լ�
    {
        if (turnEnd == true)
        {
            for (int i = 0; i < tile.Length; i++)
            {
                if (tile[i].GetComponent<Tile>().colorNumber == 1) // Player1 ���� ���� �ݺ���
                {
                    redScore++;

                }
                else if (tile[i].GetComponent<Tile>().colorNumber == 2) // Player2 ���� ���� �ݺ���
                {
                    blueScore++;
                }

            }
        }

    }

    public void OnClickRestart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    void TurnChange() // �� ��ȭ ��Ģ
    {
        if (turn <= maxTurn )
        {
            if (diceNumber == Player1.GetComponent<Player>().moveCount)
            {
                Player1.SetActive(false);

            }
            if (diceNumber == Player2.GetComponent<Player>().moveCount)
            {
                Player2.SetActive(false);
            }
            


        }
        // turn 7�϶� ���� ����
        if (Player1.activeSelf == false && Player2.activeSelf == false) // if ���ǹ��� �����̽��ٸ� ������ �Ѿ�� Ű�� �߰�����
        {

            if (turn <= maxTurn)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player1.SetActive(true);
                    Player2.SetActive(true);
                    //int routineCount = Player1.GetComponent<Player>().routine.Count;
                    //Debug.Log("��� �� Ƚ��:" + routineCount);



                    Debug.Log("�� " + turn + " ����");
                    int index1 = Player1.GetComponent<Player>().routine[diceNumber]; // Routine�� �� ������ ù ��ġ ���� ������ ����
                    int index2 = Player2.GetComponent<Player>().routine[diceNumber]; // Routine�� �� ������ ù ��ġ ���� ������ ����

                    Dice.GetComponent<Dice>().diceNumber = Random.Range(1, 7); // ex [0,0,0,0,0,0], dicenubmer = 5


                    diceNumber = Dice.GetComponent<Dice>().diceNumber; // 1~6���� ������              
                    Debug.Log("�ֻ��� ���ڴ� " + diceNumber);


                    // diceNumber + 1 �̹Ƿ� index�� diceNubmer�� ������
                    Player1.GetComponent<Player>().routine = new List<int>();
                    Player1.GetComponent<Player>().routine.Add(index1);
                    Player2.GetComponent<Player>().routine = new List<int>();
                    Player2.GetComponent<Player>().routine.Add(index2);
                    Player1.GetComponent<Player>().moveCount = 0;
                    Player2.GetComponent<Player>().moveCount = 0;
                    redScore = 0;
                    blueScore = 0;
                    // ���� ��ȭ�ϸ鼭 ��������� moveCount �ʱ�ȭ

                    for (int i = 0; i < tile.Length; i++) // ���� �ٲ�鼭 Ÿ�� ���� ���� ����
                    {
                        tile[i].GetComponent<Tile>().currentColorNumber
                        = tile[i].GetComponent<Tile>().colorNumber;
                    }


                    turn++;
                    turnEnd = true;
                }
            }


        }
    }
    /*
    void TurnEnd()
    {
        if (diceNumber == Player1.GetComponent<Player>().moveCount)
        {
            Player1.SetActive(false);
        }
        if (diceNumber == Player2.GetComponent<Player>().moveCount)
        {
            Player2.SetActive(false);
        }
    }

    IEnumerator TurnNext(GameObject player)
    {
        yield return new WaitForSeconds(2.0f);

        if (Player1.activeSelf == false && Player2.activeSelf == false && maxTurn <= 6) // if ���ǹ��� �����̽��ٸ� ������ �Ѿ�� Ű�� �߰�����
        {

            if (turn <= maxTurn && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("�� " + turn + " ����");
                Player1.SetActive(true);
                Player2.SetActive(true);
                Dice.GetComponent<Dice>().diceNumber = Random.Range(1, 7);
                diceNumber = Dice.GetComponent<Dice>().diceNumber; // 1~6���� ������              
                Debug.Log("�ֻ��� ���ڴ� " + diceNumber);
                int index = player.GetComponent<Player>().routine[diceNumber]; // Routine�� �� ������ ù ��ġ ���� ������ ���� 
                // diceNumber + 1 �̹Ƿ� index�� diceNubmer�� ������
                player.GetComponent<Player>().routine = new List<int>();
                player.GetComponent<Player>().routine.Add(index);               
                player.GetComponent<Player>().moveCount = 0;
                
                for (int i = 0; i < tiles.Length; i++)
                {
                    tiles[i].GetComponent<Tile>().currentColorNumber
                    = tiles[i].GetComponent<Tile>().colorNumber;
                }
                player.GetComponent<Player>().PlayerMove();

                turn++;
                turnEnd = true;

            }

        }
    }
    */




    void Win()
    {
        if (turn > maxTurn)
        {
            Player1.SetActive(false);
            Player2.SetActive(false);
            isGameOver = true;
        }

        if (isGameOver)
        {
            //Debug.Log("��������:" + isGameOver);
            Counter();

            if (redScore > blueScore)
            {
                winner = "Player1";
            }
            else if (redScore < blueScore)
            {
                winner = "Player2";
            }
            else
            {
                winner = "���ڰ� �������� ���߽��ϴ�.";
            }


        }



    }







    /*
    void Reset(GameObject player) // �÷��̾� ��ü�� ��ġ�� ����Ʈ�� �ְ� ��ȯ
    {


        if (Input.GetMouseButtonDown(0))
        {


            player.GetComponent<Player>().moveCount = 0;                      
            int index = player.GetComponent<Player>().routine[0];
            player.GetComponent<Player>().index = index;
            player.SetActive(true);
            player.transform.position = tiles[index].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
            player.GetComponent<Player>().routine = new List<int>();
            player.GetComponent<Player>().routine.Add(index);
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
    public void OnClickReset()
    {

        Player1.GetComponent<Player>().moveCount = 0;
        int index1 = Player1.GetComponent<Player>().routine[0];
        Player1.GetComponent<Player>().index = index1;
        Player1.SetActive(true);
        Player1.transform.position = tile[index1].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
        Player1.GetComponent<Player>().routine = new List<int>();
        Player1.GetComponent<Player>().routine.Add(index1);

        Player2.GetComponent<Player>().moveCount = 0;
        int index2 = Player2.GetComponent<Player>().routine[0];
        Player2.GetComponent<Player>().index = index2;
        Player2.SetActive(true);
        Player2.transform.position = tile[index2].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
        Player2.GetComponent<Player>().routine = new List<int>();
        Player2.GetComponent<Player>().routine.Add(index2);
        for (int i = 0; i < tile.Length; i++)
        {
            int j = tile[i].GetComponent<Tile>().currentColorNumber; // Ÿ���� �� ���� �� ����
            tile[i].GetComponent<MeshRenderer>().material
            = tile[i].GetComponent<Tile>().tileColor[j]; // �� �ʱ�ȭ
        }
        Debug.Log("�ʱ�ȭ");

    }
    /*
    void Reset() // �÷��̾� ��ü�� ��ġ�� ����Ʈ�� �ְ� ��ȯ
    {


        if (Input.GetMouseButtonDown(0))
        {

            Player1.GetComponent<Player>().moveCount = 0;
            int index1 = Player1.GetComponent<Player>().routine[0];
            Player1.GetComponent<Player>().index = index1;
            Player1.SetActive(true);
            Player1.transform.position = tile[index1].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
            Player1.GetComponent<Player>().routine = new List<int>();
            Player1.GetComponent<Player>().routine.Add(index1);

            Player2.GetComponent<Player>().moveCount = 0;
            int index2 = Player2.GetComponent<Player>().routine[0];
            Player2.GetComponent<Player>().index = index2;
            Player2.SetActive(true);
            Player2.transform.position = tile[index2].transform.position; // player�� ��ġ�� Ÿ�� �ε����� �����ϴ� ������ �迭
            Player2.GetComponent<Player>().routine = new List<int>();
            Player2.GetComponent<Player>().routine.Add(index2);
            for (int i = 0; i < tile.Length; i++)
            {
                int j = tile[i].GetComponent<Tile>().currentColorNumber; // Ÿ���� �� ���� �� ����
                tile[i].GetComponent<MeshRenderer>().material
                = tile[i].GetComponent<Tile>().tileColor[j]; // �� �ʱ�ȭ
            }
            Debug.Log("�ʱ�ȭ");
        }

    }
    */

    void PlayerMove() // Player�� ���ϴ� ��� ���ÿ� ������
    {
        List<int> copyRoutine1 = Player1.GetComponent<Player>().routine;
        List<int> copyRoutine2 = Player2.GetComponent<Player>().routine;
        if (time == 0)
        {
            for (int i = 0; i <= diceNumber; i++)
            {

                //StartCoroutine(TurnMove(i, copyRoutine1, 1));
                //StartCoroutine(TurnMove(i, copyRoutine2, 2));
            }
            
        }

    }

    public void TurnMove(int i, List<int> copyRoutine, int id) // id�� �÷��̾� ��ȣ
    {
        Player1.SetActive(true);
        Player2.SetActive(true);
       
               
        int pos = copyRoutine[i];

        if (id == 1)
        {
            Player1.transform.position = tile[pos].transform.position;
        }
        else if (id == 2)
        {
            Player2.transform.position = tile[pos].transform.position;
        }
        
        // [ 123456 ] 
        /*
        int pos1 = Player1.GetComponent<Player>().routine[i];
        Player1.transform.position = tile[pos1].transform.position;
        int pos2 = Player2.GetComponent<Player>().routine[i];
        Player2.transform.position = tile[pos2].transform.position;
       */



    }



    public static void Rule()
    {
        int index1 = GameObject.Find("Player1").GetComponent<Player>().index;
        int index2 = GameObject.Find("Player2").GetComponent<Player>().index;
        if (index1 == index2)
        {

           GameObject.Find("Player1").GetComponent<Player>().unPaint = true;
           GameObject.Find("Player2").GetComponent<Player>().unPaint = true;


        }
        else
        {
            GameObject.Find("Player1").GetComponent<Player>().unPaint = false;
            GameObject.Find("Player2").GetComponent<Player>().unPaint = false;
        }
    }
}


