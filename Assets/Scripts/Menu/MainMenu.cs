using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame(){
        UIManager.roundNumber = 1;
        UIManager.crossWins = 0;
        UIManager.circleWins = 0;
        
        if(EventSystem.current.currentSelectedGameObject.name == "Bo3 Button"){
            GameManager.mode = 0;
        }else if(EventSystem.current.currentSelectedGameObject.name == "Bo10 Button"){
            GameManager.mode = 1;
        }else if(EventSystem.current.currentSelectedGameObject.name == "BoInifinity Button"){
            GameManager.mode = 2;
        }

        SceneManager.LoadScene("Game");
    }

    public void QuitGame(){
        Debug.Log("Game quitted");
        Application.Quit();
    }
}
