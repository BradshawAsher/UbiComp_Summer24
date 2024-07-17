using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public List<Color> Colours;
    public GameObject Plane1;
    public int num1;
    public GameObject Sphere;
    public int pos;
    // Start is called before the first frame update
    void Start()
    {
        num1 = Random.Range(0, Colours.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Sphere.transform.position.z <= pos)){
            if (Colours.Count > 0){
                Color c = Colours[num1];
                GetComponent<Renderer>().material.color = c;
            }   
        }
        if ((num1==0)&&(Input.GetKeyDown(KeyCode.A))&&(Sphere.transform.position.z <= pos)){
            Destroy(Plane1);
        }
        if ((num1==1)&&(Input.GetKeyDown(KeyCode.S))&&(Sphere.transform.position.z <= pos)){
            Destroy(Plane1);
        }
        if ((num1==2)&&(Input.GetKeyDown(KeyCode.D))&&(Sphere.transform.position.z <= pos)){
            Destroy(Plane1);
        }
        if ((num1==3)&&(Input.GetKeyDown(KeyCode.F))&&(Sphere.transform.position.z <= pos)){
            Destroy(Plane1);
        }
    }
}
