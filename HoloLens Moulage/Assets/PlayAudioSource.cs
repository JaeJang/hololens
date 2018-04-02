using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour, IInputClickHandler
// Use this for initialization
{
    #region IInputClickHandler
    public void OnInputClicked(InputClickedEventData eventData)
    {
        GetComponent<AudioSource>().Play();
    }
    #endregion IInputClickHandler 
}
