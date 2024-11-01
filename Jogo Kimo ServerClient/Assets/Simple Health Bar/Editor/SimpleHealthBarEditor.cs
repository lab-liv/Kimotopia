using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.AnimatedValues;

[CanEditMultipleObjects]
[CustomEditor( typeof( SimpleHealthBar ) )]
public class SimpleHealthBarEditor : Editor
{
	SimpleHealthBar targ;

	// ----->>> IMAGE 
	AnimBool ImageAssigned, ImageUnassigned;
	AnimBool ImageFilledWarning;
	SerializedProperty barImage;

	// ---- < SCRIPT REFERENCE > ---- //
	AnimBool ExampleCode;
	enum FunctionList
	{
		UpdateBar

	}
	FunctionList functionList = FunctionList.UpdateBar;
	string exampleCode;

	// ----->>> TEST VALUE //
	float testValue = 100.0f;

	string barName = "healthBar";


	void OnEnable ()
	{
		// Store the references to all variables.
		StoreReferences();

		// Register the UndoRedoCallback function to be called when an undo/redo is performed.
		Undo.undoRedoPerformed += UndoRedoCallback;

		if( targ != null && targ.barImage != null )
			testValue = targ.barImage.fillAmount * 100.0f;
	}

	void OnDisable ()
	{
		// Remove the UndoRedoCallback from the Undo event.
		Undo.undoRedoPerformed -= UndoRedoCallback;
	}

	// Function called for Undo/Redo operations.
	void UndoRedoCallback ()
	{
		// Re-reference all variables on undo/redo.
		StoreReferences();
	}

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical("Box");

        // ----- < BAR NAME > ----- //
        if (barName == string.Empty && Event.current.type == EventType.Repaint)
        {
            GUIStyle style = new GUIStyle(GUI.skin.textField);
            style.normal.textColor = new Color(0.5f, 0.5f, 0.5f, 0.75f);
            EditorGUILayout.TextField(new GUIContent("Bar Name", "The unique name to be used in reference to this bar."), "Bar Name", style);
        }
        else
        {
            EditorGUI.BeginChangeCheck();
            barName = EditorGUILayout.TextField(new GUIContent("Bar Name", "The unique name to be used in reference to this bar."), barName);
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                ExampleCode.target = barName != string.Empty;
                GenerateExampleCode();
            }
        }
        // ----- < END BAR NAME > ----- //

        // ----- < NAME ERRORS > ----- //
        if (EditorGUILayout.BeginFadeGroup(ExampleCode.faded))
        {
            GUILayout.Space(1);

            EditorGUILayout.LabelField("Public Variable", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Copy this variable declaration into your custom scripts.", EditorStyles.wordWrappedLabel);
            EditorGUILayout.TextField("public SimpleHealthBar " + barName + ";");

            EditorGUILayout.LabelField("Example Code Generator", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Please choose the function that you want to use. Afterward, copy and paste the provided code into your scripts where you want to display a status to the user.", EditorStyles.wordWrappedLabel);
            EditorGUI.BeginChangeCheck();
            functionList = (FunctionList)EditorGUILayout.EnumPopup("Function", functionList);
            if (EditorGUI.EndChangeCheck())
                GenerateExampleCode();

            EditorGUILayout.TextField(exampleCode);

            GUILayout.Space(1);
        }
        EditorGUILayout.EndFadeGroup();
        // ----- < END NAME ERRORS > ----- //

        EditorGUILayout.EndVertical();

        // ----- < BAR IMAGE > ----- //
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(barImage, new GUIContent("Bar Image", "The image component to be used for this bar."));
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            if (targ.barImage != null && targ.barImage.type != Image.Type.Filled)
            {
                targ.barImage.type = Image.Type.Filled;
                targ.barImage.fillMethod = Image.FillMethod.Horizontal;
                EditorUtility.SetDirty(targ.barImage);
            }
            if (targ.barImage != null)
            {
                
                serializedObject.ApplyModifiedProperties();
            }
            targ.UpdateBar(testValue, 100.0f);

            ImageFilledWarning.target = GetBarImageWarning();
            ImageAssigned.target = GetImageAssigned();
            ImageUnassigned.target = GetImageUnassigned();
        }

        if (EditorGUILayout.BeginFadeGroup(ImageUnassigned.faded))
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.HelpBox("Image is unassigned.", MessageType.Warning);
            if (GUILayout.Button("Find", EditorStyles.miniButton))
            {
                barImage.objectReferenceValue = targ.GetComponent<Image>();
                serializedObject.ApplyModifiedProperties();
                if (targ.barImage != null)
                {
                    if (targ.barImage.type != Image.Type.Filled)
                    {
                        targ.barImage.type = Image.Type.Filled;
                        targ.barImage.fillMethod = Image.FillMethod.Horizontal;
                        EditorUtility.SetDirty(targ.barImage);
                    }

                    serializedObject.ApplyModifiedProperties();
                }

                ImageFilledWarning.target = GetBarImageWarning();
                ImageAssigned.target = GetImageAssigned();
                ImageUnassigned.target = GetImageUnassigned();
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndFadeGroup();
        // ----- < END BAR IMAGE > ----- //

    }
	 void StoreReferences ()
	{
		targ = ( SimpleHealthBar ) target;

		ImageAssigned = new AnimBool( GetImageAssigned() );
		ImageUnassigned = new AnimBool( GetImageUnassigned() );
		ImageFilledWarning = new AnimBool( GetBarImageWarning() );
		barImage = serializedObject.FindProperty( "barImage" );


		// ---- < SCRIPT REFERENCE > ---- //
		ExampleCode = new AnimBool( barName != string.Empty );

		GenerateExampleCode();
	}

	bool GetImageAssigned ()
	{
		if( targ.barImage != null )
			return true;
		return false;
	}

	bool GetImageUnassigned ()
	{
		if( targ.barImage == null )
			return true;
		return false;
	}

	bool GetBarImageWarning ()
	{
		if( targ.barImage != null && targ.barImage.type != Image.Type.Filled )
			return true;
		return false;
	}

	bool GetColorWarning ()
	{
		if( Application.isPlaying == true )
			return false;

		if( targ.barImage == null )
			return false;

		
		return false;
	}

	void GenerateExampleCode ()
	{
		switch( functionList )
		{
			default:
			case FunctionList.UpdateBar:
			{
				exampleCode = barName + ".UpdateBar( current, max );";
			}
			break;
			
		}
	}
}