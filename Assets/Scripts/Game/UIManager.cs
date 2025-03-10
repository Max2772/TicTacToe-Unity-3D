using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text roundNumberText;
    [SerializeField] private TMP_Text circleWinsText;
    [SerializeField] private TMP_Text crossWinsText;
    public static int roundNumber;
    public static int circleWins;
    public static int crossWins;

    public int[] rounds = new int[]{3, 10, 999999999};


    void Start(){
        roundNumberText.text = roundNumber.ToString();
        circleWinsText.text = circleWins.ToString();
        crossWinsText.text = crossWins.ToString();
    }

    public void CircleWinsUpdate(){
        circleWins++;
        circleWinsText.text = circleWins.ToString();
    }

    public void CrossWinsUpdate(){
        crossWins++;
        crossWinsText.text = crossWins.ToString();
    }

    public void RoundNumberUpdate(){
        roundNumber++;
        roundNumberText.text = roundNumber.ToString();
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void RestartButton(){
        if(UIManager.roundNumber >= rounds[GameManager.mode]){
            SceneManager.LoadScene("Menu");
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            RoundNumberUpdate();
        }
    }
}
