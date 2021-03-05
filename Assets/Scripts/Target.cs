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

    private Rigidbody targetRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();

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
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
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
