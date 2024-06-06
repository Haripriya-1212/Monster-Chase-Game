using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyReference;

    GameObject spawnedEnemy;
    

    [SerializeField]
    Transform leftPos, rightPos;

    int randonIndex;
    int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randonIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(enemyReference[randonIndex]);
            

            // left side
            if (randomSide == 0)
            {
                spawnedEnemy.transform.position = leftPos.transform.position;
                // speed in enemy script
                spawnedEnemy.GetComponent<enemy>().speed = Random.Range(4, 10);
            }
            // right side
            else
            {
                spawnedEnemy.transform.position = rightPos.transform.position;
                spawnedEnemy.GetComponent<enemy>().speed = -Random.Range(4, 10);
                spawnedEnemy.GetComponent<enemy>().enemySR.flipX = true;
                //spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

    }
}
