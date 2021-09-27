using UnityEngine;

namespace Arcanoid.Views
{
    public abstract class BaseTile : MonoBehaviour
    {
        private Color _color;

        private void Awake()
        {
            _color = GetComponent<MeshRenderer>().material.color;
        }

        protected virtual void SetScale(float x, float y)
        {
            transform.localScale.Set(x, y, 0f);
        }

        protected virtual void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        protected virtual void SetColor(Color color)
        {
            _color = color;
        }

        protected virtual void Enable(bool enable)
        {
            gameObject.SetActive(enable);
        }

    }
}
