using System;
using UnityEngine;
using UnityEngine.Events;

namespace DeadPilotTools.PoolSystem.runtime
{
    public abstract class PoolableMonoBehaviour : MonoBehaviour
    {
        public UnityAction<PoolableMonoBehaviour> onRelease;

        private ObjectPoolSO pool;

        public void RegisterPool(ObjectPoolSO pool)
        {
            this.pool = pool;
        }

        public void Release()
        {
            if (pool != null)
            {
                this.pool.Release(this);
            }

            if (onRelease != null)
            {
                onRelease(this);
                onRelease = null;
            }
        }

        public virtual void OnObjectPoolCreate() { }
        public virtual void OnObjectPoolTake() { }
        public virtual void OnObjectPoolReturn() { }
        public virtual void OnObjectPoolDestroy() { }
        public virtual void OnPostGet(object data) { }

        public bool IsDataTypeRequired(object data, Type type)
        {
            bool isTypeRequired = (data.GetType() == type);
            if (!isTypeRequired)
                Debug.LogError($"WRONG DATATYPE!.\r\n data:{data} is {data.GetType()}, should be {type}");

            return isTypeRequired;
        }
    }

}
