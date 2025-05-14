using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TapEffect : MonoBehaviour
{
    public ParticleSystem tapEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            var pos = new Vector3(-6.0f, -8.5f, -8.5f);
            Instantiate(tapEffect, pos, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            var pos = new Vector3(-2.0f, -8.5f, -8.5f);
            Instantiate(tapEffect, pos, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            var pos = new Vector3(2.0f, -8.5f, -8.5f);
            
            Instantiate(tapEffect, pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            var pos = new Vector3(6.0f, -8.5f, -8.5f);
            Instantiate(tapEffect, pos, Quaternion.identity);
        }
    }
}
