using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField] private Transform wallprefab;
    [SerializeField] private float size = 1f;
    [SerializeField] private int width = 10;
    [SerializeField] private int heigth = 10;// Start is called before the first frame update
    [SerializeField] private int seed = 0;
    [SerializeField] private int StartPosition=0;
    [SerializeField] private int EndPosition=0;


    void Start()
    {
        
        var maze = MazeGeneration.Generate(width, heigth,seed);
        maze[0, StartPosition] &= ~WallState.LEFT;
        maze[width-1, EndPosition] &= ~WallState.RIGHT;

        Draw(maze);
    }

    private void Draw(WallState[,] maze) 
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < heigth; j++)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i ,0 , -heigth/2 + j);
                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallprefab, transform) as Transform;
                    topWall.position = position + new Vector3(0,0,size/2);
                    topWall.localScale = new Vector3(size,topWall.localScale.y,topWall.localScale.z);
                }
                

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallprefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size/2, 0, 0);
                    leftWall.eulerAngles = new Vector3(0,90,0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                }

                if(i == width - 1)
                {
                    
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallprefab, transform) as Transform;
                        rightWall.position = position + new Vector3(size / 2, 0, 0);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                    }
                }
                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var downWall = Instantiate(wallprefab, transform) as Transform;
                        downWall.position = position + new Vector3(0, 0, -size / 2);
                        downWall.localScale = new Vector3(size, downWall.localScale.y, downWall.localScale.z);
                    }
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
