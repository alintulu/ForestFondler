using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode( )]
public class Anim : MonoBehaviour {

    class AnimSet {
        public string name;
        public int start, frames;
    }

    public Color color = Color.white;

    public float EXPOSURE { get { return exposure; } set { exposure = value; } }
    float exposure = 0.065f;
    // float exposure = 0.14f;

    public List<Sprite> sprites = new List<Sprite>( );

    public int idleframes = 2;

    public bool disableRenderer = true;
    public int rotationoffset = 0;
    public int sortingorder;
    public int lookdir = 1;
    public bool bottomPivot = false;
    public bool handleRotation = false;

    // particles need this to not have first frame be fucked. 
    public void SetZeroScale( ) { CreateRen( ); ren.transform.localScale = Vector2.zero; }

    void CreateRen( ) {
        if( ren != null ) return;
        GameObject g = new GameObject( "anim" );
        g.transform.SetParent( transform, false );
        ren = g.AddComponent<SpriteRenderer>( );
    }

    public SpriteRenderer REN { get { return ren; } }
    SpriteRenderer ren;
    List<AnimSet> anims = new List<AnimSet>( );

    public Vector2 ROT { get { return rotation; } set { rotation = value.normalized; } }
    Vector2 rotation = Vector2.up;
    public Vector2 TARROT { get { return targetrotation; } set { targetrotation = value.normalized; } }
    Vector2 targetrotation = Vector2.up;
    public Vector2 SCALE { get { return scale; } set { scale = value; } }
    Vector2 scale = Vector2.zero;
    Vector2 scalevel = Vector2.zero;
    public Vector2 TARSCALE { get { return targetscale; } set { targetscale = value; } }
    Vector2 targetscale = Vector2.one;
    public bool jiggleScale = true;

    float timer;
    AnimSet CURANIM { get { if( animindex > anims.Count + 1 ) return null; else return anims[ animindex ]; } }
    int animindex;
    int frame;

    public bool LOOPING { get { return looping; } }
    public bool ANIMDONE { get { return looped; } }
    bool looped = false;
    bool looping = true;

    void Awake( ) {
        if( !Application.isPlaying ) return;
        SpriteRenderer r = GetComponent<SpriteRenderer>( );
        r.enabled = false;

        CreateRen( );

        if( sprites.Count == 0 && r != null && r.sprite != null ) {
            sprites.Add( r.sprite );
        }

        if( idleframes > 0 ) AddAnim( 0, idleframes, "idle" );
    }

    void Start( ) {
        if( !Application.isPlaying ) return;
        scale = targetscale;
        timer = Random.Range( 0f, exposure ); 
    }

    void Update( ) {
        if( !Application.isPlaying ) {
            if( ren == null ) ren = GetComponent<SpriteRenderer>( );
            if( sprites.Count > 0 ) ren.sprite = sprites[ 0 ];
            ren.color = color;
            ren.sortingOrder = sortingorder;
            return;
        }
        if( CURANIM == null ) {
            print( "curanim null on " + name );
            return;
        }
        if( sprites.Count < CURANIM.start + CURANIM.frames ) {
            print( "out of range on sprites in " + name + ", anim: " + CURANIM.name );
            return;
        }

        timer += Time.deltaTime;
        if( timer > exposure ) {
            timer -= exposure;
            frame++;
            if( frame >= CURANIM.frames ) {
                if( looping ) frame = 0;
                else frame = CURANIM.frames - 1;
                looped = true;
            }
            setsprite( );
        }

        ren.transform.localScale = new Vector3( lookdir * scale.x, scale.y, 1 );
        if( bottomPivot ) {
            Vector2 pos = transform.position;
            float scaleRatio = scale.y / targetscale.y;
            ren.transform.position = pos + ROT.normalized * ( scaleRatio * ren.bounds.size.y - ren.bounds.size.y ) * .5f;
        }

        UpdateScale( );
        if( handleRotation ) {
            targetrotation = Uhh.VectorFromAngle( transform.rotation.eulerAngles.z );
        }
        //rotation = Vector2.Lerp( rotation, targetrotation, .175f );
        rotation = Vector2.Lerp( rotation, targetrotation, .425f * 60f * Time.deltaTime );

        ren.transform.rotation = Quaternion.Euler( 0, 0,
            Uhh.AngleFromVector( rotation ) + rotationoffset * lookdir );

        ren.color = color;
        ren.sortingOrder = sortingorder;
    }

    float jiggleSpeed = 64f;
    float jiggleLerp = 0.2f;
    void UpdateScale( ) {
        if( jiggleScale ) {
            // old scale lerp
            Vector2 totargetscale = targetscale - scale;
            scalevel = Vector2.Lerp( scalevel, totargetscale * jiggleSpeed, jiggleLerp );
            scale += scalevel * Time.deltaTime;

        } else {
            scale = Vector2.Lerp( scale, targetscale, .175f * 60f * Time.deltaTime );

        }
    }
    public void SetupJiggle( float speed, float lerpspeed ) {
        this.jiggleSpeed = speed;
        this.jiggleLerp = lerpspeed;
        jiggleScale = true;
    }

    void setsprite( ) {
        if( sprites != null && sprites.Count > CURANIM.start + frame ) {
            ren.sprite = sprites[ CURANIM.start + frame ];
        }
    }

    public void AddAnim( int start, int frames, string name ) {
        AnimSet a = new AnimSet( );
        a.name = name;
        a.frames = frames;
        a.start = start;
        anims.Add( a );

        setsprite( );
    }
    public string CURANIMNAME { get { return CURANIM.name; } }
    public void Load( string name, bool randomFrame = true, bool loop = true ) {
        if( CURANIM != null && CURANIM.name == name ) return;
        for( int i = 0; i < anims.Count; i++ ) {
            if( anims[ i ].name == name ) {
                animindex = i;
                if( randomFrame ) frame = Random.Range( 0, CURANIM.frames );
                else frame = 0;
                timer = exposure;
                looped = false;
                this.looping = loop;
                return;
            }
        }
    }
    public bool Contains( string name ) {
        for( int i = 0; i < anims.Count; i++ ) {
            if( anims[ i ].name == name ) return true;
        }
        return false;
    }
}
