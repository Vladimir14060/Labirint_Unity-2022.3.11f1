using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class PlayerMobile : MonoBehaviour
{

    public float speed;
    private Rigidbody _rb;
    float mHor;
    float mVer;


    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    public void Up(){
        mVer = -1f;
    }
    public void Down(){
        mVer = 1f;
    }

    public void StopMVer(){
        mVer = 0f;
    }

    public void Left(){
        mHor = -1f;
    }
    public void Right(){
        mHor = 1f;
    }

    public void StopMHor(){
        mHor = 0f;
    }


    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(mVer, 0.0f, mHor);

        _rb.AddForce(movement * speed);

       

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /*
        if (this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            foreach (Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = false;
            }
        }
        */
    }

    /*
    private void onTriggerExit(Collider other)
    {
        if (this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            foreach (Activator button in FindObjectsOfType<Activator>())
            { 
                button.canPush = true;
            }
        }
    }
    */

}
