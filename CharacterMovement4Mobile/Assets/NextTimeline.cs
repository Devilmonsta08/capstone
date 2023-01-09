using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NextTimeline : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            nextTimeLine();
        }
    }

    public void nextTimeLine()
    {
        if(playableDirector.time < 5.95f)
        {
            playableDirector.time = 5.95f;
        }
        else if(playableDirector.time > 5.95f && playableDirector.time < 12.21f)
        {
            playableDirector.time = 12.22f;
        }
        else if (playableDirector.time > 12.21f && playableDirector.time < 18.43f)
        {
            playableDirector.time = 18.44f;
        }
        else if (playableDirector.time > 18.43f && playableDirector.time < 24.08f)
        {
            playableDirector.time = 24.08f;
        }
        // AND MORE

    }
}
