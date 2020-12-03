using UnityEngine;

public class Frequences : MonoBehaviour
{

    private static Frequences _instance;

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    //todo: vérifier si la comparaison stirng est pas trop lourde, si besoin changer pour des int
    public float GetFrequence(int accord, string note)
    {
        switch (accord)
        {
            case 1:
                return getNoteOfI(note);
            case 2:
                return getNoteOfII(note);
            case 3:
                return getNoteOfIII(note);
            case 4:
                return getNoteOfIV(note);
            case 5:
                return getNoteOfV(note);
            case 6:
                return getNoteOfVI(note);
            case 7:
                return getNoteOfVII(note);
            default:
                return 0;
        }
    }

    public float getNoteOfI(string note)
    {
        switch (note)
        {
            case "tonique":
                return 261.626f;

            case "tierce":
                return 311.127f;

            case "quinte":
                return 391.995f;

            case "septieme":
                return 466.164f;

            default:
                return 0f;
        }
    }

    public float getNoteOfII(string note)
    {
        switch (note)
        {
            case "tonique":
                return 293.665f ;

            case "tierce":
                return 349.228f;

            case "quinte":
                return 415.305f;

            case "septieme":
                return 493.883f;

            default:
                return 0;
        }
    }

    public float getNoteOfIII(string note)
    {
        switch (note)
        {
            case "tonique":
                return 311.127f ;

            case "tierce":
                return 369.994f;

            case "quinte":
                return 466.164f;

            case "septieme":
                return 554.365f;

            default:
                return 0f;
        }
    }

    public float getNoteOfIV(string note)
    {
        switch (note)
        {
            case "tonique":
                return 349.228f ;

            case "tierce":
                return 415.305f;

            case "quinte":
                return 523.251f;

            case "septieme":
                return 622.254f;

            default:
                return 0;
        }
    }

    public float getNoteOfV(string note)
    {
        switch (note)
        {
            case "tonique":
                return 391.995f ;

            case "tierce":
                return 466.164f;

            case "quinte":
                return 587.33f;

            case "septieme":
                return 698.456f;

            default:
                return 0;
        }
    }

    public float getNoteOfVI(string note)
    {
        switch (note)
        {
            case "tonique":
                return 415.305f ;

            case "tierce":
                return 493.883f;

            case "quinte":
                return 622.254f;

            case "septieme":
                return 739.989f;

            default:
                return 0f;
        }
    }

    public float getNoteOfVII(string note)
    {
        switch (note)
        {
            case "tonique":
                return 466.164f ;

            case "tierce":
                return 554.365f ;

            case "quinte":
                return 659.255f;

            case "septieme":
                return 830.609f;

            default:
                return 0f;
        }
    }


}