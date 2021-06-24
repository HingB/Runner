using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectOnWay : MonoBehaviour
{
    public void Off()
    {
        gameObject.SetActive(false);
    }
}
