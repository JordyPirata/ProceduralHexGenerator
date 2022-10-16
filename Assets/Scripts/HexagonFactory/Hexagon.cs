using UnityEngine;

namespace Hexagons
{
    public abstract class Hexagon : MonoBehaviour
    {
        [SerializeField]
        public string _id;
        public string Id => _id;

    }
}