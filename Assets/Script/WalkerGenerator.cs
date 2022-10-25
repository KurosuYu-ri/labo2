using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    public GameObject criminal_;
    public GameObject walker_;

    public Transform[] spawn_;
    /*  public GameObject walker;
      public GameObject walker;
      public GameObject walker;*/
    private int peaple = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(peaple < 50)
        {
         GameObject item;
         int dice = Random.Range(0, 21);
         if(dice % 2 == 0)
         {
            //”Æß•às
            item = Instantiate(criminal_);
         }
         else 
         {
                //•àsŽÒ
            item = Instantiate(walker_);
         }

            int ranSpawn = Random.Range(0, 10);
            item.transform.position = spawn_[ranSpawn].position;
            this.peaple++;

        }
      
     
    }
}
