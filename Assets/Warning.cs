using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {

    public float duration = 1;

    [SerializeField]
    private int blinksCount = 3;

    [SerializeField]
    private float BlinkTimeVisiblePercent = 0.7f;

    private float BlinkTimeVisible = 1;
    private float BlinkTimeHidden = 0;

    private enum State
    {
        Hidden,
        BlinkHidden,
        BlinkShowed,
    }

    State state = State.Hidden;

    private float stateTime = 0;
    private float showingTime = 0;



	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
	
    private void BlinkShow()
    {
        state = State.BlinkShowed;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        stateTime = 0;
    }

    private void BlinkHide()
    {
        state = State.BlinkHidden;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        stateTime = 0;
    }

    private void Hide()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        state = State.Hidden;
    }

    public void Activate()
    {
        BlinkTimeVisible = duration * BlinkTimeVisiblePercent / ((float) blinksCount + BlinkTimeVisiblePercent - 1);
        BlinkTimeHidden = BlinkTimeVisible * (1 - BlinkTimeVisiblePercent) / BlinkTimeVisiblePercent;
        showingTime = 0;
        switch (state)
        {
            case State.Hidden:
                BlinkShow();
                stateTime = 0;
                break;
            default:
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        showingTime += Time.deltaTime;
        stateTime += Time.deltaTime;
	    switch (state)
        {
            case State.BlinkShowed:
                if (stateTime > BlinkTimeVisible)
                {
                    BlinkHide();
                }
                break;
            case State.BlinkHidden:
                if (stateTime > BlinkTimeHidden)
                {
                    if (showingTime > duration)
                    {
                        Hide();
                    }
                    else
                    {
                        BlinkShow();
                    }
                }
                break;
            default:
                break;
        }
	}
}
