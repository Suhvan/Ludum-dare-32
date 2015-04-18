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

     
        switch(col.collider.gameObject.name)
        {
            case "Houses":
                GameCore.instance.onCityDamaged();
                break;
            case "Rocket(Clone)":
                GameCore.instance.onExplosionStack();
                break;
            case "UFO":
                GameCore.instance.onUFODamaged();
                break;
            default:
                GameCore.instance.OnRocketDisabled();
                Debug.Log(string.Format("Collision with {0}", col.collider.gameObject.name));
                break;

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
