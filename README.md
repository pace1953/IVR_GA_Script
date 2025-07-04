# IVR_GA_Script
DoorOpenInteraction.cs -> 將Script放在指定物件上，當 tag 為"Hand"的物件，「Collider(碰撞)」到該指定物件時，系統會載入指定的場景(sceneName，自行在Inspector輸入)以及觸發的事件(finishEvent，Inspector 中自訂)

InteractableObject.cs -> 將Script放在指定物件上，處理物件碰撞互動。當 tag 為"Player"的物件與掛載此腳本的物件發生碰撞(Collision)時，會觸發指定事件。在Inspector中需設定參數：finishEvent(碰撞發生時要觸發的事件，可自行在Inspector中自訂)。

PosterSelector.cs -> 將Script放在指定物件上，用來控制海報選擇。 在Inspector中需要設定posterObjects(海報物件)和selectButtons(對應的選擇按鈕)。 系統啟動時會顯示所有的海報及其按鈕，當使用者點擊選擇按鈕時，該海報會從可用列表中移除。第一次選擇後會更新UI顯示，第二次選擇後會在控制台輸出選擇結果(如「選擇的海報索引：1」)。

VideoEndAction.cs -> 將Script放在指定物件上，當影片播放結束時觸發指定事件。 在Inspector中需設定兩個參數：videoPlayer(指定的影片播放器)和finishEvent(影片結束時要觸發的事件，可自行在Inspector中設定)。

SceneTransition.cs -> 將Script放在指定物件上，提供場景切換功能。可以放在一個按鈕上，按下去就會觸發場景切換。

Single_Context_Controller.cs -> 將Script放在指定物件上，控制NPC對話。 在Inspector中需要設定ui_text(顯示對話內容的Text文字)、NPCName(NPC名稱)、nameText(顯示NPC名稱的Text)、head_ui(NPC頭像的Image)、head_img(NPC頭像圖片)、auto_play(文字是否自動播放)、step_by_step(是否逐字顯示)、speed(文字顯示速度)、context_list(對話內容列表，將對話存放在此)及finish_event(可以設定對話結束時觸發的事件)，物件啟用時自動顯示第一條對話，並提供NextContext()進入下一對話(可以透過點擊按鈕控制對話)。