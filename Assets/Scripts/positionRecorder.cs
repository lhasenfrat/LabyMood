using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
public class positionRecorder : MonoBehaviour
{
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;

    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private int id = 0;
    StreamWriter writer;
    bool available = true;
    int i = 0;
    bool leftA;
    bool rightA;
    void Start()
    {

        id=PlayerPrefs.GetInt("currentid");
        int seed = PlayerPrefs.GetInt("seed");
        string condition = PlayerPrefs.GetString("condition");
        var csvFileName = $"{id}-{condition}-{seed}.csv";
        string basePath = Path.Combine(Application.persistentDataPath, csvFileName);
        writer = new StreamWriter(basePath);
        writer.WriteLine("time;xpos;zpos");
        
    }

    private void Update()
    {
        leftA = leftController.activateInteractionState.active;
        rightA = rightController.activateInteractionState.active;
        if(leftA && rightA)
        {
            i += 1;

        } else
        {
            i = 0;
        }
        if (i > 40)
        {
            available = false;
            Close();
        }
        if (available)
        {
            writer.WriteLine($"{Time.timeSinceLevelLoad};{transform.position.x};{transform.position.z}");

        }
    }

    void Close()
    {
        writer.Close();
        SceneManager.LoadScene("MainMenu");
    }
    public void NormalEnd()
    {
        available = false;
        Close();
    }

}

