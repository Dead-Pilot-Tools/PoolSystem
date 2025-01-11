using System;
using UnityEngine;

namespace DeadPilotTools.PoolSystem.runtime
{
    public class SimplePoolable : PoolableMonoBehaviour
    {
        [Header("Relase When:")]
        [SerializeField] private bool _collide;
        [SerializeField] private TypeCollisionCheck _collisionType;

        [Header("Validation:")]
        [SerializeField] private TypeValidationCheck _validationType;
        [SerializeField, Layer] private int _layer;
        [SerializeField, TagMaskField] private string _tag;


        private void OnValidate()
        {
            if (!_collide)
                _collisionType = TypeCollisionCheck.none;
        }

        private void ReleaseIfValidated(GameObject go)
        {
            if (_validationType == TypeValidationCheck.layer && go.layer != _layer)
                return;

            if (_validationType == TypeValidationCheck.tag && go.tag != _tag)
                return;

            this.Release();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_collisionType != TypeCollisionCheck.onCollisionEnter) return;

            ReleaseIfValidated(collision.gameObject);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (_collisionType != TypeCollisionCheck.onCollisionExit) return;

            ReleaseIfValidated(collision.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_collisionType != TypeCollisionCheck.onCollisionEnter2D) return;

            ReleaseIfValidated(collision.gameObject);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (_collisionType != TypeCollisionCheck.onCollisionExit2D) return;

            ReleaseIfValidated(collision.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_collisionType != TypeCollisionCheck.onTriggerEnter) return;

            ReleaseIfValidated(other.gameObject);
        }
        private void OnTriggerExit(Collider other)
        {
            if (_collisionType != TypeCollisionCheck.onTriggerExit) return;

            ReleaseIfValidated(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_collisionType != TypeCollisionCheck.onTriggerEnter2D) return;

            ReleaseIfValidated(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_collisionType != TypeCollisionCheck.onTriggerExit2D) return;

            ReleaseIfValidated(collision.gameObject);
        }
    }

    [Serializable]
    public enum TypeCollisionCheck
    {
        none,
        onCollisionEnter,
        onCollisionExit,
        onCollisionEnter2D,
        onCollisionExit2D,
        onTriggerEnter,
        onTriggerExit,
        onTriggerEnter2D,
        onTriggerExit2D
    }

    [Serializable]
    public enum TypeValidationCheck
    {
        layer,
        tag
    }
}
