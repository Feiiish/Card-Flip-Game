using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;


    bool isWinning = false;
    int score;
    [SerializeField]
    GameObject winingPanel;
    public GameTracker gameTracker;

    void Awake()
    {
        instance = this;
        score = 0;
        winingPanel.SetActive(false);
    }
    void Update()
    {
        if (!isWinning)
        {
            if (gameTracker.gameSet == GameSet.Set2_3)
            {
                if (score >= 3)
                {
                    Win();
                }
            }
            else if (gameTracker.gameSet == GameSet.Set3_4)
            {
                if (score >= 6)
                {
                    Win();
                }
            }
            else if (gameTracker.gameSet == GameSet.Set4_4)
            {
                if (score >= 8)
                {
                    Win();
                }
            }
        }

    }
    public void addScore()
    {
        score++;
    }
    void Win()
    {
        isWinning = true;
        StartCoroutine(winningAnimation());
    }

    IEnumerator winningAnimation()
    {
        winingPanel.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Menu");

    }
}
