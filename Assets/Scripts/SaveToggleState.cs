using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveToggleState : MonoBehaviour
{
    public Toggle MusicToggle;

    public void Start()
    {
        if (AudioListener.pause == false)
            MusicToggle.isOn = true;
        else
            MusicToggle.isOn = false;
    }
}

