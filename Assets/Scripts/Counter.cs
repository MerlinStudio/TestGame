using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public static Counter instance = null;

    public GameObject isCounter;
    public GameObject isLossCounter;

    public Animator Character;

    private Animation _animation;
    private Animation _animationLoss;
    private Animator _charAnimator;

    private Text _text;
    private Text _lossText;

    private int _numberFigureDestroyed;
    private int _numberFigureLoss;
    private int _countWin;
    private int _countGameOver;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        _text = isCounter.transform.GetChild(0).GetComponent<Text>();
        _animation = isCounter.GetComponent<Animation>();

        _lossText = isLossCounter.transform.GetChild(0).GetComponent<Text>();
        _animationLoss = isLossCounter.GetComponent<Animation>();

        _charAnimator = Character.GetComponent<Animator>();

        _countWin = GameSettings.instance.CountForWin;
        _countGameOver = GameSettings.instance.CountForGameOver;
        _text.text = string.Format("{0:0}/{1:0}", _numberFigureDestroyed, _countWin);
        _lossText.text = string.Format("{0:0}/{1:0}", _numberFigureLoss, _countGameOver);
    }

    public void UpdateCount()
    {
        _numberFigureDestroyed++;
        _text.text = string.Format("{0:0}/{1:0}", _numberFigureDestroyed, _countWin);
        _animation.Play("Counter");
        _charAnimator.SetTrigger("Jump");
        if (_numberFigureDestroyed == _countWin)
        {
            Menu.instance.OpenMenuWon();
        }
    }

    public void UpdateLossCount()
    {
        _numberFigureLoss++;
        _lossText.text = string.Format("{0:0}/{1:0}", _numberFigureLoss, _countGameOver);
        RandomAnimation();
        _animationLoss.Play("Counter");
        if (_numberFigureLoss == _countGameOver)
        {
            Menu.instance.OpenMenuGameOver();
        }
    }

    private void RandomAnimation()
    {
        int random = Random.Range(0, 2);
        if(random == 0)
        {
            _charAnimator.SetTrigger("Cry");
        }
        else
            _charAnimator.SetTrigger("Loss");
    }
}
