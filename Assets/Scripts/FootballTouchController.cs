using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballTouchController : MonoBehaviour {
    public GameObject go;
    private Rigidbody rigidbody;
    private float xforcemultiplier;
    public float xForce = 60;
    public float yForce = 150;
	// Use this for initialization
	void Start () {
        rigidbody = go.GetComponent<Rigidbody>();
        Time.timeScale = 0f;
        StartCoroutine("time");
	}
	
	// Update is called once per frame
	void Update () {
    
    }

    IEnumerator time()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }

    private void OnMouseDown()
    {
        Vector3 mouspos = Input.mousePosition;
        if (leftOrRight(mouspos))
        {
            rigidbody.AddForce(new Vector3(xForce*xforcemultiplier, yForce, 0));
        }
        else
        {
            rigidbody.AddForce(new Vector3(-xForce*xforcemultiplier, yForce, 0));
        }

       
    }
    private bool leftOrRight(Vector3 mousePos)
    {
        Vector3 goPos = go.transform.position;
      
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100);
        Vector3 mousePosWorlView = hit.point;

        Debug.Log("Mousepos: " + mousePosWorlView.x);
        Debug.Log("GoPos: "+goPos.x);

        xforcemultiplier = Mathf.Abs(goPos.x - mousePosWorlView.x);
        
        if (mousePosWorlView.x < goPos.x)
        {
            return true;
        }

        return false;
    }
}
