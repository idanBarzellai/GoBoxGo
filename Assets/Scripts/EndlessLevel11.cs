using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevel11 : MonoBehaviour
{
    float spawnCount;
    GameObject obs;
    public GameObject[] spawns;
    public GameObject obstacle;
    Queue<GameObject> newObstacles;
    public Player player;
    Vector3 position;
    void Start()
    {
        
        newObstacles = new Queue<GameObject>();
        InvokeRepeating("DeployObstacle", 0, 0.5f);
        InvokeRepeating("DeployDoubleObstacle", 10f, 2f);
        InvokeRepeating("DeployDoubleObstacle", 50f, 2f);
        InvokeRepeating("DeployTripleObstacle", 100f, 2f);
        InvokeRepeating("DeployTripleObstacle", 150f, 1f);
        spawnCount = spawns.Length;
    }

    private void DeployObstacle()
    {
        position = spawns[(int)Random.Range(0, spawnCount)].transform.position;
        obs = Instantiate(obstacle, position, new Quaternion(0, 0, 0, 0), this.transform);
        newObstacles.Enqueue(obs);
        Invoke("DestoryObstacle", 6f);
    }
    private void DeployDoubleObstacle()
    {
        DeployObstacle();DeployObstacle();
    }
    private void DeployTripleObstacle()
    {
        DeployObstacle(); DeployObstacle(); DeployObstacle();
    }
    private void DestoryObstacle()
    {   
        if(newObstacles.Peek() != null)
            Destroy(newObstacles.Dequeue());
    }
}
