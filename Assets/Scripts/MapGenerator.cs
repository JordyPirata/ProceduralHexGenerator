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
        public enum DrawMode { NoiseMap, StringMap }; 
        public DrawMode drawMode;

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
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _hexagonFactory.Create("CurveRiver");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _hexagonFactory.Create("Desert");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _hexagonFactory.Create("Grass");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _hexagonFactory.Create("Jungle");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _hexagonFactory.Create("Rocks");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                _hexagonFactory.Create("MiniPines");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                _hexagonFactory.Create("MiniSnowyPines");
            }
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

            MapDisplay display = FindObjectOfType<MapDisplay>();
            if (drawMode == DrawMode.NoiseMap)
            {
                display.DrawNoiseMap(noiseMap);
            }
            else if (drawMode == DrawMode.StringMap)
            {
                 
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