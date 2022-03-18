using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polares : MonoBehaviour
{


    [SerializeField]
    MyVector polarcord;
    MyVector cero = new MyVector(0, 0);
    [SerializeField]
    float rapidezradial;
    [SerializeField]
    float rapidezangular;
    [SerializeField]
    float bordex;
    [SerializeField]
    float bordey;
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        polarcord.x += rapidezradial * Time.deltaTime;
        polarcord.y += rapidezangular * Time.deltaTime;
        if (polarcord.x >= bordex || polarcord.x <= -bordex)
        {
            rapidezradial *= -1;
        }
        else if (polarcord.x == 0)
        {
            rapidezradial *= -1;
        }
        var cartesiana = PolarACartesiano(polarcord);
        cartesiana.Draw(Color.red);
        transform.position = cartesiana;
     

    }
    private MyVector PolarACartesiano(MyVector polar)
    {
        float r = polarcord.x;
        float theta = polarcord.y;
        float cos = Mathf.Cos(theta);
        float sen = Mathf.Sin(theta);
        var cartesiana = new MyVector(r * cos, r * sen);
        return cartesiana;
    }
    

}

