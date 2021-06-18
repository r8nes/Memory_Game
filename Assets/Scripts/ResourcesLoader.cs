using UnityEngine;

public class ResourcesLoader
{
    public Theme GetTheme(string themeName) {
        return Resources.Load<Theme>(themeName);
    }
}
