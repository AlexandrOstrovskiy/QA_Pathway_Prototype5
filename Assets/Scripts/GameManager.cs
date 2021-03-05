using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

    private float spawnCoolDown = 1.0f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true)
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
    }
}
