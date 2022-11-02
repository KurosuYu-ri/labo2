using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    // Start is called before the first frame update

    //private Rigidbody2D rbody2D;
    void Start()
    {
        //rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        Debug.Log("click ok");
        SceneManager.LoadScene("GameStartScene");
    }
    
}
