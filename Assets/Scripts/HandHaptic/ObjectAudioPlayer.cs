using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAudioPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
