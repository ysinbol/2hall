using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMeteroiteArea : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Emit_meteroite")) return;

        Destroy(collision.gameObject);
    }
}
