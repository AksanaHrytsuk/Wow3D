using UnityEngine;

public class PullPlatformButton : Button
{
    [Header("Components")]
    public Platform _platform;

    public override void ActionOne()
    {
        _platform.Move();
    }
    #region LogError

    void Start()
    {
        // вывод сообщения, если ссылка не задана
        if (_platform == null)
        {
            Debug.LogError("Block is not set");
        }
    }

    #endregion
}
