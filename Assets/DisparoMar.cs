using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoMar : MonoBehaviour
{
 
    public GameObject arCamera;
    public GameObject explosion;

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)){
                if(hit.transform.tag == "Mariposa"){
                    Destroy(hit.transform.gameObject);
                    Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                    Destroy(explosion, 2f);
                }
            }
        }
    }
}
