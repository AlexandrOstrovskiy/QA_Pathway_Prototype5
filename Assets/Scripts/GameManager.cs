using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    public bool isGameOn;

    private float spawnCoolDown = 1.0f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameOn)
        {

        yield return new WaitForSeconds(spawnCoolDown);

        int index = Random.Range(0, (targets.Count - 1));

        Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        scoreText.text = "Score: " + score;
        //if (score < 0)
        //    GameOver();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameOn = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        isGameOn = true;
        spawnCoolDown /= difficulty; 
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
}
