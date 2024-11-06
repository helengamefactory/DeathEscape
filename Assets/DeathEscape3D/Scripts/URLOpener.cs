using UnityEngine;

public class URLOpener : MonoBehaviour
{
    [SerializeField] string _URLToOpen;
    public void _OpenURL()
    {
        Application.OpenURL( _URLToOpen );
    }
    public void _OpenRatings()
    {
        BAHMANPublicRelation._Instance._RateClicked();
    }
}
