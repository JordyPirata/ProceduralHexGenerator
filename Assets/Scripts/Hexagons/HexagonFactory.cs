using Object = UnityEngine.Object;

namespace Hexagons
{
    public class HexagonFactory
    {
        private readonly HexagonConfiguration _hexagonConfiguration;

        public HexagonFactory(HexagonConfiguration HexagonConfiguration)
        {
            _hexagonConfiguration = HexagonConfiguration;
        }

        public Hexagon Create(string id)
        {
            var Hexagon = _hexagonConfiguration.GetHexagonPrefabById(id);
            return Object.Instantiate(Hexagon);
        }
    }
}