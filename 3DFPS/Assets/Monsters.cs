using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Minibot;
    void Start()
    {

        GameObject Minibotprf = GameObject.Instantiate<GameObject>(Minibot, new Vector3(0, 0, 0), Quaternion.Euler(-90f, 0f, 0f));
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
