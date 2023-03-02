using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemainingBullet : MonoBehaviour
{
    private TextMeshProUGUI bulletCountText;
    public TextMeshProUGUI BulletCountText
    {
        get
        {
            if(bulletCountText == null)
            bulletCountText = GetComponent<TextMeshProUGUI>();

            return bulletCountText;
        }
    }

    // private void OnEnable()
    // {
    //     EventManager.OnGunUpdate.AddListener(RefreshBulletText);
    //     //EventManager.OnFirstGunCall.AddListener(gun);
    // }

    // private void OnDisable()
    // {
    //     EventManager.OnGunUpdate.RemoveListener(RefreshBulletText); 
    //     //EventManager.OnFirstGunCall.RemoveListener(gun);
    // }

    public int count = 0;
    public int maxCount = 0;

    // void Start()
    // {
    //     maxCount = BaseBulletSpawner.maxBulletCount;
    // }

    void Update()
    {
        maxCount = BaseBulletSpawner.maxBulletCount;
        count = BaseBulletSpawner.currentBulletCount;
        BulletCountText.text = count + "/" + maxCount;
    }
    // public void RefreshBulletText()
    // {
    //     maxCount = BaseBulletSpawner.maxBulletCount;
    //     count = BaseBulletSpawner.currentBulletCount;

    //     BulletCountText.text = count + "/" + maxCount;
    // }

    // void gun()
    // {
    //     maxCount = Pistol.maxBulletCount;
    // }
}
