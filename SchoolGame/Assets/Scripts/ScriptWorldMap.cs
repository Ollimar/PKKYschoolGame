using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptWorldMap : MonoBehaviour 
{

    Vector3 hitPosition = Vector3.zero;
    Vector3 currentPosition = Vector3.zero;
    Vector3 cameraPosition = Vector3.zero;

    public Transform pointerMetalliala;
    public Transform pointerTeatteriEsitek;

    public float pointerTimer = 1f;
    public float pointerSpeed = 1f;
    public bool pointerToggle = false;

    public Canvas metallialaImage;
    public Canvas teatterEsitekImage;
    public GameObject menu;

    public Text playerName;

    public Animator MetallialaAnim;
    public Animator teatterEsitekAnim;

    public float zoomSpeed = .5f;
    public float minZoom = 11f;
    public float maxZoom = 4f;

    private ScriptPlayerData playerData;

	void Start () 
    {
        metallialaImage.enabled = false;
        MetallialaAnim = GameObject.Find( "MetallialaImage" ).GetComponent<Animator>();

        teatterEsitekImage.enabled = false;
        teatterEsitekAnim = GameObject.Find( "TeatterEsitekImage" ).GetComponent<Animator>();

        menu = GameObject.Find( "Menu" );
        menu.SetActive(false);

        playerData = GameObject.Find( "PlayerData" ).GetComponent<ScriptPlayerData>();
        playerName.text = playerData.name.ToString();
        
	}
	
	void Update () 
     {

        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) 
        {
            if ( hit.transform.tag == "Metalliala" ) 
            {
                if(Input.GetMouseButtonDown(0)) 
                {
                    metallialaImage.enabled = true;
                    MetallialaAnim.SetBool( "Touched", true );
                }
            }

             if ( hit.transform.name == "Teatteri&Esitystekniikka" ) 
            {
                if(Input.GetMouseButtonDown(0)) 
                {
                    teatterEsitekImage.enabled = true;
                    teatterEsitekAnim.SetBool( "Touched", true );
                }
            }

         if ( hit.transform.tag == "ground" && Input.touchCount <= 1) 
            {
                if(Input.GetMouseButtonDown(0)) 
                {
                    hitPosition = Input.mousePosition;
                    cameraPosition = new Vector3(transform.position.x,Camera.main.transform.position.y,transform.position.z);
                    print( "Touch" );
                }

                if(Input.GetMouseButton(0)) 
                {
                    currentPosition = Input.mousePosition;
                    Drag();
                    print( "Touch" );
                }
            }
        }

        //Camera Zoom

        if(Input.touchCount == 2) 
        {
            Touch touchZero = Input.GetTouch( 0 );
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = ( touchZero.position - touchOne.position ).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

            Camera.main.orthographicSize += deltaMagnitudediff * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Min( Camera.main.orthographicSize, minZoom );
            Camera.main.orthographicSize = Mathf.Max( Camera.main.orthographicSize, maxZoom );
        }

        // Map pointer code

        pointerTimer -= Time.deltaTime;

        if(!pointerToggle) 
        {
            pointerSpeed = 1f;
        }

        if(pointerToggle)  
        {
            pointerSpeed = -1f;
        }

        if(pointerTimer <= 0f) 
        {
            pointerToggle = !pointerToggle;
            pointerTimer = 0.5f;
        }

        pointerMetalliala.Translate(Vector3.up*pointerSpeed*Time.deltaTime);
        pointerTeatteriEsitek.Translate(Vector3.up*pointerSpeed*Time.deltaTime);
	}

    void Drag() {
        Vector3 direction = Camera.main.ScreenToWorldPoint(currentPosition) - Camera.main.ScreenToWorldPoint(hitPosition);
        direction = direction * -1;
        Vector3 position = cameraPosition + direction;
        transform.position = new Vector3(position.x,Camera.main.transform.position.y,position.z);
    }

    public void MenuOpen() 
    {
        menu.SetActive( true );
    }

    public void MenuClose() 
    {
        menu.SetActive( false );
    }

    public void closeMetalliala() 
    {
           metallialaImage.enabled = false;
           MetallialaAnim.SetBool( "Touched", false );
    }

    public void EnterMetalliala() 
    {
        Application.LoadLevel("Metalliala");
    }
}
