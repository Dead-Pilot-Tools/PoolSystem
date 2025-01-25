using UnityEngine;

namespace DeadPilotTools.PoolSystem.runtime
{
    public class PooledParticleSystem : PoolableMonoBehaviour
    {
        private ParticleSystem system;

        private void Awake()
        {
            system = GetComponent<ParticleSystem>();
            var main = system.main;
            main.stopAction = ParticleSystemStopAction.Callback;
        }

        private void OnParticleSystemStopped()
        {
            this.Release();
        }
    }
}
