using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{

    public Transform[] BGs;
    public int nextBGIndex { get; set; }

    void Start()
    {
        nextBGIndex = BGs.Length;
    }

    void Update()
    {

    }
}
