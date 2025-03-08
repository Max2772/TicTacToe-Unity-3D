using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }

    public void QuitGame(){
        Debug.Log("Game quitted");
        Application.Quit();
    }
}
