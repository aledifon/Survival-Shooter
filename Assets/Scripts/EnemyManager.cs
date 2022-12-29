using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("HellElephant Enemy")]
    public GameObject hellEphantPrefab;
    int maxHellEphantPrefab = 2;
    int countHellEphantPrefab;

    [Header("ZomBunny Enemy")]
    public GameObject zomBunnyPrefab;
    int maxZomBunnyPrefab = 6;
    int countZomBunnyPrefab;

    [Header("ZomBear Enemy")]
    public GameObject zomBearPrefab;
    int maxZomBearPrefab = 4;
    int countZomBearPrefab;

    //GameObject enemyPrefab;
    Vector3 randomPos;

    // Start is called before the first frame update
    void Start()
    {
        //Prefabs Generation every 2s
        InvokeRepeating("SpawnZomBunnyEnemy", 2, 2);
        InvokeRepeating("SpawnZomBearEnemy", 2, 2);
        InvokeRepeating("SpawnHellEphantEnemy", 2, 2);

        ////Create ZomBunny Prefabs
        //for (int i = 0; i < maxZomBunnyPrefab; i++)
        //    SpawnEnemy(zomBunnyPrefab);
        ////Create ZomBear Prefabs
        //for (int i = 0; i < maxZomBearPrefab; i++)
        //    SpawnEnemy(zomBearPrefab);
        ////Create HellElephant Prefabs
        //for (int i = 0; i < maxHellEphantPrefab; i++)
        //    SpawnEnemy(hellEphantPrefab);
    }

    // Update is called once per frame
    void Update()
    {       
        if (countZomBunnyPrefab == maxZomBunnyPrefab) 
            CancelInvoke("SpawnZomBunnyEnemy");
        if (countZomBearPrefab == maxZomBearPrefab)
            CancelInvoke("SpawnZomBearEnemy");
        if (countHellEphantPrefab == maxHellEphantPrefab)
            CancelInvoke("SpawnHellEphantEnemy");
    }
    void GenerateRandomPos()
    {
        int x = Random.Range(-27, 27);
        int y = 0;
        int z = Random.Range(-28, 16);
        randomPos = new Vector3(x, y, z);
    }
    void SpawnZomBunnyEnemy()
    {
        //Generates Random Position
        GenerateRandomPos();
        //Instantiates the clone Enemy in the random position
        Instantiate(zomBunnyPrefab, randomPos, new Quaternion(0, 0, 0, 1));
        countZomBunnyPrefab++;
        Debug.Log("ZomBunny num " + countZomBunnyPrefab + "created");
    }
    void SpawnZomBearEnemy()
    {
        //Generates Random Position
        GenerateRandomPos();
        //Instantiates the clone Enemy in the random position
        Instantiate(zomBearPrefab, randomPos, new Quaternion(0, 0, 0, 1));
        countZomBearPrefab++;
        Debug.Log("ZomBear num " + countZomBearPrefab + "created");
    }
    void SpawnHellEphantEnemy()
    {
        //Generates Random Position
        GenerateRandomPos();
        //Instantiates the clone Enemy in the random position
        Instantiate(hellEphantPrefab, randomPos, new Quaternion(0, 0, 0, 1));
        countHellEphantPrefab++;
        Debug.Log("HellEphant num " + countHellEphantPrefab + "created");
    }
}
