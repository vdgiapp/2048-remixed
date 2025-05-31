using UnityEngine;

namespace Remixed2048
{
    public class Utils
    {
        public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
        {
            position.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(position);
        }
        
        public static GameObject[] GetDontDestroyOnLoadObjects()
        {
            GameObject temp = null;
            try
            {
                temp = new GameObject();
                Object.DontDestroyOnLoad(temp);
                UnityEngine.SceneManagement.Scene dontDestroyOnLoad = temp.scene;
                Object.DestroyImmediate(temp);
                temp = null;
                return dontDestroyOnLoad.GetRootGameObjects();
            }
            finally
            {
                if(temp) Object.DestroyImmediate(temp);
            }
        }
    }
}