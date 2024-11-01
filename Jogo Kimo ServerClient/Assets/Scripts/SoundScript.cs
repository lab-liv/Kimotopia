using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {


    public static SoundScript Instance;

    // sons a serem reproduzidos
    public AudioClip remedioSound;
    public AudioClip monstroSound;
    public AudioClip appleSound;
    public AudioClip carrotSound;
    public AudioClip hamburgerSound;
    public AudioClip higieneSound;
    public AudioClip sujeiraSound;
    public AudioClip cakeSound;
    public AudioClip icecreamSound;
    public AudioClip pumpkinSound;
    public AudioClip bananaSound;
    public AudioClip candySound;
  

    void Awake()
    {
        if(Instance!=null) //erro
        {
            Debug.LogError("Erro");
        }
        Instance = this; //atribui
    }

    //metodo do som do remedio
    public void MakeRemedioSound()
    {
		
        MakeSound(remedioSound);
    }

    // metodo do som do monstro
    public void MakeMonstroSound()
    {
        MakeSound(monstroSound);
    }

    // metodo do som da apple
    public void MakeAppleSound()
    {
		
        MakeSound(appleSound);
    }

    // metodo do som da carrot
    public void MakeCarrotSound()
    {
        MakeSound(carrotSound);
    }

    // metodo do som do hamburger
    public void MakeHamburgerSound()
    {
        MakeSound(hamburgerSound);
    }

    // metodo do som da higiene
    public void MakeHigieneSound()
    {
        MakeSound(higieneSound);
    }

    // metodo do som da sujeira
    public void MakeSujeiraSound()
    {
        MakeSound(sujeiraSound);
    }

    // metodo do som da banana
    public void MakeBananaSound()
    {
        MakeSound(bananaSound);
    }

    // metodo do som do cake
    public void MakeCakeSound()
    {
        MakeSound(cakeSound);
    }

    // metodo do som do candy
    public void MakeCandySound()
    {
        MakeSound(candySound);
    }

    // metodo do som do pumpkin
    public void MakePumpkinSound()
    {
        MakeSound(pumpkinSound);
    }

    // metodo do som do icecream
    public void MakeIcecreamSound()
    {
        MakeSound(icecreamSound);
    }


    // metodo que reproduz som
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
