using System;
using Hexagons;
using UnityEngine;

namespace Terrains
{
    public class CreateTerrainMap : MonoBehaviour
    {
        [SerializeField] private MapGenerator mapGenerator;
        [SerializeField] private SpawnerTerrain spawner;
        [SerializeField] private float offsetHeight;
        private void Start()
        {
            var map = mapGenerator.GenerateMap();
            
            float radio = 0.86602f;//Z
            float altura = 1.5f;//X

            float alturaAlter = 0;
            float radioAlter = 0;
            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Hexagon byHeight;
                    try
                    {
                        byHeight = spawner.CreateByHeight(map[i, j]);
                    }
                    catch (Exception e)
                    {
                        Debug.Log($"{e.Message}");
                        byHeight = spawner.CreateById("1");
                    }
                    byHeight.transform.position = new Vector3(alturaAlter, map[i, j] * offsetHeight, radioAlter);
                    alturaAlter += altura * 2;
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