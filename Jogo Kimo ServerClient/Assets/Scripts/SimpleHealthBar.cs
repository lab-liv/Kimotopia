using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[AddComponentMenu( "UI/Simple Health Bar/Simple Health Bar" )]
public class SimpleHealthBar : MonoBehaviour
{	
    
	public Image barImage; //barrinha de vida

	float _currentFraction = 1.0f; // % da barrinha cheia
	
    // get fracao de vida atual
	public float GetCurrentFraction
	{
		get { return _currentFraction; }
	}

	float _maxValue = 10.0f; // maior valor da barrinha

	float targetFill = 10.0f; // preenchimeto da barrinha


	#region PUBLIC FUNCTIONS

	public void UpdateBar ( float currentValue, float maxValue ) // muda % de vida
	{
		
		if( barImage == null ) // vazio
			return;
			
		
        _currentFraction = currentValue / maxValue; //fracao (%) de vida para mudar na barrinha
        //print(_currentFraction);

		targetFill = _currentFraction;
        //print(targetFill);
		
		_maxValue = maxValue;

		barImage.fillAmount = targetFill; // atualizacao de % da barrinha

	}//updateBar

	#endregion
}