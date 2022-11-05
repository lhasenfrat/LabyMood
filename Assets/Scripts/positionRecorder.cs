using System.IO;
using UnityEngine;

public class positionRecorder : MonoBehaviour
{
    [SerializeField] private int id = 0;
    StreamWriter writer;
    bool available = true;
    int i = 0;
    void Start()
    {
        var csvFileName = $"{id}.csv";
        string basePath = Path.Combine(Application.persistentDataPath, csvFileName);
        writer = new StreamWriter(basePath);
        writer.WriteLine("id;time;xpos;zpos");
        
    }

    private void Update()
    {
        i += 1;
        if (i > 1000)
        {
            available = false;
            Close();
        }
        if (available)
        {
            writer.WriteLine($"{id};{Time.timeSinceLevelLoad};{transform.position.x};{transform.position.z}");

        }
    }

    void Close()
    {
        writer.Close();

    }
}