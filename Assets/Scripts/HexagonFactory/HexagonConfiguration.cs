using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagons
{
    [CreateAssetMenu(menuName = "Custom/Hexagon configuration")]
    public class HexagonConfiguration : ScriptableObject
    {
        [SerializeField] private Hexagon[] _hexagons;
        private Dictionary<string, Hexagon> _idToHexagon;
        private void Awake()
        {
            _idToHexagon = new Dictionary<string, Hexagon>();
            foreach (var hexagon in _hexagons)
            {
                _idToHexagon.Add(hexagon.id, hexagon);
            }
        }
        public Hexagon GetHexagonPrefabById(string id)
        {
            if (!_idToHexagon.TryGetValue(id, out Hexagon hexagon))
            {
                throw new Exception($"Hexagon with id {id} does not exist");
            }
            return hexagon;
        }

    }
}