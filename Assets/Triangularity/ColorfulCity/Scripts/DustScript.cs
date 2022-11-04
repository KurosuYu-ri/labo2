using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 32.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
