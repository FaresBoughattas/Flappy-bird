using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BirdMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 5f;
    [SerializeField]
    public float flapForce = 20f;
    bool isDead;
    public GameObject unfreeze,replayButton;

    // Start is called before the first frame update
    void Start()
    {
        //Freeze time to wait for the player to press the button Play
        Time.timeScale = 0;
        //Get a reference to the RigidBody2D component
        rb2d = GetComponent<Rigidbody2D>();
        //Go right
        rb2d.velocity = Vector2.right * speed * Time.deltaTime; 

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        GetComponent<Animator>().SetBool("isDead", true);
        replayButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    // Wait for flap Input
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            //Reset Velocity
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
            //Add UP force to the bird
            rb2d.AddForce(Vector2.up * flapForce);
        }
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Unfreeze()
    {
        Time.timeScale = 1;
        unfreeze.SetActive(false); 
    }
    //declare an int variable named score 
    int score = 0;
    //Declare a public text variable
    public Text ScoreText;
     void OnTriggerEnter2D(Collider2D col)
     { 
        if (col.gameObject.tag == "Score")
        {
            //increment score
            score++;
            //show the score in the console 
            Debug.Log(score);
            //Update Text
            ScoreText.text = score.ToString();
        }

    
        
    }

}
