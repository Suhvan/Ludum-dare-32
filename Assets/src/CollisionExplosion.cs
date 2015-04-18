using UnityEngine;
using System.Collections;

public class CollisionExplosion : MonoBehaviour {

    //
    [SerializeField]
    GameObject ExplosionPref;

    //
    void OnCollisionEnter2D( Collision2D col )
    {
        Debug.Log( string.Format( "Collision with {0}", col.collider.gameObject.name ) );
        Explode( col.contacts[ 0 ].point );
        Destroy( gameObject );
    }


    //
    void Explode( Vector2 pos )
    {
        Instantiate( ExplosionPref, pos, new Quaternion( 0, 0, 0, 0 ) );
    }
}
