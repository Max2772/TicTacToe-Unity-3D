using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] GameManager gameManagerScript;
    [SerializeField] UIManager UIManagerScript;

    void Start(){
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        UIManagerScript = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.R)){
            if(UIManager.roundNumber >= UIManagerScript.rounds[GameManager.mode]){
                SceneManager.LoadScene("Menu");
            }else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                UIManagerScript.RoundNumberUpdate();
            }
        }

        if(Input.GetMouseButtonDown(0) && !gameManagerScript.gameOver){ 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                if(hit.collider.CompareTag("Cell")){
                    Debug.Log("В ячейку номер " + hit.collider.name);
                    int pos = ExtractNumberFromString(hit.collider.name);
                    gameManagerScript.SpawnPlayerPrefab(hit.collider.transform.position, pos);

                    Destroy(hit.collider);
                }
            }
        }

    }

    int ExtractNumberFromString(string str){
        int num;
        for(int i = 0; i < str.Length; ++i){
            if(str[i] > 47 && str[i] < 58){
                num = str[i] - '0';
                return num;
            }
        }
        return 0;
    }

}
