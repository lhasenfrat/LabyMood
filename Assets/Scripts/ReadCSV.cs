using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class ReadCSV : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private string path;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject Maze;

    String[] lineData;
    // Start is called before the first frame update

    private void Awake()
    {
        var fileData = System.IO.File.ReadAllText(path);
        lineData = fileData.Split("\n"[0]);
        LoadMaze();
    }
    void Start()
    {
        ComputeMatrix();
        Draw();
    }

    void LoadMaze()
    {
        PlayerPrefs.SetInt("seed", Int32.Parse(path.Split("-")[2].Split(".")[0]));

    }
    void ComputeMatrix()
    {
        List<Vector4> matrixlist = new List<Vector4>();

        int i = 1;
        int maxi = 0;
        Vector3 lastLine = new Vector3();
        for (int j = 1; j < lineData.Length-1; j++)
        {
            Vector3 currentLine = CreateVector3(lineData[j]);
            if (currentLine != lastLine)
            {
                matrixlist.Add(new Vector4(lastLine.x,lastLine.y,lastLine.z,i) );
                if (i > maxi)
                {
                    maxi = i;
                }
                i = 1;
               
            } else
            {
                i++;
            }
            lastLine = currentLine;
        }
        for(int j = 0; j < matrixlist.Count; j++)
        {
            matrixlist[j] = new Vector4(matrixlist[j].x,matrixlist[j].y,matrixlist[j].z, matrixlist[j].w / (float)maxi);
            

        }
        LoadHMMaterial(matrixlist);
    }

    void LoadHMMaterial(List<Vector4> list)
    {
        material.SetInt("_Points_Length", list.Count);
        material.SetVectorArray("_Points", list);
    }

    void Draw()
    {

        lineRenderer.transform.position =  CreateVector3(lineData[1]);


        lineRenderer.positionCount = lineData.Length;
        for (int i = 1; i < lineData.Length-1; i++)
        {
            lineRenderer.SetPosition(i, CreateVector3(lineData[i]));
        }
    }
    Vector3 CreateVector3(String line)
    {
        String[] currentline = (line.Trim()).Split(";"[0]);
        return new Vector3(float.Parse(currentline[1]), 0,float.Parse(currentline[2]));
    }
}
