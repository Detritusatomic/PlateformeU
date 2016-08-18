
function quitGame() {
    Application.Quit();
}

function goMenu() {
    Time.timeScale = 1;
    objects = FindObjectsOfType(typeof(GameObject));
    for each(go in objects)
    {
        go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
    }
    Application.LoadLevel("menu");
}

function restart() {
    Time.timeScale = 1;    
    Application.LoadLevel(Application.loadedLevelName);
}