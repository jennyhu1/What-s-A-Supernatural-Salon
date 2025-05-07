using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;
    public Texture2D needleCursor;
    private bool needleActive = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivateNeedle()
    {
        needleActive = true;
        Cursor.SetCursor(needleCursor, new Vector2(needleCursor.width / 2, needleCursor.height / 2), CursorMode.Auto);
    }

    public bool IsNeedleActive()
    {
        return needleActive;
    }
}
