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
            var tempEntity = this.gameObject.GetEntityLink().entity;
            this.gameObject.Unlink();
            tempEntity.Destroy();
            Destroy(this.gameObject);

        }
    }
}
