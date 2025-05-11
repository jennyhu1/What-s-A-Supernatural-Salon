using UnityEngine;

public class Pimple : MonoBehaviour
{
    public GameObject popEffect;

    private void OnMouseDown()
    {
        if (!ToolManager.Instance.IsNeedleActive())
            return;

        if (popEffect != null)
        {
            Instantiate(popEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
