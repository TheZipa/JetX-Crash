using Aviator.Code.Core.UI.Gameplay.BetPanel;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

namespace Aviator.Code.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BetInputField))]
    public class BetInputFieldEditor : TMP_InputFieldEditor
    {
        private SerializedProperty _wrongBetView;
        private SerializedProperty _wrongBetSprite;
        private SerializedProperty _betText;

        protected override void OnEnable()
        {
            base.OnEnable();
            _wrongBetView = serializedObject.FindProperty("_wrongBetView");
            _wrongBetSprite = serializedObject.FindProperty("_wrongBetSprite");
            _betText = serializedObject.FindProperty("_betText");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.PropertyField(_wrongBetView, new GUIContent("Wrong Bet Text"));
            EditorGUILayout.PropertyField(_wrongBetSprite, new GUIContent("Wrong Bet Sprite"));
            EditorGUILayout.PropertyField(_betText, new GUIContent("User Bet"));
            serializedObject.ApplyModifiedProperties();
        }

    }
}