using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{

    [SerializeField] private string path;
    [SerializeField] private LineRenderer lineRenderer;
    String[] lineData;
    // Start is called before the first frame update
    void Start()
    {
        var fileData = System.IO.File.ReadAllText(path);
        lineData  = fileData.Split("\n"[0]);
        Draw();
    }

    private void Draw()
    {

        lineRenderer.transform.position =  CreateVector3(lineData[1]);


        lineRenderer.positionCount = lineData.Length;
        for (int i = 1; i < lineData.Length; i++)
        {
            lineRenderer.SetPosition(i, CreateVector3(lineData[i]));
        }
    }
    Vector3 CreateVector3(String line)
    {
        String[] currentline = (line.Trim()).Split(";"[0]);
        print(currentline);
        return new Vector3(float.Parse(currentline[2]), 0,float.Parse(currentline[3]));
    }
}
