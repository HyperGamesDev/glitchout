using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag_NotMulti : MonoBehaviour{
    void Start(){if(FindObjectOfType<NetworkController>()==null){Destroy(gameObject);}}
}
