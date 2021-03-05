using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnCoolDown = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
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
}
