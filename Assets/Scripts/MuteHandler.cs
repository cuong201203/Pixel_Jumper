using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteHandler : MonoBehaviour
{
    public void MuteToggle(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
