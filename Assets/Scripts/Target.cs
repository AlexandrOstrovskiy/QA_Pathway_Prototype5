using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float speedMin = 11.1f;
    private float speedMax = 17.7f;
    private float torqueMin = 8.8f;
    private float torqueMax = 16.6f;
    private float rangeX = 4.4f;
    private float spawnPosY = - 4.4f;

    [SerializeField]
    private int pointValue;

    [SerializeField]
    ParticleSystem explosionParticle;

    private Rigidbody targetRigidbody;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        transform.position = RandomSpawnPos() ;

        targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameOn)
        {
        Destroy(gameObject);
        if (gameObject.CompareTag("8ball"))
            gameManager.UpdateScore(1 * Random.Range(-5, 5));
        else
            gameManager.UpdateScore(1 * pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        //if (!(other.gameObject.CompareTag("Bad") || other.gameObject.CompareTag("8ball")))
        //if (other.gameObject.CompareTag("Untagged"))
        if (gameObject.CompareTag("Good"))
            gameManager.GameOver();
    }


    private Vector3 RandomForce()
    {
        return (Vector3.up * Random.Range(speedMin, speedMax));
    }

    private float RandomTorque()
    {
        return (Random.Range(torqueMin, torqueMax));
    }

    private Vector3 RandomSpawnPos()
    {
        return (new Vector3(Random.Range(-rangeX, rangeX), spawnPosY, transform.position.z));
    }
}
