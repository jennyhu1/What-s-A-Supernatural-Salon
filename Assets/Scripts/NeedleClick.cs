using UnityEngine;

public class NeedleClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
        ToolManager.Instance.ActivateNeedle();
    }
}
