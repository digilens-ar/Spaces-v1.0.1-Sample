using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    /// <summary>
    /// Increase sphere scale
    /// </summary>
    public void Grow()
    {
        transform.localScale *= 1.25f;
    }

    /// <summary>
    /// Decrease sphere scale
    /// </summary>
    public void Shrink()
    {
        transform.localScale /= 1.25f;
    }

}
