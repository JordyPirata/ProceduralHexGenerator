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
                _hexagonFactory.Create("Speed");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _hexagonFactory.Create("Drunk");
            }
        }
    }
}