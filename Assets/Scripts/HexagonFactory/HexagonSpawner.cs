using UnityEngine;

namespace Hexagons
{
    public class HexagonSpawner : MonoBehaviour
    {
        [SerializeField]
        public HexagonConfiguration _hexagonConfiguration;
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
    }
}