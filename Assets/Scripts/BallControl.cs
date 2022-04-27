using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BallControl : MonoBehaviour
{
    private bool isFalling;
    public float gravity;
    public object canJump;
    public object stopdumbass;
    public object previousx;
    public virtual void Start()
    {
        PlayerPrefs.SetFloat("Swing", 0);
        PlayerPrefs.SetFloat("isFalling", 0);
        this.stopdumbass = false;
    }

    public virtual void Update()
    {

        {
            float _1 = //transform.Rotate(Vector3.right * PlayerPrefs.GetFloat("Swing"));
            PlayerPrefs.GetFloat("Swing");
            Vector3 _2 = this.GetComponent<Rigidbody>().velocity;
            _2.x = _1;
            this.GetComponent<Rigidbody>().velocity = _2;
        }

        {
            float _3 = this.GetComponent<Rigidbody>().velocity.y + (this.gravity * Time.deltaTime);
            Vector3 _4 = this.GetComponent<Rigidbody>().velocity;
            _4.y = _3;
            this.GetComponent<Rigidbody>().velocity = _4;
        }
        Time.timeScale = PlayerPrefs.GetInt("paused");
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < (Screen.width / 2))
            {
                PlayerPrefs.SetFloat("Swing", -4f);
            }
            else
            {
                if (Input.mousePosition.x >= (Screen.width / 2))
                {
                    PlayerPrefs.SetFloat("Swing", 4f);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                PlayerPrefs.SetFloat("Swing", 0);
            }
        }
        this.previousx = this.transform.position.x;
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "spikes")
        {
            PlayerPrefs.SetInt("Score", 0);
            Application.LoadLevel("MainMenu");
            Time.timeScale = 1;
        }
    }

    public BallControl()
    {
        this.gravity = -50;
    }

}