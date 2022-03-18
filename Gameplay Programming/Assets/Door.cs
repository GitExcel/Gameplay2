using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject buttonconnect;
    public GameObject camera1;
    public GameObject playercam;
    private Vector3 doorpos;
    public float speed;
    public Vector3 movedistance;
    public float timer;
    private float timerstart;
    private bool completed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timerstart = timer;

        if (movedistance.y == 0)
        {
            movedistance.y = transform.position.y;
        }
        if (movedistance.z == 0)
        {
            movedistance.z = transform.position.z;
        }
        if (movedistance.x == 0)
        {
            movedistance.x = transform.position.x;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (buttonconnect.GetComponent<Button>().move == true && !completed)
        {
            transform.position = Vector3.MoveTowards(transform.position, movedistance, Time.deltaTime * speed);
            player.GetComponent<ThirdController>().cutscene = true;
            playercam.SetActive(false);
            camera1.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                player.GetComponent<ThirdController>().cutscene = false;
                buttonconnect.GetComponent<Button>().move = false;
                player.GetComponent<ThirdController>().move = false;
                timer = timerstart;
                playercam.SetActive(true);
                camera1.SetActive(false);
                completed = true;
                

            }
            else
            {

                doorpos = transform.position;
            }

        }
    }
}

