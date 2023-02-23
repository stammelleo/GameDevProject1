using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{

    public int score;
    public GameObject pauseObject;
    public TMP_Text scoreCounter;
    private bool countdown;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countdown = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // The f explicitly states that number is a float NOT a double
        float speed = 20f * Time.deltaTime;
        //if (Input.GetKey(KeyCode.UpArrow))
        //{

        //   transform.position += new Vector3(0, 0, speed);
        //}
        float horizMove = Input.GetAxisRaw("Horizontal") * speed; 
        float vertMove = Input.GetAxisRaw("Vertical") * speed; 
        transform.position += new Vector3(horizMove, 0, vertMove);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) 
        { 
            countdown = true;
        }

        if (countdown) 
        { if (timer < 3) 
            {
                timer += Time.deltaTime; 
            } else {
                UnityEditor.EditorApplication.isPlaying = false; 
            } 
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        float newX = Random.Range(-7, 7);
        Debug.Log(newX);
        float newZ = Random.Range(-3, 3);
        Debug.Log(newZ);
        // add 1 to y because it defaults to -1, then subtract 10 to z because of the 10 default
        other.transform.position = new Vector3(newX, 0 + 1, newZ - 10);
        // other.transform.position = new Vector3(0, 0, 0); GOES TO 0,-1,10
        ++score;
        scoreCounter.text = "Score: " + score;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger currently active");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger left");
    }

}
