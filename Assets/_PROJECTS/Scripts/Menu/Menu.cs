using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// function to activate object 
    /// </summary>
    /// <param name="_target"> target to activate </param>
    public void Activation(GameObject _target)
    {
        //activating target
        _target.SetActive(true);
    }


    /// <summary>
    /// function to deactivate object
    /// </summary>
    /// <param name="_target"> target to deactivate </param>
    public void Deactivation(GameObject _target)
    {
        //deactivating target
        _target.SetActive(false);
    }

    /// <summary>
    /// function to restarting scene
    /// </summary>
    public void Restart()
    {
        //clear all the pool since the data is static and it would cause conflict
        QuocAnhPoolManager.poolM.Clear();
        QuocAnhPoolManager.poolIDM.Clear();
        //set time back to normal
        Time.timeScale = 1;
        //getting current scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// function to pause scene
    /// </summary>
    /// <param name="_pause"> declare whether to pause </param>
    public void Pausing(bool _pause)
    {
        switch(_pause)
        {
            //stop pausing
            case false:
            //player able to control
            GameManager.Instance.playerControl.ableToControl = true;
            //set time back to normal
            Time.timeScale = 1;
            break;
            
            //pausing
            case true:
            //player not be able to control
            GameManager.Instance.playerControl.ableToControl = false;
            //stop time
            Time.timeScale = 0;
            break;
        }
    }
}
