using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject EmptySpot1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bob(EmptySpot1);
    }

    void bob(GameObject lebron){
        Sphere.transform.position = Vector3.MoveTowards(Sphere.transform.position, lebron.transform.position, speed);
    }
}
