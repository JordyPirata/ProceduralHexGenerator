using Hexagons;
using System;
using UnityEngine;

namespace Terrains
{
    [System.Serializable]
    public class TerrainType
    {
        public string IdName;
        public float heigth;
    }
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField]
        public HexagonConfiguration _hexagonConfiguration;
        public int mapWidth;
        public int mapHeight;
        public float noiseScale;

        public int octaves;
        [Range(0, 1)]
        public float persistance;
        public float lacunarity;

        public int seed;
        public Vector2 offset;

        [SerializeField]
        private TerrainType[] terrainTypes;

        public bool AutoUpdate;

        private HexagonFactory _hexagonFactory;
        void Awake()
        {
            _hexagonFactory = new HexagonFactory(Instantiate(_hexagonConfiguration));
        }

        public void GenerateMap()
        {
            float[,] noiseMap = NoiseMapGeneration.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

            string[,] idMap = new string[mapWidth, mapHeight];

            for (int yIndex = 0; yIndex < mapHeight; yIndex++)
            {
                for (int xIndex = 0; xIndex < mapWidth; xIndex++)
                {
                    float height = noiseMap[xIndex, yIndex];

                    TerrainType terrainType = ChooseTerrainType(height);
                    idMap [xIndex, yIndex] = terrainType.IdName;
                }
            }

            float radio = 0.86602f;//Z
            float altura = 1.5f;//X

            float alturaAlter = 0;
            float radioAlter = 0;

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    var instantiateZero = _hexagonFactory.Create(idMap[x,y]);
                    instantiateZero.transform.position = new Vector3(alturaAlter, 0, radioAlter);


                    alturaAlter += altura * 2;
                }
                radioAlter += radio;
                if ((y % 2) == 0)
                {
                    alturaAlter = altura;
                }
                else
                {
                    alturaAlter = 0;
                }
            }
        }

        TerrainType ChooseTerrainType(float heigth)
        {
            foreach (TerrainType terrainType in terrainTypes)
            {
                if (heigth > terrainType.heigth)
                {
                    return terrainType;
                }
            }
            return terrainTypes[terrainTypes.Length - 1];
        }

        private void OnValidate()
        {
            if (mapWidth < 1)
            {
                mapWidth = 1;
            }
            if (mapHeight < 1)
            {
                mapHeight = 1;
            }
            if (lacunarity < 1)
            {
                lacunarity = 1;
            }
            if (octaves < 0)
            {
                octaves = 0;
            }

        }
    }
}