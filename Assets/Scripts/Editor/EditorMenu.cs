using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class EditorMenu : MonoBehaviour
{
    [MenuItem("RollingBallScene/Scenes/StartScene")]
    static void EditorMenu_LoadStartScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StartScene.unity");
    }

    [MenuItem("RollingBallScene/Scenes/UIScene")]
    static void EditorMenu_LoadUIScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/UIScene.unity");
    }

    [MenuItem("RollingBallScene/Scenes/StartGameScene")]
    static void EditorMenu_LoadStartGameScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StartGameScene.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage1")]
    static void EditorMenu_LoadStage1()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage1.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage2")]
    static void EditorMenu_LoadStage2()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage2.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage3")]
    static void EditorMenu_LoadStage3()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage3.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage4")]
    static void EditorMenu_LoadStage4()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage4.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage5")]
    static void EditorMenu_LoadStage5()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage5.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage6")]
    static void EditorMenu_LoadStage6()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage6.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage7")]
    static void EditorMenu_LoadStage7()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage7.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage8")]
    static void EditorMenu_LoadStage8()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage8.unity");
    }

    [MenuItem("RollingBallScene/StageScenes/Stage9")]
    static void EditorMenu_LoadStage9()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/StageScene/Stage9.unity");
    }

    [MenuItem("RollingBallScene/AddBallStageScenes/AddBallStage1")]
    static void EditorMenu_LoadAddBallStage1()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/AddBallScene/AddBallStage1.unity");
    }

    [MenuItem("RollingBallScene/AddBallStageScenes/AddBallStage2")]
    static void EditorMenu_LoadAddBallStage2()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/AddBallScene/AddBallStage2.unity");
    }

    [MenuItem("RollingBallScene/AddBallStageScenes/AddBallStage3")]
    static void EditorMenu_LoadAddBallStage3()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/AddBallScene/AddBallStage3.unity");
    }

    [MenuItem("RollingBallScene/AddBallStageScenes/AddBallStage4")]
    static void EditorMenu_LoadAddBallStage4()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/AddBallScene/AddBallStage4.unity");
    }
}