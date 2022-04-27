using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GameMaster : MonoBehaviour
{
    public UnityEngine.UI.Text CTime;
    public UnityEngine.UI.Text HTime;
    public bool paused;
    public GameObject Tpaused;
    public GameObject Ball;
    public GameObject cameras;
    public GameObject Sides; // The Walls
    public int Score;
    public float setter; //para background
    public float Speeder;
    public int MaxBlocks;
    public int BlockNumber;
    public GameObject SpawnBlock;
    public System.Collections.Generic.List<float> AmountArray;
    public GameObject original;
    public float YLocation;
    public float Rando;
    public virtual void Start()
    {
        PlayerPrefs.SetInt("paused", 1);
        Time.timeScale = PlayerPrefs.GetInt("paused");
        this.YLocation = -2;
    }

    public virtual void Update()
    {
        //Score Stuff
        this.Score = (int) (this.Ball.transform.position.y * -1);
        this.CTime.text = " Current Score: " + this.Score;
        PlayerPrefs.SetInt("Score", this.Score);
        this.HTime.text = "High Score: " + PlayerPrefs.GetInt("Best");
        if (this.Score > PlayerPrefs.GetInt("Best"))
        {
            PlayerPrefs.SetInt("Best", this.Score);
        }
        if (PlayerPrefs.GetInt("paused") != 0)
        {
            this.Speeder = this.Speeder * 1.0001f;

            {
                float _5 = this.cameras.transform.position.y - (0.01f * this.Speeder);
                Vector3 _6 = this.cameras.transform.position;
                _6.y = _5;
                this.cameras.transform.position = _6;
            }

            {
                float _7 = this.Ball.transform.position.y;
                Vector3 _8 = this.Sides.transform.position;
                _8.y = _7;
                this.Sides.transform.position = _8;
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            if (PlayerPrefs.GetInt("paused") == 1)
            {
                Debug.Log("Pausing...");
                PlayerPrefs.SetInt("paused", 0);
                Time.timeScale = PlayerPrefs.GetInt("paused");
                this.Tpaused.SetActive(true);
            }
            else
            {
                if (PlayerPrefs.GetInt("paused") == 0)
                {
                    Debug.Log("Pausing...");
                    PlayerPrefs.SetInt("paused", 1);
                    Time.timeScale = PlayerPrefs.GetInt("paused");
                    this.Tpaused.SetActive(false);
                }
            }
        }
        float Amount = 8f;
        if (this.Ball.transform.position.y < (this.YLocation + 15))
        {
            while (Amount > 0) //CREATING THE BLOCKS
            {
                this.Rando = (-27f + (Random.Range(0, 9) * 6f)) / 4f; //MATH BIOTCH!!
                while (this.AmountArray.Contains(this.Rando))
                {
                    this.Rando = (-27f + (Random.Range(0, 9) * 6f)) / 4f;
                }
                this.AmountArray.Add(this.Rando);
                this.SpawnBlock = UnityEngine.Object.Instantiate(this.original, new Vector3(this.Rando, this.YLocation, -0.5f), Quaternion.identity);
                this.BlockNumber++;
                this.SpawnBlock.name = "Block #" + this.BlockNumber;
                Amount--;
            }
            this.AmountArray.Clear();
            this.YLocation = ((this.YLocation * 2f) - 9f) / 2f;
        }
        Time.timeScale = PlayerPrefs.GetInt("paused"); // Set pause or naw
    }

    public virtual void MainMenu()
    {
        Application.LoadLevel("MainMenu");
        this.paused = false;
        Time.timeScale = 1;
    }

    public GameMaster()
    {
        this.Speeder = 1;
        this.AmountArray = new List<float>();
    }

}