using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaMouse : MonoBehaviour
{
    MyVector aceleracion = new MyVector(0, 0);
    MyVector velocidad = new MyVector(0, 0);
    MyVector desplazamiento;
    

    void Start()
    {

    }

    void Update()
    {
        MyVector mousepos = MousePosition();
        MyVector transformpos = new MyVector(transform.position);
        MyVector dif = mousepos - transformpos;
        var nordif = dif.Normalizar();
        aceleracion = nordif;
        velocidad += aceleracion*Time.deltaTime;
        transform.position += velocidad * Time.deltaTime;
        float radio = Mathf.Atan2(velocidad.y, velocidad.x);
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
