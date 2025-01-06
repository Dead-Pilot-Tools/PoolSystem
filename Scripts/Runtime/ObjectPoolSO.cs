using UnityEngine;
using UnityEngine.Pool;

namespace DeadPilotTools.PoolSystem.runtime
{
    [CreateAssetMenu(fileName = "ObjectPoolSO", menuName = "Dead Pilot Tools/Pool", order = 0)]
    public class ObjectPoolSO : ScriptableObject
    {
        public PoolableMonoBehaviour prefab;
        public int defaultCapacity = 5;
        public Vector3 defaultSpawnLocation;
        public bool useDefaultSpawnRotation;
        public Quaternion defaultSpawnRotation;

        private ObjectPool<PoolableMonoBehaviour> objectPool;

        private void OnEnable()
        {
            objectPool = new ObjectPool<PoolableMonoBehaviour>(
                CreatePooledObject,
                OnTakeFromPool,
                OnReturnPool,
                OnDestroyObject,
                false,
                defaultCapacity);
        }

        private PoolableMonoBehaviour CreatePooledObject()
        {
            PoolableMonoBehaviour pm = Instantiate(prefab, defaultSpawnLocation, useDefaultSpawnRotation ? defaultSpawnRotation : Quaternion.identity);
            pm.gameObject.SetActive(true);
            pm.RegisterPool(this);
            pm.OnObjectPoolCreate();
            return pm;
        }

        private void OnTakeFromPool(PoolableMonoBehaviour pm)
        {
            pm.gameObject.SetActive(true);
            pm.OnObjectPoolTake();
        }

        private void OnReturnPool(PoolableMonoBehaviour pm)
        {
            pm.OnObjectPoolReturn();
            pm.gameObject.SetActive(false);
        }

        private void OnDestroyObject(PoolableMonoBehaviour pm)
        {
            pm.OnObjectPoolDestroy();
            Destroy(pm);
        }

        public PoolableMonoBehaviour Get()
        {
            return objectPool.Get();
        }

        public void Release(PoolableMonoBehaviour pm)
        {
            objectPool.Release(pm);
        }

        public PoolableMonoBehaviour PostGet(object data)
        {
            PoolableMonoBehaviour pm = objectPool.Get();
            pm.OnPostGet(data);

            return pm;
        }
    }
}
