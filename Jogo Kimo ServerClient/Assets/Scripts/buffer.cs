using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class buffer : MonoBehaviour
{
    CommandBuffer cmd = new CommandBuffer();
    // Start is called before the first frame update
    void Awake()
    {
        cmd.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
