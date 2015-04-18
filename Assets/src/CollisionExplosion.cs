using UnityEngine;
using System.Collections;

public class CollisionExplosion : MonoBehaviour {

    //
    [SerializeField]
    GameObject ExplosionPref;

    public float armDelay;

    private float spawnTime;

    //
    void Start()
    {
        spawnTime = Time.time;
    }

    //
    void OnCollisionEnter2D( Collision2D col )
    {
        if (armDelay + spawnTime > Time.time)
            return;

        Debug.Log( string.Format( "Collision with {0}", col.collider.gameObject.name ) );
        if (col.collider.gameObject.name.StartsWith("Houses"))
        {
            GameCore.instance.onCityDamaged();
        }
        Explode( col.contacts[ 0 ].point );
        Destroy( gameObject );
    }

    void OnCollisionStay2D(Collision2D col)
    {
        OnCollisionEnter2D(col);
    }


    //
    void Explode( Vector2 pos )
    {
        Instantiate( ExplosionPref, pos, new Quaternion( 0, 0, 0, 0 ) );
    }
}
