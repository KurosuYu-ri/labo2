using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerGenerator : MonoBehaviour
{
    public GameObject criminal;
    public GameObject walker;
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
        if(peaple <= 5)
        {
         GameObject item;
         int dice = Random.Range(0, 1);
         if(dice == 0)
         {
            //�ƍߕ��s
            item = Instantiate(criminal);
         }
         else 
         {
                //���s��
            item = Instantiate(walker);
         }
     
            this.peaple++;

        }
      
     
    }
}
