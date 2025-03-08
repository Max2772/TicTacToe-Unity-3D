using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    [SerializeField] private GameObject[] flyPrefabs;
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private Vector3 gravityValue = new Vector3(0f, 0f, 0f);
    [SerializeField] private float maxTorque = 50f;
    [SerializeField] private float minForce = 50f;
    [SerializeField] private float maxForce = 100f;
    [SerializeField] private Vector3 shootingDirection;

    //For RandomVector3Offset:
    [SerializeField] float randomXInterval = 0f;
    [SerializeField] float randomYInterval = 0f;
    [SerializeField] float randomZInterval = 0f;

    void Start(){
        Physics.gravity = gravityValue;
        StartCoroutine(SendPrefabFlying());
        StartCoroutine(DeleteDistantPrefabs());
    }

    IEnumerator DeleteDistantPrefabs(){
        while(true){
            yield return new WaitForSeconds(respawnTime * 5);
            List<GameObject> distantPrefabs = new List<GameObject>();
            Rigidbody[] rbDistantPrefabs = FindObjectsByType<Rigidbody>(FindObjectsSortMode.None);

            for(int i = 0; i < rbDistantPrefabs.Length; ++i){
                if(rbDistantPrefabs[i].transform.position.z > 30 || rbDistantPrefabs[i].transform.position.z < -40
                || rbDistantPrefabs[i].transform.position.y > 30 || rbDistantPrefabs[i].transform.position.y < -40
                || rbDistantPrefabs[i].transform.position.x < -30 || rbDistantPrefabs[i].transform.position.x > 100){
                    distantPrefabs.Add(rbDistantPrefabs[i].gameObject);
                }
            }

            for(int i = 0; i < distantPrefabs.Count; ++i){
                Destroy(distantPrefabs[i]);
            }
        }
    }

    IEnumerator SendPrefabFlying(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            int randomIdx = Random.Range(0, 2);
            float randomForce = Random.Range(minForce, maxForce);
            float randomSpawn = Random.Range(-10, 10);
            float randomTorque = Random.Range(-maxTorque, maxTorque);

            var instance = Instantiate(flyPrefabs[randomIdx], transform.position + RandomVector3Offset(), flyPrefabs[randomIdx].transform.rotation);
            instance.GetComponent<Rigidbody>().AddForce(shootingDirection * randomForce);
            instance.GetComponent<Rigidbody>().AddTorque(randomTorque, randomTorque, randomTorque);
        }
    }

    private Vector3 RandomVector3Offset(){
        float randomX = Random.Range(-randomXInterval, randomXInterval);
        float radnomY = Random.Range(-randomYInterval, randomYInterval);
        float randomZ = Random.Range(-randomZInterval, randomZInterval);
        Vector3 offsetVector = new Vector3(randomX, radnomY, randomZ);

        return offsetVector;
    }
}
