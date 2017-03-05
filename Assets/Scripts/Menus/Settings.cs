using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour {

    private float horizontalLookSpeed = 100f;
    private float verticalLookSpeed = 100f;

    public float VerticalLookSpeed
    {
        get
        {
            return verticalLookSpeed;
        }

        set
        {
            verticalLookSpeed = value;
            Save();
        }
    }

    public float HorizontalLookSpeed
    {
        get
        {
            return horizontalLookSpeed;
        }

        set
        {
            horizontalLookSpeed = value;
            Save();
        }
    }

    public void Start()
    {
        Load();
    }

    public void Save()
    {
        File.WriteAllText(Application.dataPath + "/settings.json", JsonUtility.ToJson(this));
    }

    public void Load()
    {
        JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.dataPath + "/settings.json"), this);
    }
}
