using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguidor : MonoBehaviour
{
    
    MyVector velocidad = new MyVector(0, 0);
    MyVector desplazamiento;
    [SerializeField]
    [Range(0, 5)]
    float f;

    void Start()
    {

    }

    void Update()
    {
        MyVector mousepos = MousePosition();
        MyVector transformpos = new MyVector(transform.position);
        MyVector dif = mousepos - transformpos;
        var nordif = dif.Normalizar();
        velocidad = nordif*f ;
        velocidad.Draw(transformpos, Color.blue);
        desplazamiento = velocidad * Time.deltaTime;
        transform.position = transform.position + desplazamiento;
        float radio = Mathf.Atan2(dif.y, dif.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radio * Mathf.Rad2Deg);
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
