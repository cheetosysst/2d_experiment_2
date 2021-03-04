using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float playerSpeed = 0.1f;
    public float playerSpeedSlow = 0.1f;
    bool playerSlowMode = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player \""+name+"\" init");
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.0f, 1.0f);
        pos.y = Mathf.Clamp(pos.y, 0.0f, 1.0f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        if (Input.GetKey(KeyCode.LeftShift)) {
            playerSlowMode = true;
        } else {
            playerSlowMode = false;
        }
        if (Input.GetKey(KeyCode.Z)) {
            print("Shoot");
        }
        if (Input.GetKey(KeyCode.X)) {
            print("Bomb");
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            this.gameObject.transform.position += new Vector3(playerSlowMode?playerSpeedSlow:playerSpeed, 0 ,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.gameObject.transform.position += new Vector3(playerSlowMode?-playerSpeedSlow:-playerSpeed, 0 ,0);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            this.gameObject.transform.position += new Vector3(0, playerSlowMode?playerSpeedSlow:playerSpeed ,0);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            this.gameObject.transform.position += new Vector3(0, playerSlowMode?-playerSpeedSlow:-playerSpeed ,0);
        }
    }
}
