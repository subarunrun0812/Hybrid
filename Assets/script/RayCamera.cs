using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    [SerializeField] Camera fpsCam;             // カメラ
    [SerializeField] float distance = 1.5f;    // 検出可能な距離
    [Header("使用するスクリプトをアタッチする")]
    [SerializeField] ColorLockKey colorLockKey;
    [SerializeField] private LockKeyDoorScript colorKeydoor;
    [SerializeField] private parkToMuseumKey museumkey_s;
    [SerializeField] private ItemsUI itemsUI;
    // [SerializeField] private NotOpenDoorScript notOpen_s;
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject aimE;
    private void Start()
    {
        NoActiveAimE();
    }
    void Update()
    {

        if (aimE.activeSelf == true)
        {
            NoActiveAimE();
        }
        // Rayはカメラの位置からとばす
        var rayPosition = fpsCam.transform.position;
        // Rayはカメラが向いてる方向にとばす
        var rayDirection = fpsCam.transform.forward.normalized;

        // Hitしたオブジェクト格納用
        RaycastHit raycastHit;

        // Rayを飛ばす（out raycastHit でHitしたオブジェクトを取得する）
        var isHit = Physics.Raycast(rayPosition, rayDirection, out raycastHit, distance);

        // Debug.DrawRay (Vector3 start(rayを開始する位置), Vector3 dir(rayの方向と長さ), Color color(ラインの色));
        Debug.DrawRay(rayPosition, rayDirection * distance, Color.red);

        // なにかを検出したら
        if (isHit)
        {
            //rayでhitした名前を入れる変数
            string hitname = raycastHit.collider.gameObject.name;
            string hittag = raycastHit.collider.gameObject.tag;
            // LogにHitしたオブジェクト名を出力
            // Debug.Log("HitObject : " + hitname);

            if (hitname == "Button_1green" || hitname == "Button_2yellow" || hitname == "Button_3lightBlue"
            || hitname == "Button_4red" || hitname == "Button_5purple" || hitname == "Button_6blue"
            || hitname == "Button_7gray" || hitname == "Button_8brown" || hitname == "Button_9pink"
            || hittag == "ColorKeyDoor" || hittag == "NormalDoor" || hittag == "NotOpenDoor"
            || hitname == "parkToMuseumKey" || hitname == "parkToMuseumDoor" || hittag == "Bed"
            || hittag == "Locker" || hittag == "BackRoomsDoor" || hittag == "MazeMap"
            || hittag == "BackRoomsExitDoor" || hittag == "NormalDoorRight" || hittag == "Memo"
            || hittag == "KeyDoor" || hittag == "KeyDoor_Key" || hittag == "MorgueBox_Door"
            || hittag == "DuctDoor" || hittag == "ShelfDoor" || hittag == "Driver" || hittag == "BookShelf"
            || hittag == "Drawer" || hittag == "Handle")
            {
                ActiveAimE();
            }
            //rayが当たった瞬間に驚かす
            else if (hittag == "DeadBody")
            {
                ShakeDaedBody shakeDaedBody = raycastHit.collider.GetComponent<ShakeDaedBody>();
                shakeDaedBody.DeadBodyShake();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //colorLockKeyの処理
                if (hitname == "Button_1green")
                {
                    colorLockKey.Button_1green();
                }
                else if (hitname == "Button_2yellow")
                {
                    colorLockKey.Button_2yellow();
                }
                else if (hitname == "Button_3lightBlue")
                {
                    colorLockKey.Button_3lightBlue();
                }
                else if (hitname == "Button_4red")
                {
                    colorLockKey.Button_4red();
                }
                else if (hitname == "Button_5purple")
                {
                    colorLockKey.Button_5purple();
                }
                else if (hitname == "Button_6blue")
                {
                    colorLockKey.Button_6blue();
                }
                else if (hitname == "Button_7gray")
                {
                    colorLockKey.Button_7gray();
                }
                else if (hitname == "Button_8brown")
                {
                    colorLockKey.Button_8brown();
                }
                else if (hitname == "Button_9pink")
                {
                    colorLockKey.Button_9pink();
                }
                //doorの処理
                else if (hittag == "ColorKeyDoor")
                {
                    colorKeydoor.IsNearColorLockKeyDoor();
                }
                else if (hittag == "NormalDoor")
                {
                    NormalDoor normalDoor_s = raycastHit.collider.GetComponent<NormalDoor>();
                    normalDoor_s.IsNearNormalDoor();
                }
                else if (hittag == "NormalDoorRight")
                {
                    NormalDoorRight normalDoorRight = raycastHit.collider.GetComponent<NormalDoorRight>();
                    normalDoorRight.IsNearNormalDoor();
                }
                else if (hittag == "NotOpenDoor")
                {
                    NotOpenDoorScript notOpen_s = raycastHit.collider.GetComponent<NotOpenDoorScript>();
                    notOpen_s.IsNearNotOpenDoor();
                }
                else if (hittag == "BackRoomsDoor")
                {
                    BackRoomsDoor backRoomsDoor = raycastHit.collider.GetComponent<BackRoomsDoor>();
                    backRoomsDoor.IsNearBackRoomsDoor();
                }
                else if (hitname == "parkToMuseumKey")
                {
                    museumkey_s.parkTOMuseumKey();
                }
                else if (hittag == "KeyDoor")
                {
                    KeyDoor_Door keyDoor_Door = raycastHit.collider.GetComponent<KeyDoor_Door>();
                    keyDoor_Door.IsNearDoor();
                }
                else if (hittag == "KeyDoor_Key")
                {
                    KeyDoor_Key KeyDoor_Key = raycastHit.collider.GetComponent<KeyDoor_Key>();
                    KeyDoor_Key.GetKey();
                }
                else if (hitname == "parkToMuseumDoor")
                {
                    museumkey_s.door_parkToMuseumDoor();
                }
                else if (hittag == "Bed")
                {
                    GetUnderTheBed getUnderTheBed = raycastHit.collider.GetComponent<GetUnderTheBed>();
                    getUnderTheBed.TheBedFunction();
                }
                else if (hittag == "Locker")
                {
                    Locker locker = raycastHit.collider.GetComponent<Locker>();
                    locker.GoInsideLocker();
                }
                else if (hittag == "MazeMap")
                {
                    itemsUI.MazeMapFunction();
                }
                else if (hittag == "BackRoomsExitDoor")
                {
                    MazeExitDoor mazeExitDoor = raycastHit.collider.GetComponent<MazeExitDoor>();
                    mazeExitDoor.IsNearMazeExitDoor();
                }
                else if (hittag == "Memo")
                {
                    Memo memo = raycastHit.collider.GetComponent<Memo>();
                    memo.MemoUION();
                }
                else if (hittag == "MorgueBox_Door")
                {
                    MorgueBox_Door morgueBox_Door = raycastHit.collider.GetComponent<MorgueBox_Door>();
                    morgueBox_Door.IsNearDoor();
                }
                else if (hittag == "DuctDoor")
                {
                    DuctDoor ductDoor = raycastHit.collider.GetComponent<DuctDoor>();
                    ductDoor.IsNearDoctDoor();
                }
                else if (hittag == "ShelfDoor")
                {
                    ShelfDoor shelfDoor = raycastHit.collider.GetComponent<ShelfDoor>();
                    shelfDoor.IsNearNormalDoor();
                }
                else if (hittag == "Driver")
                {
                    DriverItem driverItem = raycastHit.collider.GetComponent<DriverItem>();
                    driverItem.GetDriver();
                }
                else if (hittag == "BookShelf")
                {
                    BookShelf bookShelf = raycastHit.collider.GetComponent<BookShelf>();
                    bookShelf.BookShelfMove();
                }
                else if (hittag == "Drawer")
                {
                    MoveDrawer moveDrawer = raycastHit.collider.GetComponent<MoveDrawer>();
                    moveDrawer.MoveDrawerFunction();
                }
                else if (hittag == "Handle")
                {
                    MoveHandle moveHandle = raycastHit.collider.GetComponent<MoveHandle>();
                    moveHandle.LowerHandle();
                }
            }
        }
    }
    public void ActiveAimE()
    {
        aim.SetActive(false);
        aimE.SetActive(true);
    }
    private void NoActiveAimE()
    {
        aim.SetActive(true);
        aimE.SetActive(false);
    }
}