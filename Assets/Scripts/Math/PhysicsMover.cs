using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMover : MonoBehaviour
{
    //[SerializeField]
    MyVector desplazamiento;
    //[SerializeField]
    MyVector velocidad = new MyVector(0, 0);
    MyVector aceleracion=new MyVector(0,0);
    MyVector friccion = new MyVector(0, 0);
    // [SerializeField]
    // MyVector acum;
    [SerializeField]
    private float masa=1;
    [SerializeField]
    float bordex;
    [SerializeField]
    float bordey;
    float perdida = 0.9f;
    float gravedad = -9.8f;
    [SerializeField]
    [Range (0,1)]
    float coefriccion;
    

    void Start()
    {

    }

    private void Update()
    {
        ApplyForce(new MyVector(0.0f,masa*gravedad));
        //ApplyForce(new MyVector(1.0f, 0.0f));
        if (transform.position.y < 0)
        {
            var velnormal = velocidad.Normalizar();

            friccion = -coefriccion * velnormal*10.0f;
            ApplyForce(friccion);
        }
       

        Move();
        CheckCollisions();
        Draw();
        aceleracion = new MyVector(0, 0);
       
        


    }

    public void Move()
    {
        velocidad = velocidad + (aceleracion * Time.deltaTime);
        desplazamiento = velocidad * Time.deltaTime;
        //acum = acum + desplazamiento;
        transform.position = transform.position + desplazamiento;

    }
    public void Draw()
    {
        var posicion = new MyVector(transform.position.x, transform.position.y);
        //posicion.Draw(Color.blue);
        velocidad.Draw(posicion, Color.red);
        //aceleracion.Draw(posicion, Color.black);
        friccion.Draw(posicion, Color.yellow);

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
    private void ApplyForce(MyVector fuerza)
    {
        aceleracion += fuerza *(1/ masa);
        
        
        
    }
}
