using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.SceneManagement;
public class _EnviromentMaster : _Master
{
    [Separator("Active Scene", true)]
    [SerializeField] [ReadOnly] private EnumsGame.Scenes m_ActiveScenes;
    [Separator("Open Scenes", true)]
    [SerializeField] [ReadOnly] private List<EnumsGame.Scenes> m_OpenScenes;


    public override void CustomInitializationAnex()
    {
        var ascene = EnumsGame.Scenes.SCN_GameMasters;
        m_OpenScenes.Add(ascene);
        m_ActiveScenes = ascene;
    }

    public void OpenSceneRemoveActiveScene(EnumsGame.Scenes sceneToOpen )
    {
        m_OpenScenes.Remove(m_ActiveScenes);
        SceneManager.LoadScene(sceneToOpen.ToString());
        m_ActiveScenes = sceneToOpen;
        m_OpenScenes.Add(sceneToOpen);
        //Implement Load Async?
    }
}
