using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Control Script / Ray Shooter")]
public class RayShooter : MonoBehaviour
{

    private Camera _camera;
    
    [SerializeField]
    private GUIStyle style;
    
    [SerializeField]
    private Font font;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        style.font=font;
        style.fontSize = 30;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        	Vector3 point = new Vector3(
                _camera.pixelWidth / 2.0F, _camera.pixelHeight / 2.0F, 0.0F );
        	
        	Ray ray = _camera.ScreenPointToRay(point);
        	
        	RaycastHit hit;
        	if(Physics.Raycast(ray, out hit)){
        
                       //объект, в которвй попал луч 
        		GameObject hitObject = hit.transform.gameObject;
        		ReactiveTarget rt = hitObject.GetComponent<ReactiveTarget>();
        		if(rt != null ){
        		
        		    Debug.Log("Попал!!!");
        		    rt.reactToHit();
        		}
        		else{
        		    
        		    StartCoroutine(ShapeIndicator(hit.point));
        		}
        	}
        }	
    }
    
    private IEnumerator ShapeIndicator(Vector3 pos){
    
    	GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    	sphere.transform.position = pos;
    	
    	yield return new WaitForSeconds(1.5F);
    	
    	Destroy(sphere); 
    }
    
    void OnGUI(){
    
    	int size = 30;
    	
    	float posX = GetComponent<Camera>().pixelWidth / 2.0F - size * 0.25F;
    	float posY = GetComponent<Camera>().pixelHeight  / 2.0F - size * 0.75F;
    	
    	GUI.Label(
    		new Rect(posX, posY, size, size), "+", style);
    
    }
}
