using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public static levelmanager main;

    public Transform startPoint;
    public Transform[] path;
    private void Awake()
    {
        main = this;
    }
}
