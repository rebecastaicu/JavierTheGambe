using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LanzadorCoco))]
public class LanzadorCocoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Dibuja el inspector por defecto

        LanzadorCoco script = (LanzadorCoco)target;
        if (GUILayout.Button("Iniciar Lanzamiento"))
        {
            script.IniciarLanzamiento(); // Llama a la funci�n IniciarLanzamiento del script LanzadorCoco
        }

        if (GUILayout.Button("Detener Lanzamiento"))
        {
            script.DetenerLanzamiento(); // Llama a la funci�n DetenerLanzamiento del script LanzadorCoco
        }
    }
}

