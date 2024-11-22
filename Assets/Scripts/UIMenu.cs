using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private bool closedByDefault = true;

    private void Awake()
    {
        if (closedByDefault)
        {
            GetComponent<Canvas>().enabled = false;
        }
    }

    public void OpenOptions()
    {
        GetComponent<Canvas>().enabled = true;
    }

    public void CloseOptions()
    {
        GetComponent<Canvas>().enabled = false;
    }

}
