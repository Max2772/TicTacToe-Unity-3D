using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool firstPlayer = true;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    public bool gameOver = false;
    private int turnCount = 0;

    private int[,] gameTable = {{0, 0, 0},
                                {0, 0, 0},
                                {0, 0, 0}};

    private int[,] posTable = {{0, 1, 2},
                                {3, 4, 5},
                                {6, 7, 8}};


    public void GameOver(int winnerIdx){
        if(winnerIdx == 0){
            Debug.Log("DRAW!");
        }else{
            Debug.Log("Player " + winnerIdx + " has won the game!");
        }
        gameOver = true;
    }

    public void SpawnPlayerPrefab(Vector3 playerPos, int tablePos){
        turnCount++;

        if(firstPlayer){
             Instantiate(player1, playerPos, player1.transform.rotation);
             FillTable(1, tablePos);
        }else{
            Instantiate(player2, playerPos, player2.transform.rotation);
            FillTable(2, tablePos);
        }

        firstPlayer = !firstPlayer;
    }


    private void FillTable(int playerID, int playerPos){
        int[] pos = FindGameTableIdx(playerPos);
        if(playerID == 1){
            gameTable[pos[0], pos[1]] = 1;
        }else{
            gameTable[pos[0], pos[1]] = 2;
        }
        CheckWinner();
    }

    private void CheckWinner(){
        for(int i = 0; i < 3; ++i){ // Проверка горизонтали
            if(gameTable[i, 0] == gameTable[i, 1] && gameTable[i, 1] == gameTable[i, 2]){
                if(gameTable[i,0] == 1){
                    GameOver(1);
                }else if(gameTable[i, 0] == 2){
                    GameOver(2);
                }
            }
        }

        for(int i = 0; i < 3; ++i){ // Проверка вертикалей
            if(gameTable[0, i] == gameTable[1, i] && gameTable[1, i] == gameTable[2, i]){
                if(gameTable[0, i] == 1){
                    GameOver(1);
                }else if(gameTable[0, i] == 2){
                    GameOver(2);
                }
            }
        }

        // Проверка главной диагонали
            if(gameTable[0, 0] == gameTable[1, 1] && gameTable[1, 1] == gameTable[2, 2]){
                if(gameTable[0, 0] == 1){
                    GameOver(1);
                }else if(gameTable[0, 0] == 2){
                    GameOver(2);
                }
            }

        // Проверка побочной диагонали
            if(gameTable[2, 0] == gameTable[1, 1] && gameTable[1, 1] == gameTable[0, 2]){
                if(gameTable[2, 0] == 1){
                    GameOver(1);
                }else if(gameTable[2, 0] == 2){
                    GameOver(2);
                }
            }

    }

    private int[] FindGameTableIdx(int tablePos){
        int[] res = new int[2];
            for(int i = 0; i < 3; ++i){
                for(int j = 0; j < 3; ++j){
                    if(posTable[i,j] == tablePos){
                        res[0] = i;
                        res[1] = j;
                        return res;
                    }
            }
        }
        
        Debug.Log("FindGameTableIdx not found location!");
        return new int[] {-1, -1};
    }
}
