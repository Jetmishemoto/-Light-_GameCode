using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// This is a Singltion Class meaning it can be assesed from any script on any game object


public class LevelManager 
{

    //------ when you use static it means this veriable belongs to this class
    /*       |
             |   
             |
             V                                       */
    private static LevelManager instance;




    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LevelManager();

            }
            return instance;
        }
    }
    // Constants to make sure you dont load infinte levels and worlds
    private const int LEVELS_PRE_WORLD = 4;
    private const int MAXIMUM_WORLD = 1;
    private const int MAXIMUM_LEVEL = 4;

// variables to keep track of the current level
    private int world = 1; 
    private int level = 1;
    public string LevelName { get { return "level" + world + "-" + level; } }

    // properties to read world and level information
    public int Level { get { return level;  } }
    public int World { get { return world; } }
    



    //
    public void LoadLevel (int world, int level)
    {
        this.world = world;
        this.level = level;

        if (world > MAXIMUM_WORLD || ( world == MAXIMUM_WORLD && level > MAXIMUM_LEVEL))
        {
            this.world = 1;
            this.level = 1;
            SceneManager.LoadScene("Menu");
        }

            SceneManager.LoadScene("Level" + world + "-" + level);
        
    }

    public void LoadNextLevel()
    {
       this.level++;
        if (this.level > LEVELS_PRE_WORLD)
        {
            this.level = 1;
            this.world++;
        }
        LoadLevel(this.world, this.level);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
