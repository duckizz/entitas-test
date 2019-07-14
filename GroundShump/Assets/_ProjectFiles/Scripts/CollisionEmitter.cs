using Entitas;
using UnityEngine;

public class CollisionEmitter : MonoBehaviour
{

    public string targetTag;




    void OnCollisionEnter2D(Collision2D col)
    {
    
         if (col.gameObject.CompareTag(targetTag))
        {
            var thisEntity = col.gameObject.GetEntityLink().entity;
            col.gameObject.Unlink();
            thisEntity.Destroy();
            Destroy(col.gameObject);
            Destroy(this.gameObject);

        }
    }
}
