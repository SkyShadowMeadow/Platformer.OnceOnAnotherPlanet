using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaxPool : MonoBehaviour
{
    protected List<GameObject> _waxPool = new List<GameObject>();

    protected void InstantiatePool(GameObject waxBlobPrefab, int poolSize, Transform container)
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject waxBlob = Instantiate(waxBlobPrefab, container);
            waxBlob.gameObject.SetActive(false);
            _waxPool.Add(waxBlob);
        }
    }

    protected GameObject GetWaxBlob() 
    {
        GameObject waxBlob = _waxPool.FirstOrDefault(p => p.activeSelf == false);
        return waxBlob;
    }

}
