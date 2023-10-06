using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private GameObject playerObj = null;
    // Start is called before the first frame update
    public void Face()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj.transform.position.x < transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(playerObj.transform.position.x > transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 360f, 0f);
        }
        else if(playerObj.transform.position.x == transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Face();
    }
}
