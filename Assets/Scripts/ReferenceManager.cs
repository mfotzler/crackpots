using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    static ReferenceManager instance;
    public GameObject pots;

    public static GameObject Pots => instance.pots;
    void Awake()
    {
        instance = this;
    }
}
