using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFixer : MonoBehaviour
{

    [SerializeField] bool _enabled = false;
    [SerializeField] bool deleteAll = false;
    [SerializeField] int _frameRate = 50;
    private void Awake()
    {
        Application.targetFrameRate = _frameRate;

        if (_enabled)
        {
            if (deleteAll)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
            }
            PlayerPrefs.DeleteKey("Screenmanager Resolution Height Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Width Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Height");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Width");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Use Native Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Use Native");
            PlayerPrefs.Save();
        }

    }

    public void OnApplicationQuit()
    {
        if (_enabled)
        {
            if (deleteAll)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
            }
            PlayerPrefs.DeleteKey("Screenmanager Resolution Height Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Width Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Height");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Width");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Use Native Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Use Native");
            PlayerPrefs.Save();
            Debug.Log("OnApplicationQuit");
        }

    }

    public void OnDestroy()
    {
        if (_enabled)
        {
            if (deleteAll)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
            }
            PlayerPrefs.DeleteKey("Screenmanager Resolution Height Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Width Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Height");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Width");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Use Native Default");
            PlayerPrefs.DeleteKey("Screenmanager Resolution Use Native");
            PlayerPrefs.Save();
            Debug.Log("OnDestroy");
        }

    }
}
