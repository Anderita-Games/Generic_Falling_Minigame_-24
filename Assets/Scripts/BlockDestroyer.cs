using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BlockDestroyer : MonoBehaviour
{
    public virtual void Update()
    {
        if ((PlayerPrefs.GetInt("Score") * -1) < (this.gameObject.transform.position.y - 10))
        {
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

}