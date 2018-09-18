using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver = true;
    public GameObject player;

    private HUD _hud;

   

    private void Start()
    {
        _hud = GameObject.Find("Canvas").GetComponent<HUD>();

    }

    public void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                _hud.hideTitle();

            }

        }
    }
 
}
