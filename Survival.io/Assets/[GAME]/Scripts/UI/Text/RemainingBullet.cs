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
    

    public int count = 0;
    public int maxCount = 0;

    void Update()
    {
        if(GameManager.instance.isLevelEnd) return;

        maxCount = BaseBulletSpawner.maxBulletCount;
        count = BaseBulletSpawner.currentBulletCount;
        BulletCountText.text = count + "/" + maxCount;
    }
}
