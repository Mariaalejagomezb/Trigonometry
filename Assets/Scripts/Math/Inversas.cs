using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inversas : MonoBehaviour
{


    
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        MyVector mousepos = MousePosition();
        //float pendiente = mousepos.y / mousepos.x;
        //float radio = Mathf.Atan(pendiente);
        MyVector transformpos = new MyVector(transform.position);
        MyVector dif = mousepos - transformpos;
        float radio = Mathf.Atan2(dif.y,dif.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radio* Mathf.Rad2Deg);
        
        
        //transform.localPosition = MousePosition();
        

    }
    
    private MyVector MousePosition()
    {
        Camera camara = Camera.main;
        Vector2 screenpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camara.nearClipPlane);
        Vector2 worldpos = Camera.main.ScreenToWorldPoint(screenpos);
        MyVector mundopos = new MyVector(worldpos);
        mundopos.Draw(Color.red);
        return (mundopos);
    }
    

}

