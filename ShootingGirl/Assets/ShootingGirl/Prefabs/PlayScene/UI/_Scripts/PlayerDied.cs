using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    [SerializeField]private PlayerDiedPanel _playerDiedPanel;

    private void OnEnable()
    {
        GlobalEventManager.DiedModelEvent.AddListener(CheckExistPlayerModel);
    }
    private void OnDisable()
    {
        GlobalEventManager.DiedModelEvent.RemoveListener(CheckExistPlayerModel);
    }

    private void CheckExistPlayerModel()
    {
        int countDiedPlayerModel = 0;

        foreach (AbsPlayerBaseModetState item in PlayerModelSwitcher.s_playerModelStateDictionary.Values)
        {
            if (item.isDied)
                countDiedPlayerModel++;
        }

        if (countDiedPlayerModel == PlayerModelSwitcher.s_playerModelStateDictionary.Values.Count)
            PlayerDie();
    }

    private void PlayerDie()
    {
        GlobalEventManager.DiedPlayerEvent?.Invoke();
        _playerDiedPanel.gameObject.SetActive(true);
    }
}
