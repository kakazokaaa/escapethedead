using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour {

    private float timeNextGenerations = 0;
    public float timeBetweenGenerations = 60;
    public GameObject BossPrefab;
    private InterfaceControl scriptInterfaceControl;
    public Transform[] GenerationPositions;
    private Transform player;

    private void Start()
    {
        timeNextGenerations = timeBetweenGenerations;
        scriptInterfaceControl = GameObject.FindObjectOfType(typeof(InterfaceControl)) as InterfaceControl;
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > timeNextGeneration)
        {
            Vector3 creationPosition = CalculateFarthestPositionPlayer();
            Instantiate(BossPrefab, creationPosition, Quaternion.identity);
            scriptInterfaceControl.ShowBossSpawnsText();
            timeNextGeneration = Time.timeSinceLevelLoad + timeBetweenGenerations;
        }
    }

    Vector3 CalculateFarthestPositionPlayer()
    {
        Vector3 farthestPosition = Vector3.zero;
        float longestDistance = 0;

        foreach(Transform position in GenerationPositions)
        {
            float distanceBetweenPlayer = Vector3.Distance(position.position, player.position);
            if(distanceBetweenPlayer > longestDistance)
            {
                longestDistance = distanceBetweenPlayer;
                farthestPosition = position.position;
            }
        }
        return farthestPosition;
    }
}
