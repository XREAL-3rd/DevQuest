
using UnityEngine;
/* shooting by mousebutton, setting target's hp=5, get info about mouseposition and direction, destroy target,
make an effect orthogonally against plane */
public class ObjectDestroyer : MonoBehaviour
{
    public GameObject bulletEffect;
    ParticleSystem ps;
    private RaycastHit hit;

    void Start()
    {
       ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 100f));
            Vector3 direction = worldMousePosition - Camera.main.transform.position;
            
            Ray ray = new Ray(Camera.main.transform.position, direction);
            
            if(Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
               /* if(hit.collider.tag == "Target")
                    {
                        
                        hp -= 1;
                        if(hp==0)
                        {
                        Destroy(hit.collider.gameObject);
                        hp = 5;
                        }
                    }
                    */
                    if (hit.collider.tag == "Target"){
                        hit.collider.GetComponent<TargetControl>().Hit(ray);
                        }
            }
            else
            {
                Debug.DrawLine(Camera.main.transform.position, worldMousePosition, Color.red, 0.5f);
            }
            
            if(Physics.Raycast(ray, out hit))
            {
                bulletEffect.transform.position = hit.point;
                bulletEffect.transform.forward = hit.normal; 

                ps.Play();
            }
        }
    }
}
