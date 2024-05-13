using UnityEngine;

namespace WizardGame.Common
{
    public class GpuInstansingEnabler : MonoBehaviour
    {
        private void Awake()
        {
            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.SetPropertyBlock(materialPropertyBlock);
        }
    }
}
