using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using OnScreenKeyboard;

namespace Editor
{

    [CustomEditor(typeof(Key), true)]
    public class KeyEditor : ButtonEditor
    {
        public override void OnInspectorGUI()
        {
            Key targetMyButton = (Key)target;
        
            targetMyButton.keyboard = (OnScreenKeyboard.OnScreenKeyboard)EditorGUILayout.ObjectField("Keyboard:", targetMyButton.keyboard, typeof(OnScreenKeyboard.OnScreenKeyboard), true);
            targetMyButton.label = (Text)EditorGUILayout.ObjectField("Label:", targetMyButton.label, typeof(Text), true);
 
            base.OnInspectorGUI();
        }
    }

    
}