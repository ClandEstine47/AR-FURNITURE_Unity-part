package com.clandestinestudio.arfurniture

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import com.unity3d.player.UnityPlayer
import com.unity3d.player.UnityPlayerActivity

class UnityHandlerActivity : UnityPlayerActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_unity_handler)

        var unityBtn: Button = findViewById(R.id.btn_OpenUnity)

        unityBtn.setOnClickListener{
            var intent = Intent(this, UnityPlayerActivity::class.java)
            startActivity(intent)
//            val handler = Handler()
//            val delay: Long = 5000 // delay for 5 second

//            handler.postDelayed({
            // code to be executed after the delay
            UnityPlayer.UnitySendMessage("DataManager", "ReceivedMessage", "YES!!!")
//            }, delay)
        }
    }


}