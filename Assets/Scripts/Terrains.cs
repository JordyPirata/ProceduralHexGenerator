using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrains
{
    public class Terrains : MonoBehaviour
    {
        [SerializeField] private int largo;
        [SerializeField] private int ancho;
        [SerializeField] private GameObject terrain;
        private float radio = 0.86602f;//Z
        private float altura = 1.5f;//X

        private void Start()
        {
            /*var instantiateZero = Instantiate(terrain);
            instantiateZero.transform.position = zero;

                var instantiate0 = Instantiate(terrain);
                instantiate0.transform.position = zero + new Vector3(0,0,radio*2);
                var instantiate1 = Instantiate(terrain);
                instantiate1.transform.position = zero + new Vector3(altura,0,radio);
                var instantiate2 = Instantiate(terrain);
                instantiate2.transform.position = zero + new Vector3(altura,0,radio*-1);
                var instantiate3 = Instantiate(terrain);
                instantiate3.transform.position = zero + new Vector3(0,0,radio*-2);
                var instantiate4 = Instantiate(terrain);
                instantiate4.transform.position = zero + new Vector3(altura*-1,0,radio*-1);
                var instantiate5 = Instantiate(terrain);
                instantiate5.transform.position = zero + new Vector3(altura*-1,0,radio);
                radio *= 2;
                altura *= 2;
            */
            float alturaAlter = 0;
            float radioAlter = 0;
            
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < largo; j++)
                {
                    var instantiateZero = Instantiate(terrain);
                    instantiateZero.transform.position = new Vector3(alturaAlter, 0, radioAlter);
                   

                    alturaAlter += (altura * 2);
                }
                radioAlter += radio;
                if ((i % 2) == 0)
                {
                    alturaAlter = altura;
                }
                else
                {
                    alturaAlter = 0;
                }
            }
        }

    }
}