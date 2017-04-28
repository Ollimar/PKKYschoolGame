using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Minipeli1TeatteriJaEsitystekniikka : MonoBehaviour {

    public GameObject star1;
    public ParticleSystem sawParticle;
    public GameObject[] touchTrails;
    public GameObject winStar;

    public GameObject placeButton;

    public float zoomSpeed = .5f;
    public Vector3 maxZoom;
    public Vector3 minZoom;

    public GameObject pauseImage;
    public Animator pauseAnim;

    public int phase = 1;

	// Use this for initialization
	void Start () 
    {

		sawParticle.enableEmission = false;
        touchTrails = GameObject.FindGameObjectsWithTag( "CutLine" );
        winStar.SetActive( false );
        star1 = GameObject.Find("Star1");
        placeButton = GameObject.Find( "placeButton" );
        placeButton.SetActive( true );
        pauseAnim = GameObject.Find( "PauseImage" ).GetComponent<Animator>();
        pauseImage.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        print( Input.touchCount );
        if(phase <2) 
        {

        if(Input.touchCount > 0) 
        {

        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );

        if(!EventSystem.current.IsPointerOverGameObject()) 
        {
        if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) ) 
        {
            if ( hit.transform.name == "Vaneri" ) 
            {
                star1.transform.position = hit.point;
            }

           }	
        }
        }

        if(Input.touchCount == 2) 
        {
                if ( !EventSystem.current.IsPointerOverGameObject() ) 
                {
                                Touch touchZero = Input.GetTouch( 0 );
                                Touch touchOne = Input.GetTouch(1);

                                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                                float touchDeltaMag = ( touchZero.position - touchOne.position ).magnitude;

                                float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

                                star1.transform.localScale -= new Vector3(star1.transform.localScale.x,star1.transform.localScale.y,star1.transform.localScale.z)*deltaMagnitudediff * zoomSpeed;

                                if(star1.transform.localScale.x>maxZoom.x) 
                                    {
                                        star1.transform.localScale = maxZoom;
                                    }
                                else if(star1.transform.localScale.x<minZoom.x) 
                                    {
                                        star1.transform.localScale = minZoom;
                                    }
                                //star1.transform.localScale = Mathf.Min( star1.transform.localScale, 1f );
                                //star1.transform.localScale = Mathf.Max( star1.transform.localScale, 10f );
                }
            }
        }

        if(phase > 1) 
        {
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );

        if(Input.touchCount > 0) 
        {
        if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) ) 
        {
            if ( hit.transform.tag == "CutLine" ) 
            {
                sawParticle.transform.position = hit.point;
                sawParticle.enableEmission = true;
                print("Cut");

                hit.transform.gameObject.SetActive( false );
                touchTrails = GameObject.FindGameObjectsWithTag( "CutLine" );
            }
            else 
            {
                sawParticle.enableEmission = false;
            }
        }	
        }

        if(touchTrails.Length == 0) {
            print( "Win!" );
            winStar.SetActive( true );
            winStar.GetComponent<Animator>().SetBool("Win",true);
        }
        }
	}

    public void Place() {
        print( "Phase2" );
        phase = 2;
    }

    public void Pause() 
    {
         pauseImage.SetActive(true);
         pauseAnim.SetBool("Touched",true);
    }

    public void Quit() {
        Application.LoadLevel("TeatteriJaEsitystekniikka");
    }
}
