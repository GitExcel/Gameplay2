using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{


    public GameObject trigger;
    public int linkvalue;
    private bool enter = false;
    public string direction;
    public bool move = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
            print("enter");
            


        }
       


        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdController>().push == true)
        {
            move = true;
            print("moving");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
            print("exit");

        }
    }



    private void Update()
    {

        
    }

    // Start is called before the first frame update

}
