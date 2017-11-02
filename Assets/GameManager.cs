using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour {

    [Header("Components")] //Created Header for the component section in unity
    [Space(10)]
    public TextMesh QuestionTextMesh; //text mesh for questions and answers
    public TextMesh AnswerLeftTextMesh;
    public TextMesh AnswerRightTextMesh;
    public Camera myCamera;
    public Text LeftButtonText;
    public Text RightButtonText;
    public TextMesh ClientTextMesh;
    public TextMesh PlayerTextMesh;

    [Header("Client Statements")]
    [TextArea(2, 10)]
    public List<string> Client;//list of statements by the client

    [Header("Player Statements")]
    [TextArea(2, 10)]
    public List<string> Player;// list of statements by the player


    [Header("Questions")]
    [TextArea(2, 10)]
    public List<string> Questions; //list for Questions and answers

    [Header("Answers")]  //add a header to this section
    [TextArea(2, 10)]  //display the list of strings that follows as text areas, with a min or 2 lines & a max of 10 lines for the text
    public List<string> Answers1;
    [Space(10)] //put some space below the header
    [TextArea(2, 10)]  //display the list of strings that follows as text areas, with a min or 2 lines & a max of 10 lines for the text
    public List<string> Answers2;


    //private variables have to be set in code, like p5.play's global variables
    private int currentQuestion; //Keep track of which questions
    private int goodAnswers; //Count Good Answers
    private int badAnswers; //Count Bad Answers
    private int currentClient;//keep track of client statements
    private int currentPlayer;//keep track of player statements

    private Rect leftAnswerRect;  //a rect we'll set to the bounds of the left answer
    private Rect rightAnswerRect;  //a rect we'll set to the bounds of the right answer
    private Renderer leftRend; //the left textmesh's renderer
    private Renderer rightRend; //the right textmesh's renderer

    //public BoxCollider buttonColliderLeft;

    //public BoxCollider buttonColliderRight;



    private void Awake()
    {
        
    }



    // Use this for initialization
    void Start () {

        //annoyingly, you can't make linebreaks in the unity editor
        //so here we're just goint through all the strings in Questions
        //and wherever we see "BREAK" we're replacing it with \n
        //which is then read as a line break
        int i = 0;
        foreach (string s in Questions)
        {
            Questions[i] = s.Replace("BREAK", "\r\n");
            i++;
        }
        currentQuestion = 0; //set current question to 0
        currentClient = 0;
        currentPlayer = 0;
         
        QuestionTextMesh.text = Questions[currentQuestion]; //set the starting values for question text mesh
        AnswerLeftTextMesh.text = Answers1[currentQuestion]; //set the starting values for left answer text mesh
        AnswerRightTextMesh.text = Answers2[currentQuestion]; //set the starting values for right answer text mesh
        ClientTextMesh.text = Client[currentClient];
        PlayerTextMesh.text = Player[currentClient];

        leftRend = AnswerLeftTextMesh.GetComponent<Renderer>(); //set the renderers
        rightRend = AnswerRightTextMesh.GetComponent<Renderer>();

        LeftButtonText.text = Answers1[0];
        RightButtonText.text = Answers2[0];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonClicked(int buttonNum)
    {
        Debug.Log("Button " + buttonNum + " clicked");
        Debug.Log(currentQuestion);







        if (currentQuestion >= 6) //Now all questions answered, so it's time to give a result (no matter what we clicked)
        {
            AnswerLeftTextMesh.text = ""; //set answer to blank
            AnswerRightTextMesh.text = ""; //set answer to blank
            if (goodAnswers > badAnswers) //if more good answers than bad
            {
                AnswerLeftTextMesh.text = "(I have to survive out here) Sure."; //Cat wants to live with you
                
            }
            else
            {
                AnswerRightTextMesh.text = "You don't seem to understand "; //Cat can't live with you
                
            }
        }
        else //otherwise, we need to keep updating answers & questions
        {
            //Answer is Left Answer, as the user clicked on a point that is within the left answer rect
            if (buttonNum == 0)
            {
                //all of these are the same, we set a new cat sprite, then add one to goodAnswers or badAnswers accordingly
                if (currentQuestion == 0)
                {
                    LeftButtonText.text = Answers1[0];
                    RightButtonText.text = Answers2[0];
                    goodAnswers++; //add one to good answers
                }
                else if (currentQuestion == 1)
                {
                    
                    goodAnswers++;
                }
                else if (currentQuestion == 2)
                {
                 
                    badAnswers++;
                }
                else if (currentQuestion == 3)
                {
                    
                    badAnswers++;
                }
                else if (currentQuestion == 4)
                {
                    
                    goodAnswers++;
                }
                else if (currentQuestion == 5)
                {
                    
                    goodAnswers++;
                }
                else if (currentQuestion == 6)
                {
                  
                    goodAnswers++;
                }
            }
            //Answer is Right Answer, as the user clicked on a point that is within the right answer rect
            else if (buttonNum == 1)
            {
                //all of these are the same, we set a new cat sprite, then add one to goodAnswers or badAnswers accordingly
                if (currentQuestion == 0)
                {
                    //set the cat sprite
                    badAnswers++; //add one to good answers
                }
                if (currentQuestion == 1)
                {
                    
                    badAnswers++;
                }
                else if (currentQuestion == 2)
                {
                    
                    badAnswers++;
                }
                else if (currentQuestion == 3)
                {
                    
                    goodAnswers++;
                }
                else if (currentQuestion == 4)
                {
                    
                    badAnswers++;
                }
                else if (currentQuestion == 5)
                {
                   
                    badAnswers++;
                }
                else if (currentQuestion == 6)
                {
                   
                    badAnswers++;
                }
            }

            currentQuestion++; //moving on to the next question
            QuestionTextMesh.text = Questions[currentQuestion]; //setting the text mesh to the next question
            AnswerLeftTextMesh.text = Answers1[currentQuestion]; //setting the text mesh to the next answer
            AnswerRightTextMesh.text = Answers2[currentQuestion]; //setting the text mesh to the next answer


            //update button size
            Vector3 newSizeLeft = AnswerLeftTextMesh.GetComponent<MeshRenderer>().bounds.size;
            Vector3 newSizeRight = AnswerRightTextMesh.GetComponent<MeshRenderer>().bounds.size;

            //buttonColliderLeft.size = newSizeLeft;
            //buttonColliderRight.size = newSizeRight;

        }
    }


}

