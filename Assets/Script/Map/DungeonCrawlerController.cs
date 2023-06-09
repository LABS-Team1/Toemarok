using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    TOP = 0,
    LEFT,
    DOWN,
    RIGHT
};

public class DungeonCrawlerController : MonoBehaviour
{
    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();
    private static readonly Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int>
    {
        {Direction.TOP, Vector2Int.up },
        {Direction.LEFT, Vector2Int.left },
        {Direction.DOWN, Vector2Int.down },
        {Direction.RIGHT, Vector2Int.right }
    };

    public static List<Vector2Int> GenerateDungeon(DungeonGenerationData dungeonData)
    {
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();

        for (int i = 0; i < dungeonData.numCrawlers; i++)
        {
            dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero)); 
        }

        int iterations = Random.Range(dungeonData.iterationMin, dungeonData.iterationMax);

        for (int i = 0; i < iterations; i++)
        {
            foreach (DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                Vector2Int newPos = dungeonCrawler.Move(directionMovementMap);
                positionsVisited.Add(newPos);
            }
        }
        return positionsVisited;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
