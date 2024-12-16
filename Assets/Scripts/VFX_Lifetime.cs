using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Lifetime : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroyVFX", 2f);
    }

    private void DestroyVFX()
    {
        Destroy(gameObject);
    }
}
