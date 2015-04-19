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
                GameCore.instance.onCityDamaged(col.collider.gameObject);
                break;                
            case "UFO":
                GameCore.instance.onUFODamaged();
                break;
            case "Human(Clone)":
                break;
            case "Rocket(Clone)":
            default:
                GameCore.instance.OnRocketDisabled();
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
