using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartSceneScript : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickButton()
    {
        Debug.Log("click ok");
        SceneManager.LoadScene("City (Main scene)");
    }
}
