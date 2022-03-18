using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMover2 : MonoBehaviour
{
    //[SerializeField]
    MyVector desplazamiento;
    [SerializeField]
    MyVector velocidad = new MyVector(0, 0);
    MyVector aceleracion=new MyVector(0,0);
    MyVector friccion = new MyVector(0, 0);
    MyVector atracciongrav = new MyVector(0, 0);
    
    [SerializeField]
    PhysicsMover2 other;
    // [SerializeField]
    // MyVector acum;
    [SerializeField]
    public float masa;
    [SerializeField]
    float bordex;
    [SerializeField]
    float bordey;
    float perdida = 0.9f;
    float grav = 1.0f;
    float escalar=0;
    [SerializeField]
    bool isStatic = false;
    

    void Start()
    {
    }

    private void Update()
    {
        if (isStatic)
            return;
        Vector2 r = other.transform.position-transform.position;
        MyVector re = new MyVector(r);
        var rnor = re.Normalizar();
        var rmag = re.Magnitud();
        escalar =other.masa * masa * grav*1;
        atracciongrav =(escalar/(rmag*rmag))*rnor;
        ApplyForce(atracciongrav);
         


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
