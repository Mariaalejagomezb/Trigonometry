using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbita : MonoBehaviour
{
    [SerializeField]
    Transform otherbolita;
    //[SerializeField]
    MyVector desplazamiento;
    [SerializeField]
    MyVector velocidad = new MyVector(2, 2);
    [SerializeField]
    MyVector aceleracion;
    // [SerializeField]
    // MyVector acum;
    [SerializeField]
    float bordex;
    [SerializeField]
    float bordey;
    float perdida = 0.9f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //CheckCollisions();
        Draw();
    }
    public void Move()
    {
        var posicion = new MyVector(transform.position.x, transform.position.y);
        var otrabolita = new MyVector(otherbolita.position.x, otherbolita.position.y);
        aceleracion = otrabolita - posicion;
        velocidad = velocidad + (aceleracion * Time.deltaTime);
        desplazamiento = velocidad * Time.deltaTime;
        //acum = acum + desplazamiento;
        transform.position = transform.position + desplazamiento;

    }
    public void Draw()
    {
        var posicion = new MyVector(transform.position.x, transform.position.y);
        posicion.Draw(Color.blue);
        velocidad.Draw(posicion, Color.red);
        aceleracion.Draw(posicion, Color.black);

    }
    private void CheckCollisions()
    {
        if (transform.position.x >= bordex || transform.position.x <= -bordex)
        {
            velocidad.x = -velocidad.x * perdida;
        }
        else if (transform.position.y >= bordey || transform.position.y <= -bordey)
        {
            velocidad.y = -velocidad.y * perdida;
        }
        else if (transform.position.y == bordey && transform.position.x == bordex)
        {
            velocidad.y = -velocidad.y * perdida;
            velocidad.x = -velocidad.x * perdida;
        }
        if (transform.position.y < -bordey)
        {
            transform.position = new MyVector(transform.position.x, -bordey);

        }
        else if (transform.position.y > bordey)
        {
            transform.position = new MyVector(transform.position.x, bordey);
        }
        else if (transform.position.x < -bordex)
        {
            transform.position = new MyVector(-bordex, transform.position.y);
        }
        else if (transform.position.x > bordex)
        {
            transform.position = new MyVector(bordex, transform.position.y);
        }
    }
}
